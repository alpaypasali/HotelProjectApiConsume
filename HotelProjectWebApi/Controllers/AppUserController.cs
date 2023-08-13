using HotelProject.BusinessLayer.Absract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet]
        public IActionResult UserListWithWorkLocation()
        {
            var values = _appUserService.TUserListWithWorkLocation();
            return Ok(values);

        } 
    }
}
