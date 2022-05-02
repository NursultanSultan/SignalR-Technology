using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRTech.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessageAsync(string message)
        {
            await Clients.All.SendAsync("receiveMessage", message);
        }
 
        /// <summary>
        /// Sisteme (Hub- a)  bir client daxil olduqda bu method tetiklenir
        /// </summary>
        /// <returns></returns>
        public override async Task OnConnectedAsync()
        {
            var ConnectionId = Context.ConnectionId;
            await Clients.All.SendAsync("userJoined", ConnectionId);
        }

        /// <summary>
        /// Sistemden (Hub- dan) bir client baqlantisini qopardiqda bu method tetiklenir
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var ConnectionId = Context.ConnectionId;
            await Clients.All.SendAsync("userLeaved", ConnectionId);
        }
    }
}
