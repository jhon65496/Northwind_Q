using System;
using System.Collections.Generic;

namespace Northwind.Model
{
    public class Order : ModelBase
    {
        public const string OrderIdPropertyName = "OrderId";
        private int _orderId;
        public int OrderId
        {
            get => _orderId;
            set
            {
                if (_orderId == value)
                    return;

                _orderId = value;
                RaisePropertyChanged(OrderIdPropertyName);
            }
        }

        public const string OrderDatePropertyName = "OrderDate";
        private DateTime? _orderDate;
        public DateTime? OrderDate
        {
            get => _orderDate;
            set
            {
                if (_orderDate == value)
                    return;

                _orderDate = value;
                RaisePropertyChanged(OrderDatePropertyName);
            }
        }

        public const string ShippedDatePropertyName = "ShippedDate";
        private DateTime? _shippedDate;
        public DateTime? ShippedDate
        {
            get => _shippedDate;
            set
            {
                if (_shippedDate == value)
                    return;

                _shippedDate = value;
                RaisePropertyChanged(ShippedDatePropertyName);
            }
        }

        public const string FreightPropertyName = "Freight";
        private decimal? _freight;
        public decimal? Freight
        {
            get => _freight;
            set
            {
                if (_freight == value)
                    return;

                _freight = value;
                RaisePropertyChanged(FreightPropertyName);
            }
        }

        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}