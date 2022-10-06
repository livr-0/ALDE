using MemberManagementSystem.Commands;
using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using System;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace MemberManagementSystem.ViewModel
{
    internal class AddProductViewModel : ViewModelBase
    {
        Book<Product> _productBook;

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(nameof(Description)); }
        }

        private string _price;

        public string Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged(nameof(Price)); }
        }

        private string _quantity;

        public string Quantity
        {
            get { return _quantity; }
            set { _quantity = value; OnPropertyChanged(nameof(Quantity)); }
        }

        private string _priceColor = "Gray";
        public string PriceColor
        {
            get { return _priceColor; }
            set { _priceColor = value; OnPropertyChanged(nameof(PriceColor)); }
        }

        private Regex _priceRegex = new Regex("[0-9]*(.[0-9]{0,2})$");

        private string _quantityColor = "Gray";
        public string QuantityColor
        {
            get { return _quantityColor; }
            set { _quantityColor = value; OnPropertyChanged(nameof(QuantityColor)); }
        }

        private Regex _quantityRegex = new Regex("[0-9]*");

        public AddProductViewModel(NavigateService navService, Book<Product> productBook)
        {
            _productBook = productBook;
            HomePage = new NavigateCommand(navService, nameof(HomeViewModel));
            SubmitProduct = new AddRecordCommand<Product>(productBook, CreateProduct);
        }



        public ICommand HomePage { get; }
        public ICommand SubmitProduct { get; }

        private Product CreateProduct()
        {
            bool inputCorrect = true;

            if (_price == null || _priceRegex.IsMatch(_price) == false)
            {
                inputCorrect = false;
                PriceColor = "Red";
            }

            if (_quantity == null || _quantityRegex.IsMatch(_quantity) == false)
            {
                inputCorrect = false;
                QuantityColor = "Red";
            }
            
            if (inputCorrect)
            {
                float price = float.Parse(Price);
                int quantity = int.Parse(Quantity);
                PriceColor = "Gray";
                QuantityColor = "Gray";
                return new Product(_productBook.ID, Name, Description, price, quantity, true);
            }

            return null;
        }
    }
}