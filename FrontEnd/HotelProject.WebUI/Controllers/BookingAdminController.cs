using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7051/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> ApprovedReservation2(int id)
        {
           
            var client = _httpClientFactory.CreateClient();
      
         
            var responseMessage = await client.GetAsync($"https://localhost:7051/api/Booking/BookingAproved?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();

        }
        public async Task<IActionResult> CancelReservation(int id)
        {

            var client = _httpClientFactory.CreateClient();


            var responseMessage = await client.GetAsync($"https://localhost:7051/api/Booking/BookingCancel?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();

        }
        public async Task<IActionResult> WaitReservation(int id)
        {

            var client = _httpClientFactory.CreateClient();


            var responseMessage = await client.GetAsync($"https://localhost:7051/api/Booking/BookingWait?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7051/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
                return View(values);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7051/api/Booking/UpdateBook", content);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }

            return View();


        }


    }
}
