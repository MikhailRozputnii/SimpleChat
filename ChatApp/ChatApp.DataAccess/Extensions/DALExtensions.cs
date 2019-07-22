using ChatApp.DataAccess.Contracts;
using ChatApp.DataAccess.Data;
using ChatApp.DataAccess.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.DataAccess.Extensions
{
    public static class DALExtensions
    {
        public static void AddChatAppDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ChatAppDbContext>(options => options
             .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void AddRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
