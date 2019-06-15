using ChatApp.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.DataAccess.Extensions
{
    public static class ChatAppDbExtensions
    {
        public static void AddChatAppDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ChatAppDbContext>(options => options
             .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
