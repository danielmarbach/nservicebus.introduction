namespace SiriusCyberneticsCorp.Sales.Frontend.Models
{
    using NServiceBus;

    using SiriusCyberneticsCorp.InternalMessages.Sales;

    public class OrderFailedHandler : IHandleMessages<OrderFailed>
    {
        public void Handle(OrderFailed message)
        {
            Database.Orders[message.OrderId].Status = OrderStatus.Failed;
        }
    }
}