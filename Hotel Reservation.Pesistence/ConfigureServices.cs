using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Reservation.Core.Entities;
using Hotel_Reservation.Core.Repositories;
using Hotel_Reservation.Core.Repositories.Repositrory;
using Hotel_Reservation.Persistence.Data;
using Hotel_Reservation.Persistence.Repositrory;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            
            return services;
        }
    }
}
