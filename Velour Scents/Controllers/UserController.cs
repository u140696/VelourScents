using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Velour_Scents.Controllers
{
    [Authorize(Roles = "User")] // ✅ Only Normal Users Can Access
    public class UserController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }
    }
}
