namespace SiriusCyberneticsCorp.Sales.Frontend.Models
{
    using NServiceBus;

    using SiriusCyberneticsCorp.InternalMessages.Sales;

    public class OrderSuccessfulHandler : IHandleMessages<OrderFulfilled>
    {
        public void Handle(OrderFulfilled message)
        {
            Database.Orders[message.OrderId].Status = OrderStatus.Successful;
        }
    }
}