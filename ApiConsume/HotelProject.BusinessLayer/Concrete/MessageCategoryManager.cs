using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class MessageCategoryManager : IMessageCategoryService
    {
        private readonly IMessageCategoryDal _messagerCategoryDal;

        public MessageCategoryManager(IMessageCategoryDal messagerCategoryDal)
        {
            _messagerCategoryDal = messagerCategoryDal;
        }

        public void TDelete(MessageCategory t)
        {
            throw new NotImplementedException();
        }

        public MessageCategory TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<MessageCategory> TGetList()
        {
            return _messagerCategoryDal.GetList();
        }

        public void TInsert(MessageCategory t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(MessageCategory t)
        {
            throw new NotImplementedException();
        }
    }
}
