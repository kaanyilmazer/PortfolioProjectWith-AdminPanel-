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
    public class WriterUserManager:IWriterUserService
    {
        IWriterUserDal _writeruserDal;

        public WriterUserManager(IWriterUserDal writeruserDal)
        {
            _writeruserDal = writeruserDal;
        }

        public void TAdd(AspUser t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(AspUser t)
        {
            throw new NotImplementedException();
        }

        public AspUser TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<AspUser> TGetList()
        {
            return _writeruserDal.GetList();
        }

        public List<AspUser> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(AspUser t)
        {
            throw new NotImplementedException();
        }
    }
}
