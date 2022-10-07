using MemberManagementSystem.Commands;
using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using System;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Collections.Generic;

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

        private string _nameColor = "Gray";
        public string NameColor
        {
            get { return _nameColor; }
            set { _nameColor = value; OnPropertyChanged(nameof(NameColor)); }
        }

        private string _descColor = "Gray";
        public string DescColor
        {
            get { return _descColor; }
            set { _descColor = value; OnPropertyChanged(nameof(DescColor)); }
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

        private string _nameError = "";
        public string NameError
        {
            get { return _nameError; }
            set { _nameError = value; OnPropertyChanged(nameof(NameError)); }
        }

        private string _descError = "";
        public string DescError
        {
            get { return _descError; }
            set { _descError = value; OnPropertyChanged(nameof(DescError)); }
        }

        private string _priceError = "";
        public string PriceError
        {
            get { return _priceError; }
            set { _priceError = value; OnPropertyChanged(nameof(PriceError)); }
        }

        private string _quantityError = "";
        public string QuantityError
        {
            get { return _quantityError; }
            set { _quantityError = value; OnPropertyChanged(nameof(QuantityError)); }
        }

        private string _submitMsg = "";
        public string SubmitMsg
        {
            get { return _submitMsg; }
            set { _submitMsg = value; OnPropertyChanged(nameof(SubmitMsg)); }
        }

        public string _submitMsgColor = "Red";
        public string SubmitMsgColor
        {
            get { return _submitMsgColor; }
            set { _submitMsgColor = value; OnPropertyChanged(nameof(SubmitMsgColor)); }
        }

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

            if (_name == null)
            {
                inputCorrect = false;
                NameColor = "Red";
                NameError = "Please enter product name.";
            }
            else
            {
                NameColor = "Gray";
                NameError = "";
            }

            if (_description == null)
            {
                inputCorrect = false;
                DescColor = "Red";
                DescError = "Please enter product description.";
            }
            else
            {
                DescColor = "Gray";
                DescError = "";
            }

            if (_price == null || _priceRegex.IsMatch(_price) == false)
            {
                inputCorrect = false;
                PriceColor = "Red";
                PriceError = "Please enter product price in formats:\n12, 12.3, 15.46";
            }
            else
            {
                PriceColor = "Gray";
                PriceError = "";
            }

            if (_quantity == null || _quantityRegex.IsMatch(_quantity) == false)
            {
                inputCorrect = false;
                QuantityColor = "Red";
                QuantityError = "Please enter quantity of product.\nAny integer.";
            }
            else
            {
                QuantityColor = "Gray";
                QuantityError = "";
            }

            if (inputCorrect)
            {
                float price = float.Parse(Price);
                int quantity = int.Parse(Quantity);

                Product newProduct = new Product(_productBook.ID, Name, Description, price, quantity, true);

                if(_productBook.RecordExists(newProduct))
                {
                    SubmitMsgColor = "Red";
                    SubmitMsg = "Product already exists";
                }
                else
                {
                    SubmitMsgColor = "Green";
                    SubmitMsg = "Product Created";
                    return newProduct;
                }
            }
            else
            {
                SubmitMsgColor = "Red";
                SubmitMsg = "Failed to create Product";
            }

            return null;
        }
    }
}