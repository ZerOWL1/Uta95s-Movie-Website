using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Uta95s_Movie_Web___BETA_0._1
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
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            services.AddSession();
            services.AddControllersWithViews();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            /*app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });*/

            //Set Default Startup
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Index}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/index",
                    pattern: "{controller=Index}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/home",
                    pattern: "{controller=Home}/{action=Home}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/mail",
                    pattern: "{controller=Home}/{action=Mail}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/code",
                    pattern: "{controller=Home}/{action=RandomCode}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/details",
                    pattern: "{controller=Home}/{action=Details}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/films",
                    pattern: "{controller=Home}/{action=Movies}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/profiles",
                    pattern: "{controller=Home}/{action=Profile}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/login",
                    pattern: "{controller=Index}/{action=Login}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/logout",
                    pattern: "{controller=Home}/{action=Logout}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/signup",
                    pattern: "{controller=Index}/{action=Signup}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/verifyCode",
                    pattern: "{controller=Home}/{action=VerifyCode}/{id?}");
            });
        }
    }
}
