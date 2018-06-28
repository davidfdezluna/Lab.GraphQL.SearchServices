using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Lab.GraphQL.SearchServices.App;
using Lab.GraphQL.SearchServices.App.Types;
using Lab.GraphQL.SearchServices.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Lab.GraphQL.SearchServices.API
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
            services
                .AddCors()
                .AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Data services
            services.AddSingleton<IDataPersons, DataPersonsMock>();

            //Dependence GraphQL
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            //GraphQL types
            services.AddTransient<PeopleGraphType>();
            services.AddTransient<OrganizationGraphType>();

            //Dependence Domain
            services.AddTransient<SearchQuery>();
            //services.AddSingleton<ISchema, SearchSchema>();
            services.AddSingleton<ISchema>(s => new SearchSchema(new FuncDependencyResolver(type => (GraphType)s.GetService(type))));
            services.AddTransient<GraphQueryExecuter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl();

            app.UseCors(
                options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            );

            app.UseMvc();
        }
    }
}
