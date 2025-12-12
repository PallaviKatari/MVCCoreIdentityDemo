using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVCCoreIdentityDemo.Controllers
{
    ///Secure → redirects to /Identity/Account/Login
    [Authorize]
    public class SecureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
