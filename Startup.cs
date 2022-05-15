// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.AspNetCore.HttpsPolicy;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Hosting;
// using Microsoft.Extensions.Logging;
// using Microsoft.OpenApi.Models;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace video
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();

            // 啟用預設檔案 (網址只打 hostname 時，自動導向至 index.html 那頁)
            // 要放 app.UseStaticFiles() 之前才有效果
            app.UseDefaultFiles();

            // 啟用用網頁前端靜態檔案
            // 用 dotnet watch run 時，若 launchSettings.json 的 launchBrowser 有設為 true 時，
            // 自動開啟的 launchUrl 網址若設為 index.html 就會自動幫你開首頁
            // 或是移除 launchUrl 也行 (有 launchUrl 屬性時，網址會多 /index.html)
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
