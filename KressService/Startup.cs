﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(KressService.Startup))]

namespace KressService
{
    public class Startup
    {
        public static mongodb db;
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
             db = new mongodb();
            //    db.AddFG14ProzessdataAsync(new FG14Connect.FG14v3.Prozessdaten(), "Test").Wait();
            
            app.MapSignalR();
            

        }
    }
}
