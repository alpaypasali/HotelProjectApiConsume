using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntitiyLayer.Concrete;
using System.Linq;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
       

        public EfBookingDal(Context context) : base(context)
        {
           
        }

        public void BookingStatusChangeApproved(Booking booking)
        {
            var _context=new Context(); 
            var values = _context.Bookings.FirstOrDefault(x => x.BookingID == booking.BookingID);
            
                values.Status = "Onaylandı";
                _context.SaveChanges();
           
        }

        public void BookingStatusChangeApproved2(int id)
        {
            var _context = new Context();
            var values = _context.Bookings.Find(id);
           
                values.Status = "Onaylandı";
                _context.SaveChanges();
           
        }
    }
}
