using Microsoft.AspNetCore.SignalR;
using SignalRTech.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRTech.Business
{
    public class MyBusiness
    {
        readonly IHubContext<ChatHub> _hubContext;

        public MyBusiness(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageAsync(string message)
        {
            await _hubContext.Clients.All.SendAsync("receiveMessage", message);
        }
    }
}
