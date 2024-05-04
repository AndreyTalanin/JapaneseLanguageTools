using System;

using JapaneseLanguageTools.Configuration;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JapaneseLanguageTools.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void UseSpa(this IApplicationBuilder applicationBuilder)
    {
        IServiceProvider serviceProvider = applicationBuilder.ApplicationServices;

        IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();
        IWebHostEnvironment webHostEnvironment = serviceProvider.GetRequiredService<IWebHostEnvironment>();

        applicationBuilder.UseSpa(spaBuilder =>
        {
            if (webHostEnvironment.IsDevelopment())
            {
                SpaDevelopmentServerConfiguration spaDevelopmentServerConfiguration = new();
                configuration.GetSection(SpaDevelopmentServerConfiguration.SectionName)
                    .Bind(spaDevelopmentServerConfiguration);

                applicationBuilder.Use(async (context, next) =>
                {
                    context.Request.Headers.AcceptEncoding = string.Empty;

                    await next.Invoke(context);
                });

                string developmentServerBaseUri = spaDevelopmentServerConfiguration.DevelopmentServerBaseUri
                    ?? throw new InvalidOperationException("Unable to read the Single Page Application (SPA) development server base URI from the configuration.");

                spaBuilder.UseProxyToSpaDevelopmentServer(developmentServerBaseUri);
            }
        });
    }
}
