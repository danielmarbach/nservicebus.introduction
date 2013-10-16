namespace SiriusCyberneticsCorp.Sales.Frontend.Models
{
    using NServiceBus;

    using SiriusCyberneticsCorp.InternalMessages.Sales;

    public class OrderDelayedHandler : IHandleMessages<OrderDelayed>
    {
        public void Handle(OrderDelayed message)
        {
            Database.Orders[message.OrderId].Status = OrderStatus.Delayed;
        }
    }
}