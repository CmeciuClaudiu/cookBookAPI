using cookbookAPI.Hubs;
using cookbookAPI.Hubs.Model;
using cookbookAPI.Managers.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cookbookAPI.Utilities;

namespace cookbookAPI.Controllers
{
    [Route("api/chat")]
    [ApiController]
    public class ChatController : ControllerBase
    {
   
        private readonly IHubContext<ChatHub> hubContext;
        private readonly IChatMsgManager chatMsgManager;

        public ChatController(IHubContext<ChatHub> _hubContext, IChatMsgManager _chatMsgManager)
        {
            hubContext = _hubContext;
            chatMsgManager = _chatMsgManager;
        }

        [Route("send")]                                           
        [HttpPost]
        public IActionResult SendRequest([FromBody] MessageDto msg)
        {
            hubContext.Clients.All.SendAsync("ReceiveOne", msg.Username, msg.Message, msg.DateTime);
            chatMsgManager.PostMessage(MapObject.MapObj<MessageDto,Managers.Contract.Model.ChatMsg>(msg));

            return Ok();
        }

        [Route("getMessagesHistory")]
        [HttpGet]

        public List<Managers.Contract.Model.ChatMsg> GetMsgHistory()
        {
            return chatMsgManager.GetMessages();
        }
        
    }
}


