using TheVyshka.Auth.Interfaces;
using TheVyshka.Auth.Services;
using TheVyshka.Core.Repositories;
using TheVyshka.Data;
using TheVyshka.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheVyshka.Core.EF;

namespace TheVyshka.Configurations
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddIdentity(
            this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole<Guid>>(o =>
            {
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireLowercase = false;
            })
                .AddEntityFrameworkStores<TheVyshkaContext>();

            return services;
        }

        public static IServiceCollection AddRepositories(
            this IServiceCollection services)
        {
            services
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<IJwtGenerator, JwtGenerator>()
                .AddTransient<IAuthService, AuthService>()
                .AddTransient<IPostRepository, PostRepository>()
                .AddTransient<ITagRepository, TagRepository>()
                .AddTransient<ICategoryRepository, CategoryRepository>()
                .AddTransient<ICollaboratorRepository, CollaboratorRepository>();

            return services;
        }


    }
}
