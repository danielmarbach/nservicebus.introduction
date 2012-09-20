using System.Web.Mvc;

namespace SiriusCyberneticsCorp.Sales.Frontend.Controllers
{
    using System;

    using NServiceBus;

    using SiriusCyberneticsCorp.InternalMessages.Sales;
    using SiriusCyberneticsCorp.Sales.Frontend.Models;

    using System.Linq;

    using Order = SiriusCyberneticsCorp.Sales.Frontend.Models.Order;

    public class OrdersController : Controller
    {
        public IBus Bus { get; set; }

        //
        // GET: /Orders/

        public ActionResult Index()
        {
            return View(Database.Orders.Values.OrderByDescending(o => o.SubmittedAt));
        }


        public ActionResult Create()
        {
            var order = new Order { CategoryId = new Guid("{400FA2D8-2B33-4C2C-8369-1C75B736DF4A}") };

            return View(order);
        }

        [HttpPost]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                order.SubmittedAt = DateTime.UtcNow;

                Database.Orders.Add(order.OrderId, order);

                this.Bus.Send<OrderFacility>(m =>
                {
                    m.OrderId = order.OrderId;
                    m.CategoryId = order.CategoryId;
                });

                return RedirectToAction("Index");
            }

            return View(order);
        }

        public ActionResult Clear()
        {
            Database.Orders.Clear();

            return RedirectToAction("Index");
        }
    }
}
