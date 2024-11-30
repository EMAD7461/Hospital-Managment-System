using Hospital_Managment_System.MiddleWares;
using Hospital_Managment_System.Models;
using Hospital_Managment_System.Repositry.Implemntation;
using Hospital_Managment_System.Repositry.Interfaces;
using Hospital_Managment_System.Service.Implementation;
using Hospital_Managment_System.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Managment_System
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure the database connection
            builder.Services.AddDbContext<HospitalDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("HospitalDB")));

            // Configure Identity services
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<HospitalDBContext>()
                .AddDefaultTokenProviders();

            // Configure Authentication
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.AccessDeniedPath = "/Account/AccessDenied";
                });

            // Add services to the container
            builder.Services.AddControllersWithViews();

            // Register services for Dependency Injection
            builder.Services.AddScoped<IDoctorRepositry, DoctorRepositry>();
            builder.Services.AddScoped<IDoctorService, DoctorService>();
            builder.Services.AddScoped<IPatientRepositry, PatientRepositry>();
            builder.Services.AddScoped<IPatientService, PatientService>();
            builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            builder.Services.AddScoped<IAppointmentService, AppointmentService>();
            //builder.Services.AddScoped<INotificationService, NotificationService>();
            builder.Services.AddScoped<INotificationService, MockNotificationService>();
            builder.Services.AddScoped<INurseRepository, NurseRepository>();
            builder.Services.AddScoped<INurseService, NurseService>();

            // Configure Authorization
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
                options.AddPolicy("AdminOrDoctorPolicy", policy => policy.RequireRole("Admin", "Doctor"));
                options.AddPolicy("PatientPolicy", policy => policy.RequireRole("Patient"));
            });

            var app = builder.Build();

            // Call CreateRoles method after the app is built
            await CreateRoles(app.Services);

            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Adding Middleware
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Custom Middleware
            app.UseMiddleware<LoggingMiddleware>();
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseRouting();

            // Authentication and Authorization
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        private static async Task CreateRoles(IServiceProvider serviceProvider)
        {
            // Create a new scope to resolve scoped services
            using (var scope = serviceProvider.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                string[] roleNames = { "Admin", "Doctor", "Patient" };

                foreach (var roleName in roleNames)
                {
                    if (!await roleManager.RoleExistsAsync(roleName))
                    {
                        await roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }
            }
        }
    }
}
