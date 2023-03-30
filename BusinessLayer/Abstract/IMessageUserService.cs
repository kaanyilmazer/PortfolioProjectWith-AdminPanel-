using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageUserService : IGenericService<MessageUser>
    {
        List<MessageUser> GetListReceiverMessage(string p);
        List<MessageUser> GetListSenderMessage(string p);
    }
}
