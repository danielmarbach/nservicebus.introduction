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
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            this.Bus.Send<OrderFacility>(m => m.OrderId = Guid.NewGuid());

            return View();
        }
    }
}