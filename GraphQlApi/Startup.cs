using Autofac;
using GraphQl.Api.GraphQl;
using GraphQl.Common.Database;
using GraphQl.Common.Models;
using GraphQl.Common.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GraphQlApi
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
            services.AddOptions();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphQlApi", Version = "v1" });
            });

            services.AddDbContext<MovieDbContext>(context =>
            {
                context.UseInMemoryDatabase("TimeGraphServer");
            });

            services.AddEntityFrameworkInMemoryDatabase()
                .AddDbContext<MovieDbContext>(context => { context.UseInMemoryDatabase("MovieDb"); });

            services.AddGraphQLServer().AddQueryType<Query>();
            services.AddGraphQLServer().AddMutationType<Mutation>().AddType<Review>();
            services.AddGraphQLServer().AddTypeExtension<QueryMovieResolvers>();
            services.AddGraphQLServer().AddTypeExtension<MutationMovieResolvers>();
            services.AddGraphQLServer().AddTypeExtension<QueryReviewResolvers>();
            services.AddGraphQLServer().AddTypeExtension<MutationReviewResolvers>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQlApi v1"));
            }
            
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGraphQL();
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public virtual void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
            builder.RegisterType<MovieRepository>().As<IMovieRepository>().SingleInstance();
            builder.RegisterType<MovieDbContext>().AsImplementedInterfaces().InstancePerLifetimeScope();
            //builder.RegisterType<DocumentWriter>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<Query>().AsSelf().SingleInstance();
            builder.RegisterType<Mutation>().AsSelf().SingleInstance();
            builder.RegisterType<QueryMovieResolvers>().AsSelf().InstancePerRequest();
            builder.RegisterType<MutationMovieResolvers>().AsSelf().InstancePerRequest();
            builder.RegisterType<QueryReviewResolvers>().AsSelf().InstancePerRequest();
            builder.RegisterType<MutationReviewResolvers>().AsSelf().InstancePerRequest();
            
            //builder.RegisterType<MovieReviewSchema>().AsSelf().SingleInstance();
        }
    }
}
