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
                    pattern: "{controller=Home}/{action=Movies}/{id?}/{val?}");
                endpoints.MapControllerRoute(
                    name: "/profiles",
                    pattern: "{controller=Home}/{action=Profile}/{page?}/{col?}");
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
                endpoints.MapControllerRoute(
                    name: "/category",
                    pattern: "{controller=Home}/{action=Category}/{id?}/{page?}");
                endpoints.MapControllerRoute(
                    name: "/favorite",
                    pattern: "{controller=Home}/{action=AddToFavorite}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/search",
                    pattern: "{controller=Home}/{action=Search}/{id?}/{page?}");

                //user profile
                endpoints.MapControllerRoute(
                    name: "/EditImg",
                    pattern: "{controller=Home}/{action=EditUIMG}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/DeleteFa",
                    pattern: "{controller=Home}/{action=DeleteFavorite}/{mid?}/{col?}");
                endpoints.MapControllerRoute(
                    name: "/deleteUser",
                    pattern: "{controller=Home}/{action=deleteUser}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/editName",
                    pattern: "{controller=Home}/{action=editName}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/editEmail",
                    pattern: "{controller=Home}/{action=editEmail}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/changePass",
                    pattern: "{controller=Home}/{action=changePass}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/changeName",
                    pattern: "{controller=Home}/{action=changeName}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/changeMail",
                    pattern: "{controller=Home}/{action=changeMail}/{id?}");
                
                //Manager
                endpoints.MapControllerRoute(
                    name: "/manager",
                    pattern: "{controller=Manager}/{action=Manager}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/user-manager",
                    pattern: "{controller=Manager}/{action=UserManage}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/movie-manager",
                    pattern: "{controller=Manager}/{action=MovieManage}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/episode-manager",
                    pattern: "{controller=Manager}/{action=EpisodeManage}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/actor-manager",
                    pattern: "{controller=Manager}/{action=ActorManage}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/director-manager",
                    pattern: "{controller=Manager}/{action=DirectorManage}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/genre-manager",
                    pattern: "{controller=Manager}/{action=GenreManage}/{id?}");

                //Edit Control
                endpoints.MapControllerRoute(
                    name: "/editM",
                    pattern: "{controller=Manager}/{action=EditMovie}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/editA",
                    pattern: "{controller=Manager}/{action=EditActor}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/editD",
                    pattern: "{controller=Manager}/{action=EditDirector}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/editE",
                    pattern: "{controller=Manager}/{action=EditEpisode}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/editG",
                    pattern: "{controller=Manager}/{action=EditGenre}/{id?}");

                //Delete Control
                endpoints.MapControllerRoute(
                    name: "/deleteE",
                    pattern: "{controller=Manager}/{action=DeleteE}/{id?}/{val?}");
                endpoints.MapControllerRoute(
                    name: "/deleteA",
                    pattern: "{controller=Manager}/{action=DeleteA}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/deleteD",
                    pattern: "{controller=Manager}/{action=DeleteD}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/deleteG",
                    pattern: "{controller=Manager}/{action=DeleteG}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/deleteM",
                    pattern: "{controller=Manager}/{action=DeleteM}/{id?}");

                //user modified
                endpoints.MapControllerRoute(
                    name: "/deleteU",
                    pattern: "{controller=Manager}/{action=DeleteU}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/upgradeU",
                    pattern: "{controller=Manager}/{action=UpgradeU}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/deUpgradeU",
                    pattern: "{controller=Manager}/{action=DeUpgradeU}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/unbanU",
                    pattern: "{controller=Manager}/{action=BanUser}/{id?}");
                endpoints.MapControllerRoute(
                    name: "/banU",
                    pattern: "{controller=Manager}/{action=UnBanUser}/{id?}");

                //others table
                endpoints.MapControllerRoute(
                    name: "/MDirector",
                    pattern: "{controller=Manager}/{action=MDirector}/{id?}/{did?}");
                endpoints.MapControllerRoute(
                    name: "/MGenre",
                    pattern: "{controller=Manager}/{action=MGenre}/{mid?}/{gid?}");
                endpoints.MapControllerRoute(
                    name: "/MActor",
                    pattern: "{controller=Manager}/{action=MActor}/{aid?}/{mid?}");
            });
        }
    }
}
