using HotelProject.WebUI.Dtos.GuestDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace HotelProject.WebUI.ViewComponents.Dashboard
{
  
    public class _DashboardWidgetPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync() {

                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:7051/api/DashBoardWidgets/StaffCount");
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //var values = JsonConvert.DeserializeObject<List<ResultGuestDto>>(jsonData);
                ViewBag.v = jsonData;

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:7051/api/DashBoardWidgets/BookingCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            //var values = JsonConvert.DeserializeObject<List<ResultGuestDto>>(jsonData);
            ViewBag.b = jsonData2;

            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:7051/api/DashBoardWidgets/GuestCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            //var values = JsonConvert.DeserializeObject<List<ResultGuestDto>>(jsonData);
            ViewBag.g = jsonData3;

            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:7051/api/DashBoardWidgets/RoomCount");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            //var values = JsonConvert.DeserializeObject<List<ResultGuestDto>>(jsonData);
            ViewBag.r = jsonData4;


            return View();
           
        } 
    }
}
