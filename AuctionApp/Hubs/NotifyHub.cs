using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace AuctionApp.Hubs
{
    public class NotifyHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}