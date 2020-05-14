using System;
using System.Collections.Generic;
using System.Threading;

namespace DDD.EF.OptimisticConcurrency.DomainModel
{
    public class Order : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }

        private List<OrderLine> _orderLines;

        private DateTime? _modifyDate;

        private Order()
        {
            _orderLines = new List<OrderLine>();
        }

        public void AddOrderLine(string productCode)
        {
            if (_orderLines.Count >= 5)
            {
                throw new Exception("Order cannot have more than 5 order lines.");
            }

            _orderLines.Add(OrderLine.CreateNew(productCode));
            _modifyDate = DateTime.Now;
        }
    }
}