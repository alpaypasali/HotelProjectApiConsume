using HotelProject.BusinessLayer.Absract;
using HotelProject.EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult Aboutlist()
        {
            var values = _aboutService.TGetlist();
            return Ok(values);

        }
        [HttpPost]
        public IActionResult AddAbout(About about)
        {
            _aboutService.TInsert(about);
            return Ok();


        }
        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var valuses = _aboutService.TGetByID(id);
            _aboutService.TDelete(valuses);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateAbout(About about)
        {
            _aboutService.TUpdate(about);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {

            var values = _aboutService.TGetByID(id);
            return Ok(values);
        }
    }
}
