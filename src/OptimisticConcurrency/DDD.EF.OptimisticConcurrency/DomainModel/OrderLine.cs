using System;

namespace DDD.EF.OptimisticConcurrency.DomainModel
{
    public class OrderLine : Entity
    {
        internal Guid Id;

        private string _productCode;

        private OrderLine()
        {
            
        }

        private OrderLine(string productCode)
        {
            this.Id = Guid.NewGuid();

            _productCode = productCode;
        }

        internal static OrderLine CreateNew(string productCode)
        {
            return new OrderLine(productCode);
        }
    }
}