namespace SiriusCyberneticsCorp.Sales.Frontend.Models
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    public static class Database
    {
        private static readonly ConcurrentDictionary<Guid, Order> orders = new ConcurrentDictionary<Guid, Order>(); 

        public static IDictionary<Guid, Order> Orders
        {
            get
            {
                return orders;
            }
        }
    }
}