using Autofac;
using Autofac.Extensions.DependencyInjection;
using TestProject.API.Extensions;
using TestProject.Data.DataContext;
using TestProject.Extensions;
using TestProject.Services;
using Microsoft.AspNetCore.HttpOverrides;
using Serilog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TestProject.API;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
        Serilog.Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
    }


    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        //Auto Schedule Jobs
        // services.AddBackgroundScheduleService(Configuration);

        // Add services to the container.
        services.AddControllers().AddJsonOptions(options=> {  options.JsonSerializerOptions.PropertyNamingPolicy = null;
            options.JsonSerializerOptions.DictionaryKeyPolicy = null;

        });
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
            .AddNewtonsoftJson(opt => {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        //Configure Extension
        services.ConfigureCors();
        services.ConfigureDI();
        services.AddSwaggerExtension();
        services.ConfigureSqlContext(Configuration);

        services.ConfigureAuthentication(Configuration);
        services.ConfigureAuthorization();
        services.ConfigureIdentity();
        services.ConfigureDefaultIdentity();
        services.AuthorizationPolicy();

        services.AddAutoMapper(typeof(Startup));

        // Register our services with Autofac container
        var builder = new ContainerBuilder();
        builder.RegisterModule(new AutoFacConfiguration());
        // builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
        builder.Populate(services);
        IContainer container = builder.Build();
        //
        // //Create the IServiceProvider based on the container.
        return new AutofacServiceProvider(container);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseStaticFiles();

        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.All
        });

        //call database migration
        // serviceProvider.GetRequiredService<AppDbContext>().Database.Migrate();
        //
        //call database migration
        // serviceProvider.GetRequiredService<AppDbContext>().Database.Migrate();

        // Enable middleware to serve generated Swagger as a JSON endpoint.
        app.UseSwagger();

        app.UseResponseCaching();

        app.UseCors("AllowAllOrigins");

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        });

        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}
