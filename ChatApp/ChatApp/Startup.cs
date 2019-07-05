using AutoMapper;
using ChatApp.Core.Dto;
using ChatApp.Core.Extensions;
using ChatApp.DataAccess.Data;
using ChatApp.DataAccess.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ChatApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddChatAppDbContext(Configuration);
            services.AddRepositoryWrapper();
            services.AddCustomIdentityProvider();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 2;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = false;
            });

            services.AddAuthentication(o =>
            {
                o.DefaultScheme = IdentityConstants.ApplicationScheme;
                o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            }).AddIdentityCookies(o => { });

        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ChatAppDbContext db, SignInManager<UserDto> s)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                if (s.UserManager.FindByNameAsync("dev").Result == null)
                {
                    var result = s.UserManager.CreateAsync(new UserDto
                    {
                        FirstName = "devF",
                        LastName = "devL",
                        Email = "dev@app.com"
                    }, "Aut94L#G-a").Result;
                }

            }
            app.UseAuthentication();
        }
    }
}
