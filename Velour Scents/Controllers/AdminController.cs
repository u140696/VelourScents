using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Velour_Scents.Controllers
{
    [Authorize(Roles = "Administrator")] // ✅ Only Admin Can Access
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult ManageUsers()
        {
            return View();
        }
    }
}
