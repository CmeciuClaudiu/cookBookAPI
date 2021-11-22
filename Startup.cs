using cookbookAPI.EFCore.Context;
using cookbookAPI.Engine;
using cookbookAPI.Hubs;
using cookbookAPI.Managers;
using cookbookAPI.Resources;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Web.Http;

namespace cookbookAPI
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
            services.AddControllers();
            services.AddSignalR();

            services.AddScoped<Managers.Contract.IRecipesManager, RecipesManager>();
            services.AddScoped<Managers.Contract.IUsersManager, UsersManager>();
            services.AddScoped<Engine.Contract.IEligibilityEngine, EligibilityEngine>();
            services.AddScoped<Resources.Contract.IRecipeResource, RecipeResource>();
            services.AddScoped<Resources.Contract.IUserResource, UserResource>();
            services.AddScoped<Managers.Contract.IChatMsgManager, ChatMsgManager>();

            services.AddSwaggerGen();

            services.AddDbContext<CookbookDatabaseContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("RecipesDatabase"))
                );

            services.AddDbContext<UsersDatabaseContext>(options =>
                options.UseSqlServer(
                        Configuration.GetConnectionString("UsersDatabase"))
                    );

            services.AddCors(c => c.AddPolicy("AllowOrigin", options => {
                options.AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithOrigins("http://localhost:4200","http://cookbook.ddns.net")
                        .AllowCredentials();
                        }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowOrigin");

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/chatsocket");
            });
        }
    }
}
