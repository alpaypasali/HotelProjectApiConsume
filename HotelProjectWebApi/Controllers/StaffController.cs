using HotelProject.BusinessLayer.Absract;
using HotelProject.EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public IActionResult Stafflist()
        {
            var values = _staffService.TGetlist();
            return Ok(values);

        }
        [HttpPost]
        public IActionResult AddStaff(Staff staff)
        {
            _staffService.TInsert(staff);
            return Ok();


        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStaff(int id)
        {
            var valuses = _staffService.TGetByID(id);
            _staffService.TDelete(valuses);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateStaff(Staff staff)
        {
            _staffService.TUpdate(staff); 
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetStaff(int id)
        {

            var values = _staffService.TGetByID(id);
            return Ok(values);
        }
        [HttpGet("Last4Staff")]
        public IActionResult Last4Staff()
        {
            var values = _staffService.TLast4Staff();
            return Ok(values);
        }
    }
}
