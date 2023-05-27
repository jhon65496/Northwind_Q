namespace Northwind.Model
{
    public class OrderDetail : ModelBase
    {
        public const string ProductPropertyName = "Product";
        private Product _product;
        public Product Product
        {
            get => _product;
            set
            {
                if (_product == value)
                    return;

                _product = value;
                RaisePropertyChanged(ProductPropertyName);
            }
        }

        public const string QuantityPropertyName = "Quantity";
        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity == value)
                    return;

                _quantity = value;
                RaisePropertyChanged(QuantityPropertyName);
            }
        }

        public const string UnitPricePropertyName = "UnitPrice";
        private decimal _unitPrice;
        public decimal UnitPrice
        {
            get => _unitPrice;
            set
            {
                if (_unitPrice == value)
                    return;

                _unitPrice = value;
                RaisePropertyChanged(UnitPricePropertyName);
            }
        }



    }
}