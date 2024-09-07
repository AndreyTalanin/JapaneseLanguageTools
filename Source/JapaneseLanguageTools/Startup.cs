using System;
using System.IO;

using JapaneseLanguageTools.Core.AutoMapper;
using JapaneseLanguageTools.Data.Contexts;
using JapaneseLanguageTools.Data.Sqlite.Contexts;
using JapaneseLanguageTools.Extensions;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace JapaneseLanguageTools;

// Disable the IDE0001 (Simplify name) notification to preserve explicit service types.
#pragma warning disable IDE0001

public class Startup
{
    private readonly IConfiguration m_configuration;

    public Startup(IConfiguration configuration)
    {
        m_configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddKeyedSingleton<SqliteMainDbContextConnectionString>(SqliteMainDbContextConnectionStrings.MainConnectionString, (serviceProvider, serviceKey) =>
        {
            string connectionStringName = SqliteMainDbContextConnectionStrings.MainConnectionString;
            string? connectionString = m_configuration.GetConnectionString(connectionStringName);
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException($"Unable to get the connection string using the \"{connectionStringName}\" configuration key.");
            }

            SqliteConnectionStringBuilder connectionStringBuilder = new(connectionString);
            if (connectionStringBuilder.DataSource.Contains('~'))
            {
                string homeDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                connectionStringBuilder.DataSource = connectionStringBuilder.DataSource.Replace("~", homeDirectoryPath);
                connectionString = connectionStringBuilder.ToString();
            }

            return !File.Exists(connectionStringBuilder.DataSource)
                ? throw new FileNotFoundException($"The data source file ({connectionStringBuilder.DataSource}) does not exist.")
                : new SqliteMainDbContextConnectionString(connectionString);
        });

        services.AddDbContext<MainDbContext, SqliteMainDbContext>((serviceProvider, contextOptions) =>
        {
            SqliteMainDbContextConnectionString connectionString =
                serviceProvider.GetRequiredKeyedService<SqliteMainDbContextConnectionString>(SqliteMainDbContextConnectionStrings.MainConnectionString);

            contextOptions.UseSqlite(connectionString.Value, sqliteOptions =>
            {
                sqliteOptions
                    .MigrationsAssembly(typeof(SqliteMainDbContext).Assembly.FullName)
                    .MigrationsHistoryTable("MigrationsHistory")
                    .CommandTimeout(120);
            });
        });

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

        services.AddSpaStaticFiles(staticFilesOptions =>
        {
            // Must match the <SpaPublishRoot /> MSBuild property of the .csproj file.
            staticFilesOptions.RootPath = "./ReactSpa";
        });

        services.AddAutoMapper(options =>
        {
            options.AddProfile<TagDatabaseProfile>();
            options.AddProfile<TagXmlSerializationProfile>();
            options.AddProfile<ApplicationDictionaryDatabaseProfile>();
            options.AddProfile<ApplicationDictionaryXmlSerializationProfile>();
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
        applicationBuilder.UseSpaStaticFiles();

        applicationBuilder.UseRouting();

        applicationBuilder.UseAuthorization();

        applicationBuilder.UseEndpoints(endpointRouteBuilder =>
        {
            endpointRouteBuilder.MapControllers();
        });

        applicationBuilder.UseSpa();
    }
}
