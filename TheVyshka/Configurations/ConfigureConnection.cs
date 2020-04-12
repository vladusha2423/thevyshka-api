﻿using TheVyshka.Core.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheVyshka.Configurations
{
    public static class ConfigureConnection
    {
        public static IServiceCollection AddConnectionProvider
            (this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<TheVyshkaContext>(opt =>
            opt.UseNpgsql(
                configuration.GetSection("ConnectionStrings")["DefaultConnection"],
                b => b.MigrationsAssembly("TheVyshka")));

            return services;
        }
    }

    
}
