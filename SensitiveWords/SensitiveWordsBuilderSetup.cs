using Microsoft.OpenApi.Models;
using SensitiveWords.Model;
using System.Reflection;

namespace SensitiveWords
{
    public static class SensitiveWordsBuilderSetup
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Sensitive Words",
                    Description = "An API for maintaining and applying a list of inappropriate words",
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

            });

            builder.Services.AddDbContext<DatabaseContext>();
            builder.Services.AddScoped<IWordService, WordService>();
            builder.Services.AddScoped<IWordMasker, WordMasker>();
        }
    }
}
