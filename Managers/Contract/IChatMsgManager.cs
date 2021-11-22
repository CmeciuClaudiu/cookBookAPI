using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cookbookAPI.Managers.Contract
{
    public interface IChatMsgManager
    {
        List<Model.ChatMsg> GetMessages();

        void PostMessage(Model.ChatMsg message);
    }
}
