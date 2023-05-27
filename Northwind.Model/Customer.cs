using System;
using System.Collections.ObjectModel;

namespace Northwind.Model
{
    public class Customer : ModelBase
    {
        private string _customerId;
        public string CustomerId
        {
            get => _customerId;
            set
            {
                if(string.CompareOrdinal(_customerId, value) == 0)
                    return;

                _customerId = value;
                RaisePropertyChanged(nameof(CustomerId));
            }
        }

        private string _companyName;
        public string CompanyName
        {
            get => _companyName;
            set
            {
                if (string.CompareOrdinal(_companyName, value) == 0)
                    return;

                _companyName = value;
                RaisePropertyChanged(nameof(CompanyName));
            }
        }

        private string _contactName;
        public string ContactName
        {
            get => _contactName;
            set
            {
                if (string.CompareOrdinal(_contactName, value) == 0)
                    return;

                _contactName = value;
                RaisePropertyChanged(nameof(ContactName));
            }
        }

        private string _address;
        public string Address
        {
            get => _address;
            set
            {
                if (string.CompareOrdinal(_address, value) == 0)
                    return;

                _address = value;
                RaisePropertyChanged(nameof(Address));
            }
        }

        private string _city;
        public string City
        {
            get => _city;
            set
            {
                if (string.CompareOrdinal(_city, value) == 0)
                    return;

                _city = value;
                RaisePropertyChanged(nameof(City));
            }
        }

        private string _region;
        public string Region
        {
            get => _region;
            set
            {
                if (string.CompareOrdinal(_region, value) == 0)
                    return;

                _region = value;
                RaisePropertyChanged(nameof(Region));
            }
        }

        private string _country;
        public string Country
        {
            get => _country;
            set
            {
                if (string.CompareOrdinal(_country, value) == 0)
                    return;

                _country = value;
                RaisePropertyChanged(nameof(Country));
            }
        }

        private string _phone;
        public string Phone
        {
            get => _phone;
            set
            {
                if (string.CompareOrdinal(_phone, value) == 0)
                    return;

                _phone = value;
                RaisePropertyChanged(nameof(Phone));
            }
        }

        private string _postalCode;
        public string PostalCode
        {
            get => _postalCode;
            set
            {
                if (string.CompareOrdinal(_postalCode, value) == 0)
                    return;

                _postalCode = value;
                RaisePropertyChanged(nameof(PostalCode));
            }
        }

        private ObservableCollection<Order> _orders;
        public ObservableCollection<Order> Orders
        {
            get => _orders;
            set
            {
                if (_orders == value)
                    return;

                _orders = value; 
                RaisePropertyChanged(nameof(Orders));
            }
        }

    }
}
