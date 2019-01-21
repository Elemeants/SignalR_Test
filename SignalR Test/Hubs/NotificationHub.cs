using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_Test.Hubs
{
    public class NotificationHub : Hub
    {
        public void SendNotification(string message)
        {
            Clients.All.SendAsync("Notifications", message);
        }
    }
}
