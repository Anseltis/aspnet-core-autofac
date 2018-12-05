using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using ConsoleApp1.Math;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ConsoleApp1
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var builder = new ContainerBuilder();

            builder.RegisterType<CallLogger>();
            builder.RegisterType<CalculatorFactory>().As<ICalculatorFactory>();

            builder.RegisterType<Calculator>().As<ICalculator>()
                .EnableInterfaceInterceptors().InterceptedBy(typeof(CallLogger));
            
            builder.Populate(services);

            var appContainer = builder.Build();
            return new AutofacServiceProvider(appContainer);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app
                .UseStaticFiles()
                .UseMvcWithDefaultRoute();
        }
    }
}