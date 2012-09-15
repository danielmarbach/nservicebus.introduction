namespace SiriusCyberneticsCorp.Sales.Frontend.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Sirius Cybernetics Corporation Sales.";

            return View();
        }
    }
}