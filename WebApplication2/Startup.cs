using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2
{
    public class Startup
    {
        public class Company
        {
            public string Name { get; set; }
            public string Address { get; set; }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var company = new Company
                    {
                        Name = "CompZachinyev",
                        Address = "Prosvekt 401",
                    };

                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync($"Company Name: {company.Name}, Address: {company.Address}");
                });

                endpoints.MapGet("/random", async context =>
                {
                    var random = new Random();
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync($"Random number: {random.Next(0, 101)}");
                });
            });
        }
    }
}
