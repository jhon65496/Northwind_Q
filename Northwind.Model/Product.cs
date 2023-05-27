namespace Northwind.Model
{
    public class Product : ModelBase
    {
        public const string ProductIdPropertyName = "ProductId";
        private int _productId;
        public int ProductId
        {
            get => _productId;
            set
            {
                if (_productId == value)
                    return;

                _productId = value; 
                RaisePropertyChanged(ProductIdPropertyName);
            }
        }

        public const string ProductNamePropertyName = "ProductName";
        private string _productName;
        public string ProductName
        {
            get => _productName;
            set
            {
                if (_productName == value)
                    return;

                _productName = value; 
                RaisePropertyChanged(ProductNamePropertyName);
            }
        }
    }
}
