using cookbookAPI.Managers.Contract;
using cookbookAPI.Managers.Contract.Model;
using cookbookAPI.Resources.Contract;
using System;
using cookbookAPI.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cookbookAPI.Managers
{
    public class ChatMsgManager : IChatMsgManager
    {
        private IUserResource usersResource;
        public ChatMsgManager(IUserResource _usersResource)
        {
            usersResource = _usersResource;
        }

        public List<ChatMsg> GetMessages()
        {
            DateTime time = DateTime.Now.ToUniversalTime();
            time=time.AddDays(-2);

            return MapObject.MapObjList<Resources.Contract.Model.ChatMsg,ChatMsg>(usersResource.GetChatMsgHistory(time));
        }

        public void PostMessage(ChatMsg message)
        {
            message.Id = Guid.NewGuid().ToString();
            message.DateTime = message.DateTime.ToUniversalTime();

            usersResource.PostUserChatMessage(MapObject.MapObj<ChatMsg, Resources.Contract.Model.ChatMsg>(message));
        }
    }
}
