using ITIMVCD1.Data;
using ITIMVCD1.IRepository;
using ITIMVCD1.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace ITIMVCD1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<ICourseRepository, CouresRepository>();
            builder.Services.AddScoped<IStudentRepository , StudentRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            builder.Services.AddDbContext<ITIContext>(
                a => a.UseSqlServer(builder.Configuration.GetConnectionString("cons"))
                );

            builder.Services.AddLocalization(o => o.ResourcesPath = "Resources");

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddViewLocalization().AddDataAnnotationsLocalization();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
                AddCookie(options => {
                    options.LoginPath = "/Account/Login";
                    options.Cookie.Expiration = TimeSpan.FromDays(7); ;
                    options.SlidingExpiration = true;
                });

            var app = builder.Build();

            //app.Use(async (c,n) => {
            //    //c.Response.ContentType = "text/html";
            //    await c.Response.WriteAsync("welcome from first middleware");
            //    await n.Invoke();
            //    });

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            var supportedCultures = new[] { "en-US", "ar-SA" };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures.Select(c => new System.Globalization.CultureInfo(c)).ToList(),
                SupportedUICultures = supportedCultures.Select(c => new System.Globalization.CultureInfo(c)).ToList()
            });

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures.Select(c => new CultureInfo(c)).ToList(),
                SupportedUICultures = supportedCultures.Select(c => new CultureInfo(c)).ToList(),
                RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new CookieRequestCultureProvider()
                }
            });

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
