using System.Text;
using Hotel_Reservation.Core.Repositories;
using Hotel_Reservation.Core.Repositories.Repositrory;
using Hotel_Reservation.Persistence.Data;
using Hotel_Reservation.Persistence.Repositrory;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Hotel_Reservation.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection serviceDescriptors(this IServiceCollection services , IConfiguration config)
        {
            services.AddSqlServer<ApplicationDbContext>(config.GetConnectionString("DefaultConnection"));
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IGuestRepository, GuestReposititory>();
            services.AddTransient<IReservationRepository, ReservationRepository>();


            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            });

            string Issuer = config.GetValue<string>("JWT:Issuer");
            string Audience = config.GetValue<string>("JWT:Audience");
            string Key = config.GetValue<string>("JWT:Key");

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Bearer";
                options.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = Issuer,
                    ValidateAudience = true,
                    ValidAudience = Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key))
                };
                

            });
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("Customers", policy =>
                policy.RequireClaim("Rooms", ["Customer","Admin"]));
            });
                

            return services;
        }
    }
}
