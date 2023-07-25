
using HotelProject.BusinessLayer.Absract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;
        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void TDelete(Contact t)
        {
            _contactDal.Delete(t);
        }

        public Contact TGetByID(int id)
        {
           return _contactDal.GetByID(id);  
        }

        public int TGetContactCount()
        {
            return _contactDal.GetContactCount();
        }

        public List<Contact> TGetlist()
        {
           return _contactDal.Getlist();
        }

        public void TInsert(Contact t)
        {
            _contactDal.Insert(t);
        }

        public void TUpdate(Contact t)
        {
           _contactDal.Update(t);
        }
    }
}
