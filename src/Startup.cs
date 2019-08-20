using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HackQuestion.Libraries.Data.Context;
using HackQuestion.Models;
using HackQuestion.Services;
using HackQuestion.Libraries.Data.Repository;
using HackQuestion.Libraries.Core.Domain.Categories;
using HackQuestion.Libraries.Services.Interfaces;
using HackQuestion.Libraries.Services.Entity;
using Microsoft.AspNetCore.Rewrite;

namespace HackQuestion
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

            services.AddDbContext<HackContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("HackConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<HackContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(ICategoryServices), typeof(CategoryServices));
            services.AddScoped(typeof(IQuestionServices), typeof(QuestionServices));


            //Please pay attention on that:
            // Singleton which creates a single instance throughout the application. It creates the instance for the first time and reuses the same object in the all calls.
            // Scoped lifetime services are created once per request within the scope. It is equivalent to Singleton in the current scope. eg. in MVC it creates 1 instance per each http request but uses the same instance in the other calls within the same web request.
            // Transient lifetime services are created each time they are requested. This lifetime works best for lightweight, stateless services. 


            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            
            

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
