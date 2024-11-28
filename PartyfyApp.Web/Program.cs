using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using PartyfyApp.Data;
using PartyfyApp.Data.Models;
using PartyfyApp.Web.ViewModels;
using PartyfyApp.Web.Infrastructure.Extensions;
using PartyfyApp.Services.Data.Interfaces;
using PartyfyApp.Services.Mapping;

using static PartyfyApp.Common.GeneralApplicationConstants;

internal class Program
{
    private static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        builder.Services.AddDbContext<PartyfyAppDbContext>(options =>
            options.UseSqlServer(connectionString));

        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
        {
            options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
            options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
            options.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
            options.Password.RequireLowercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
            options.Password.RequiredLength = builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
        })
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<PartyfyAppDbContext>();

        builder.Services.AddApplicationServices(typeof(IEventService));

        builder.Services.ConfigureApplicationCookie(cfg =>
        {
            cfg.LoginPath = "/User/Login";
        });

        builder.Services.AddControllersWithViews();

        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            options.Cookie.SameSite = SameSiteMode.Strict;
        });

        WebApplication app = builder.Build();

        AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);


        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error/500");

            app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");

            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseResponseCaching();

        app.UseCookiePolicy();
        app.UseAuthentication();
        app.UseAuthorization();

        if (app.Environment.IsDevelopment())
        {
            app.SeedAdministrator(DevelopmentAdminEmail);

        }

        app.UseEndpoints(config =>
        {
            config.MapControllerRoute(
                name: "areas",
                pattern: "/{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );

            //config.MapControllerRoute(
            //    name: "ProtectingUrlRoute",
            //    pattern: "/{controller}/{action}/{id}/{information}",
            //    defaults: new { Controller = "Category", Action = "Details" });

            config.MapDefaultControllerRoute();

            config.MapRazorPages();
        });

        app.Run();
    }
}