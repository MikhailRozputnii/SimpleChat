using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ChatApp.HubConfig
{
    public class ChatHub : Hub
    {
        public async Task Send(string message)
        {
            await Clients.All.SendAsync("Send", message);
        }
    }
}
