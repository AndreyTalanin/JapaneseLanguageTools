using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace JapaneseLanguageTools;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            string version = "v0.1.0";
            OpenApiContact contact = new()
            {
                Name = "Andrey Talanin",
                Email = "andrey.talanin@outlook.com",
                Url = new Uri("https://github.com/AndreyTalanin"),
            };
            OpenApiLicense license = new()
            {
                Name = "The MIT License",
                Url = new Uri("https://github.com/AndreyTalanin/JapaneseLanguageTools/blob/main/LICENSE.md"),
            };

            options.SwaggerDoc("JapaneseLanguageTools", new OpenApiInfo()
            {
                Title = $"Japanese Language Tools {version}",
                Description = "Initial pre-release (unstable) API version.",
                Version = version,
                Contact = contact,
                License = license,
            });

            options.SupportNonNullableReferenceTypes();
        });
    }

    public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostEnvironment)
    {
        if (webHostEnvironment.IsDevelopment())
        {
            applicationBuilder.UseSwagger();
            applicationBuilder.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint($"/swagger/JapaneseLanguageTools/swagger.json", $"JapaneseLanguageTools");
            });

            applicationBuilder.UseDeveloperExceptionPage();
        }
        else
        {
            applicationBuilder.UseHsts();
        }

        applicationBuilder.UseHttpsRedirection();

        applicationBuilder.UseStaticFiles();

        applicationBuilder.UseRouting();

        applicationBuilder.UseAuthorization();

        applicationBuilder.UseEndpoints(endpointRouteBuilder =>
        {
            endpointRouteBuilder.MapControllers();
        });
    }
}
