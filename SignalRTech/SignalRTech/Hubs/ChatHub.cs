using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRTech.Hubs
{
    public class ChatHub : Hub
    {
        /// <summary>
        /// Butun clients ozunde saxlayan list
        /// </summary>
        public static List<string> clients = new List<string>();

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
            clients.Add(ConnectionId);
            await Clients.All.SendAsync("clients", clients); // Clients list client-side da goruntulemey ucun
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
            clients.Remove(ConnectionId);
            await Clients.All.SendAsync("clients", clients); // Clients list client-side da goruntulemey ucun
            await Clients.All.SendAsync("userLeaved", ConnectionId);
        }
    }
}
