using Abp.Owin;
using MyAbpProject.Api.Controllers;
using MyAbpProject.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using MyAbpProject.Api.OAuthOptions;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(Startup))]

namespace MyAbpProject.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //第一步：配置跨域访问
            app.UseCors(CorsOptions.AllowAll);

            app.UseOAuthBearerAuthentication(AccountController.OAuthBearerOptions);

            //第二步：使用OAuth密码认证模式
            app.UseOAuthAuthorizationServer(OAuthOptions.CreateServerOptions());

            //第三步：使用Abp
            app.UseAbp();   



            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.MapSignalR();

            //ENABLE TO USE HANGFIRE dashboard (Requires enabling Hangfire in MyAbpProjectWebModule)
            //app.UseHangfireDashboard("/hangfire", new DashboardOptions
            //{
            //    Authorization = new[] { new AbpHangfireAuthorizationFilter() } //You can remove this line to disable authorization
            //});
        }
    }
}