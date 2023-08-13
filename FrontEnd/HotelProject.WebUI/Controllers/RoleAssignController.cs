using HotelProject.EntitiyLayer.Concrete;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class RoleAssignController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager; 

        public RoleAssignController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager; 
        }

        public IActionResult Index()
        {
            var values=_userManager.Users.ToList(); 
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> AssingRole(int id)
        {
            var user=_userManager.Users.FirstOrDefault(x => x.Id == id);    
            if (user == null)
            {
                return View("error");
            }
            TempData["userid"]=user.Id; 
            var roles=_roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();   
            foreach (var role in roles) { 
            
            
                RoleAssignViewModel roleAssignViewModel = new RoleAssignViewModel();
                roleAssignViewModel.RoleID= role.Id;    
                roleAssignViewModel.RoleName= role.Name;    
                roleAssignViewModel.RoleExist=userRoles.Contains(role.Name);
                roleAssignViewModels.Add(roleAssignViewModel);  
            }
            return View(roleAssignViewModels);


        }

        [HttpPost]
        public async Task<IActionResult> AssingRole(List<RoleAssignViewModel> roleAssignViewModel)
        {

            var userId = (int)TempData["userId"]; 
            var user = _userManager.Users.FirstOrDefault(x=>x.Id==userId);
            foreach(var item in  roleAssignViewModel) {

                if (item.RoleExist)
                {

                    await _userManager.AddToRoleAsync(user, item.RoleName); 
                }
                else
                {

                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            
            }
            return RedirectToAction("Index");


        }
    }
}
