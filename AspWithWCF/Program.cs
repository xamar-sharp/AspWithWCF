using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using Microsoft.AspNetCore;
using Microsoft.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AspWithWCF.Services;
namespace AspWithWCF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddServiceModelServices();
            builder.Services.AddServiceModelMetadata();
            builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>(); 
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            app.UseServiceModel(serviceBuilder =>
            {
                serviceBuilder.AddService<EnvironmentOSStatePresentor>();
                serviceBuilder.AddServiceEndpoint<EnvironmentOSStatePresentor, IOSStatePresentor>(new BasicHttpBinding(),
                    "/EnvironmentOSStatePresentor/basichttp");
                var serviceMetadataFactory = app.Services.GetRequiredService<ServiceMetadataBehavior>();
                serviceMetadataFactory.HttpGetEnabled = true;
            });
            app.Run();
        }
    }
}
