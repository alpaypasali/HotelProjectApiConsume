using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http.Headers;

namespace HotelProject.WebUI.Controllers
{
    public class AdminImageFileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
                var stream = new MemoryStream();    //akış oluşturma
            await file.CopyToAsync(stream);         //Dosyayı kopyalama
            var bytes = stream.ToArray();           //akıştaki dosyayı byte olarak tutma

            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(byteArrayContent,"file",file.FileName);
            var httpclient = new HttpClient();
            var responseMessage = await httpclient.PostAsync("https://localhost:7051/api/FileImage", multipartFormDataContent);
            if(responseMessage.IsSuccessStatusCode) {

                return View();
            }

            return View();  
        }
    }
}
