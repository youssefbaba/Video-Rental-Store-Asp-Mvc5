using System.Web.Mvc;

namespace VideoRentalStore.Controllers
{
    public class RentalsController : Controller
    {
        // GET: /rentals/new
        [HttpGet]
        public ActionResult New()
        {
            return View();
        }
    }
}