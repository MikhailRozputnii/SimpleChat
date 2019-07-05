using ChatApp.Core.Dto;
using ChatApp.Core.Services.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.Core.Extensions
{
    public static class ServicesConfig
    {
        public static void AddCustomIdentityProvider(this IServiceCollection services)
        {
            //services.AddIdentity<UserDto, UserRoleDto>()
            //        .AddDefaultTokenProviders();
            services.AddIdentityCore<UserDto>()
               .AddSignInManager()
               .AddDefaultTokenProviders();
            services.AddTransient<IUserStore<UserDto>, UserStore>();
            //services.AddTransient<IRoleStore<UserRoleDto>, RoleStore>();
        }
    }
}
