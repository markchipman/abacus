using Abacus.WebApi.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace Abacus.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(o =>
            {
                o.SuppressInferBindingSourcesForParameters = true;
            });

            services.AddMvcCore(o =>
            {
                o.OutputFormatters.Clear();
                o.OutputFormatters.Add(new AbacusJsonOutputFormatter(new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Converters =
                    {
                        new StringEnumConverter()
                    },
                    TypeNameHandling = TypeNameHandling.None,
                    DateFormatHandling = DateFormatHandling.IsoDateFormat,
                    DateParseHandling = DateParseHandling.DateTime,
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                    DefaultValueHandling = DefaultValueHandling.Include,
                    FloatFormatHandling = FloatFormatHandling.DefaultValue,
                    Formatting = Formatting.None
                }));
            })
            .AddApiExplorer()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new Info { Title = "Abacus Api", Version = "V1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(o =>
            {
                o.SwaggerEndpoint("/swagger/v1/swagger.json", "Abacus Api V1");
            });
        }
    }
}
