using Abp;
using Abp.Timing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyAbpProject.Web.Controllers
{
    public class TokenController : Controller
    {
        public async Task<string> GetOAuth2Token()
        {
            Uri uri = new Uri("http://localhost:61759" + "/oauth/token");
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.None };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var content = new FormUrlEncodedContent(new Dictionary<string, string>()
                    {
                        {"grant_type", "password"},
                        {"username", "admin" },
                        {"password", "123qwe" },
                        {"client_id", "app" },
                        {"client_secret", "app"},
                    });

                //获取token保存到cookie，并设置token的过期日期                    
                var result = await client.PostAsync(uri, content);
                string tokenResult = await result.Content.ReadAsStringAsync();

                var tokenObj = (JObject)JsonConvert.DeserializeObject(tokenResult);
                string token = tokenObj["access_token"].ToString();
                string refreshToken = tokenObj["refresh_token"].ToString();
                long expires = Convert.ToInt64(tokenObj["expires_in"]);

                this.Response.SetCookie(new HttpCookie("access_token", token));
                this.Response.SetCookie(new HttpCookie("refresh_token", refreshToken));
                this.Response.Cookies["access_token"].Expires = Clock.Now.AddSeconds(expires);

                return tokenResult;
            }
        }

        public async Task<string> GetOAuth2TokenByRefreshToken(string refreshToken)
        {
            Uri uri = new Uri("http://localhost:61759" + "/oauth/token");
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.None, UseCookies = true };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var content = new FormUrlEncodedContent(new Dictionary<string, string>()
                    {
                        {"grant_type", "refresh_token"},
                        {"refresh_token", refreshToken},
                        {"client_id", "app" },
                        {"client_secret", "app"},
                    });

                //获取token保存到cookie，并设置token的过期日期                    
                var result = await client.PostAsync(uri, content);

                string tokenResult = await result.Content.ReadAsStringAsync();

                var tokenObj = (JObject)JsonConvert.DeserializeObject(tokenResult);
                string token = tokenObj["access_token"].ToString();
                string newRefreshToken = tokenObj["refresh_token"].ToString();
                long expires = Convert.ToInt64(tokenObj["expires_in"]);

                this.Response.SetCookie(new HttpCookie("access_token", token));
                this.Response.SetCookie(new HttpCookie("refresh_token", newRefreshToken));
                this.Response.Cookies["access_token"].Expires = Clock.Now.AddSeconds(expires);

                return tokenResult;
            }
        }
        
    }
}