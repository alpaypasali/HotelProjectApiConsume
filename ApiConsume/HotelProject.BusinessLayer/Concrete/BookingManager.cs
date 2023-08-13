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
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public void TBookingStatusChangeCancel(int id)
        {
            _bookingDal.BookingStatusChangeCancel(id);
        }

        public void TBookingStatusChangeApproved(Booking booking)
        {
           _bookingDal.BookingStatusChangeApproved(booking);

        }

        public void TBookingStatusChangeApproved2(int id)
        {
            _bookingDal.BookingStatusChangeApproved2(id);
        }
        public void TBookingStatusChangeApproved3(int id)
        {
            _bookingDal.BookingStatusChangeApproved3(id);
        }

        public void TDelete(Booking t)
        {
            _bookingDal.Delete(t);  
        }

        public int TGetBookingCount()
        {
            return _bookingDal.GetBookingCount();
        }

        public Booking TGetByID(int id)
        {
           return _bookingDal.GetByID(id);  
        }

        public List<Booking> TGetlist()
        {
            return _bookingDal.Getlist();
        }

        public void TInsert(Booking t)
        {
            _bookingDal.Insert(t);
        }

        public List<Booking> TLast6Bookings()
        {
            return _bookingDal.Last6Bookings();
        }

        public void TUpdate(Booking t)
        {
            _bookingDal.Update(t);
        }

        public void TBookingStatusChangeWait(int id)
        {
          _bookingDal.BookingStatusChangeWait(id); 
        }
    }
}
