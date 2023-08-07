using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata.Ecma335;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{

    public class _DashboardSubscribeCountPartial:ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); } 
    }
}
