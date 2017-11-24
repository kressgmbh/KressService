using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace KressService
{
    public class MyFgHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
        public void Send( string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage( message);
        }
    }
}