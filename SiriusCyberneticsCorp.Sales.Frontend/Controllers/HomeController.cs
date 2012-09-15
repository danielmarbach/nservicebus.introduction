namespace SiriusCyberneticsCorp.Sales.Frontend.Controllers
{
    using System;
    using System.Web.Mvc;

    using NServiceBus;

    using SiriusCyberneticsCorp.InternalMessages.Sales;

    public class HomeController : Controller
    {
        public IBus Bus { get; set; }

        public ActionResult Index()
        {
            ViewBag.Message = "Sirius Cybernetics Corporation Sales.";

            this.Bus.Send<OrderFacility>(m =>
                {
                    m.OrderId = Guid.NewGuid();
                    m.CategoryId = new Guid("{400FA2D8-2B33-4C2C-8369-1C75B736DF4A}");
                });

            return View();
        }
    }
}