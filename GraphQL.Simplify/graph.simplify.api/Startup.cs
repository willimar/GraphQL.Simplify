using graph.simplify.api.Queries;
using graph.simplify.api.Repositories;
using graph.simplify.api.Types;
using graph.simplify.core;
using GraphQL.Server;
using GraphQL.Server.Internal;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace graph.simplify.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Depedences

            StartupResolve.ConfigureServices<Startup>(services);
            services.AddScoped<IGraphQLExecuter<AppScheme<SampleQuery>>, DefaultGraphQLExecuter<AppScheme<SampleQuery>>>();
            services.AddScoped<SampleRepository>();
            services.AddScoped<SampleQuery>();
            services.AddScoped<SampleType>();
            services.AddScoped<AppScheme<SampleQuery>>();

            #endregion

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseGraphQL<AppScheme<SampleQuery>>();
            StartupResolve.Configure(app);
        }
    }
}
