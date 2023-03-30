using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageUserManager : IMessageUserService
    {
        IMessageUserDal _messageUserDal;

        public MessageUserManager(IMessageUserDal messageUserDal)
        {
            _messageUserDal = messageUserDal;
        }

        public void TAdd(MessageUser t)
        {
            _messageUserDal.Insert(t);
        }

        public void TDelete(MessageUser t)
        {
            _messageUserDal.Delete(t);
        }

        public MessageUser TGetByID(int id)
        {
            return _messageUserDal.GetByID(id);
        }

        public List<MessageUser> TGetList()
        {
            throw new NotImplementedException();
        }
            
        public List<MessageUser> GetListReceiverMessage(string p)
        {
            return _messageUserDal.GetByFilter(x=>x.Receiver ==p);
        }

        public void TUpdate(MessageUser t)
        {
            throw new NotImplementedException();
        }

        public List<MessageUser> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public List<MessageUser> GetListSenderMessage(string p)
        {
            return _messageUserDal.GetByFilter(x => x.Sender == p);
        }
    }
}
