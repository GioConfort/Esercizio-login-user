using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Esercizio_login_user.Models.Services.Application;
using Esercizio_login_user.Models.Services.Infrastructures;

namespace Esercizio_login_user
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<IHomeService, AdoNetHomeService>();       
            services.AddTransient<ILoginService, AdoNetLoginService>();    
            services.AddTransient<IDatabaseAccessor, SqliteDatabaseAccessor>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles(); 
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Login}/{action=Index}/{id?}");
            }); 
        } 
    }
}
