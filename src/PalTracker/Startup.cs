
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace PalTracker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            System.Diagnostics.Debug.WriteLine("##### Startup.Startup() " + configuration.ToString());
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. 
        // Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            System.Diagnostics.Debug.WriteLine("##### Startup.ConfigureServices() " + services.ToString());
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSingleton( new WelcomeMessage( Configuration.GetValue("WELCOME_MESSAGE","WELCOME_MESSAGE not set ...")));
            
            services.AddSingleton( new CloudFoundryInfo( Configuration.GetValue("PORT","PORT not set ...") ,
                                                         Configuration.GetValue("MEMORY_LIMIT","MEMORY_LIMIT not set ...") ,
                                                         Configuration.GetValue("CF_INSTANCE_INDEX","CF_INSTANCE_INDEX not set ...") ,
                                                         Configuration.GetValue("CF_INSTANCE_ADDR","CF_INSTANCE_ADDR not set ...")   
                                                         ) 
                                );

            services.AddSingleton<ITimeEntryRepository, InMemoryTimeEntryRepository>();


        }

        // This method gets called by the runtime. 
        //Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
             System.Diagnostics.Debug.WriteLine("##### Startup.Configure() - 0");
            if (env.IsDevelopment())
            {
                System.Diagnostics.Debug.WriteLine("##### Startup.Configure() - 1");
                app.UseDeveloperExceptionPage(); // Captures synchronous and asynchronous Exception instances 
                                                 // from the pipeline and generates HTML error responses.
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("##### Startup.Configure() - 2");
                // The default HSTS value is 30 days. 
                // You may want to change this for production scenarios, 
                // see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}


// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.AspNetCore.HttpsPolicy;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Logging;
// using Microsoft.Extensions.Options;

// namespace PalTracker
// {
//     public class Startup
//     {
//         public Startup(IConfiguration configuration)
//         {
//             Configuration = configuration;
//         }

//         public IConfiguration Configuration { get; }

//         // This method gets called by the runtime. Use this method to add services to the container.
//         public void ConfigureServices(IServiceCollection services)
//         {
//             services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

//             services.AddSingleton(sp => new WelcomeMessage(
//                 Configuration.GetValue<string>("WELCOME_MESSAGE", "WELCOME_MESSAGE not configured.")
//             ));

//             services.AddSingleton(sp => new CloudFoundryInfo(
//                 Configuration.GetValue<string>("PORT"),
//                 Configuration.GetValue<string>("MEMORY_LIMIT"),
//                 Configuration.GetValue<string>("CF_INSTANCE_INDEX"),
//                 Configuration.GetValue<string>("CF_INSTANCE_ADDR")
//             ));

//             services.AddSingleton<ITimeEntryRepository, InMemoryTimeEntryRepository>();
//         }

//         // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//         public void Configure(IApplicationBuilder app, IHostingEnvironment env)
//         {
//             if (env.IsDevelopment())
//             {
//                 app.UseDeveloperExceptionPage();
//             }
//             else
//             {
//                 app.UseHsts();
//             }

//             app.UseHttpsRedirection();
//             app.UseMvc();
//         }
//     }
// }

