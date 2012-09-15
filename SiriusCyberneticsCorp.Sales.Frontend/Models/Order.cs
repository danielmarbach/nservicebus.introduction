namespace SiriusCyberneticsCorp.Sales.Frontend.Models
{
    using System;

    public class Order
    {
        public Order()
        {
            this.OrderId = Guid.NewGuid();
            this.Status = OrderStatus.Processing;
        }

        public Guid OrderId { get; private set; }

        public Guid CategoryId { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime SubmittedAt { get; set; }
    }
}