using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Steeltoe.Common.Http.Discovery;
using Steeltoe.Discovery.Client;
using SteeltoeWithHttpClientFactory.Controllers;
using SteeltoeWithHttpClientFactory.Service;

namespace SteeltoeWithHttpClientFactory
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

            // Add Steeltoe Discovery Client service
            services.AddDiscoveryClient(Configuration);

            // Add Steeltoe handler to container
            services.AddTransient<DiscoveryHttpMessageHandler>();


            // 最终的请求地址应该等于 BaseAddress + GetStringAsync方法url 参数
            // Configure a HttpClient
            services.AddHttpClient("eurekakClient01", c =>
                {
                    c.BaseAddress = new Uri("http://EUREKAKCLIENT01");
                })
                .AddHttpMessageHandler<DiscoveryHttpMessageHandler>();


            // Configure a HttpClient
            services.AddHttpClient("eurekakClient01-inject",
                    c => { c.BaseAddress = new Uri("http://EUREKAKCLIENT01/getMember"); })
                .AddHttpMessageHandler<DiscoveryHttpMessageHandler>()
                .AddTypedClient<ITeamService,TeamService>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();


            // euraka
            app.UseDiscoveryClient();
        }
    }
}
