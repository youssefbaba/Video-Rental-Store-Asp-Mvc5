using System.Web.Mvc;

namespace VideoRentalStore.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        //[OutputCache(Duration = 50, Location = OutputCacheLocation.Server, VaryByParam = "*")]  // To Enable caching
        //[OutputCache(Duration = 0, VaryByParam = "*", NoStore = true)]  // To unable caching
        public ActionResult Index()
        {
            return View();
        }
    }
}