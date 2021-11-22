using cookbookAPI.Hubs.Model;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cookbookAPI.Hubs
{
    public class ChatHub : Hub
    {
        public Task SendMessage(string username, string message, DateTime dateTime)               
        {
            return Clients.All.SendAsync("ReceiveOne", username, message, dateTime);    
        }
    }
}
