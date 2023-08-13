    using HotelProject.BusinessLayer.Absract;
using HotelProject.EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookService;

        public BookingController(IBookingService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Booklist()
        {
            var values = _bookService.TGetlist();
            return Ok(values);

        }
        [HttpPost]
        public IActionResult AddBook(Booking book)
        {
            _bookService.TInsert(book);
            return Ok();


        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var valuses = _bookService.TGetByID(id);
            _bookService.TDelete(valuses);
            return Ok();
        }
        [HttpPut("UpdateBook")]
        public IActionResult UpdateBook(Booking book)
        {
            _bookService.TUpdate(book);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {

            var values = _bookService.TGetByID(id);
            return Ok(values);
        }

        [HttpPut("deneme")]
        public IActionResult deneme(Booking booking)
        {

            _bookService.TBookingStatusChangeApproved(booking);
            return Ok();
        }
        [HttpPut("deneme2")]
        public IActionResult deneme2(int id)
        {

            _bookService.TBookingStatusChangeApproved2(id);
            return Ok();
        }
        [HttpGet("Last6Booking")]
        public IActionResult Last6Booking()
        {
            var values = _bookService.TLast6Bookings();
            return Ok(values);
        }
        [HttpGet("BookingAproved")]
        public IActionResult BookingAproved(int id)
        {
            _bookService.TBookingStatusChangeApproved3(id);    
            return Ok();    
        }
        [HttpGet("BookingCancel")]
        public IActionResult BookingCancel(int id)
        {
            _bookService.TBookingStatusChangeCancel(id);
            return Ok();
        }
        [HttpGet("BookingWait")]
        public IActionResult BookingWait(int id)
        {
            _bookService.TBookingStatusChangeWait(id);
            return Ok();
        }
    }
}
