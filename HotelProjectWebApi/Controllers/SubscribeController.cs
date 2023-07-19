using HotelProject.BusinessLayer.Absract;
using HotelProject.EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpGet]
        public IActionResult Subscribelist()
        {
            var values = _subscribeService.TGetlist();
            return Ok(values);

        }
        [HttpPost]
        public IActionResult AddSubscribe(Subscribe subscribe)
        {
            _subscribeService.TInsert(subscribe);
            return Ok();


        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSubscribe(int id)
        {
            var valuses = _subscribeService.TGetByID(id);
            _subscribeService.TDelete(valuses);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateSubscribe(Subscribe subscribe)
        {
            _subscribeService.TUpdate(subscribe);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetSubscribe(int id)
        {

            var values = _subscribeService.TGetByID(id);
            return Ok(values);
        }
    }
}
