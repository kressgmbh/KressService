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
        public void SendFG14Systemdaten(string sender, FG14Connect.FG14v3.Systemdaten sDaten)
        {
            // Call the broadcastMessage method to update clients.
            Startup.db.AddFG14SystemdatenAsync(sDaten, sender).Wait();
            Clients.All.broadcastFG14Systemdaten(sender, sDaten);
        }
        public void SendFG14Prozessdaten(string sender, FG14Connect.FG14v3.Prozessdaten pData)
        {
            // Call the broadcastMessage method to update clients.
            Startup.db.AddFG14ProzessdataAsync(pData, sender).Wait();
            Clients.All.broadcastFG14Prozessdaten(sender,pData);
        }
    }
}