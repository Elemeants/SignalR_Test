using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR_Test.Hubs;
using SignalR_Test.Models;

namespace SignalR_Test.Controllers
{
    [Route("api/Notifications")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> hubContext;

        public NotificationsController(IHubContext<NotificationHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        [HttpPut("SendNotification")]
        public IActionResult SendNotification([FromBody] EventNotification eventNotification)
        {
            this.hubContext.Clients.All.SendAsync("Notifications", eventNotification);
            return Ok();
        }
    }
}