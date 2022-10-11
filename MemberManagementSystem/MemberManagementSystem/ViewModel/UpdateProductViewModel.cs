using MemberManagementSystem.Commands;
using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace MemberManagementSystem.ViewModel
{
    internal class UpdateProductViewModel : ViewModelBase
    {
        Book<Product> _productBook;

        private ObservableCollection<ProductViewModel> _product;
        public IEnumerable<ProductViewModel> Products => _product;
        public ICommand HomePage { get; }
        public ICommand AlterProduct { get; }
        public ICommand DeleteProduct { get; }

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

        private string _productColor = "Gray";
        public string ProductColor
        {
            get { return _productColor; }
            set { _productColor = value; OnPropertyChanged(nameof(ProductColor)); }
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

        private string _productError = "";
        public string ProductError
        {
            get { return _productError; }
            set { _productError = value; OnPropertyChanged(nameof(ProductError)); }
        }

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

        private ProductViewModel _selectedProduct;
        public ProductViewModel SelectedProduct
        {
            get { return _selectedProduct; }
            set { _selectedProduct = value;
                updateTextBoxes(); OnPropertyChanged("SelectedProduct"); }
        }

        public UpdateProductViewModel(Book<Product> productBook, NavigateService navService)
        {
            HomePage = new NavigateCommand(navService, nameof(HomeViewModel));
            _productBook = productBook;
            _product = new ObservableCollection<ProductViewModel>();
            GatherProductViews(productBook);
            AlterProduct = new UpdateRecordCommand<Product>(productBook, UpdateProduct);
            DeleteProduct = new RemoveRecordCommand<Product>(productBook, RemoveProduct);
        }

        private void GatherProductViews(Book<Product> productBook)
        {
            _product.Clear();
            IEnumerable<Product> products = productBook.Records; 
            foreach (Product product in products)
            {
                if (product.ActiveStatus)
                {
                    _product.Add(new ProductViewModel(product));
                }
            }
        }

        private void updateTextBoxes()
        {
            if (_selectedProduct != null)
            {
                Name = SelectedProduct.Name.ToString();
                Description = SelectedProduct.Description.ToString();
                Quantity = SelectedProduct.Quantity.ToString();
                Price = SelectedProduct.Price.ToString();
            }
            else
            {
                Name = null;
                Description = null;
                Quantity = null;
                Price = null;
            }
        }

        private void UpdateProduct()
        {
            bool inputCorrect = true;

            if (_selectedProduct == null)
            {
                ProductColor = "Red";
                ProductError = "Please Select a Product.";
            }
            else
            {
                ProductColor = "Gray";
                ProductError = "";
            }

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

                Product pChanged = _productBook.GetSingleRecord(int.Parse(_selectedProduct.ProductID));

                pChanged.Price = price;
                pChanged.Quantity = quantity;
                pChanged.Name = _name;
                pChanged.Description = _description;

                SubmitMsgColor = "Green";
                SubmitMsg = "Product Updated";
                // _productBook.SwapRecord(pChanged);
            }
            else
            {
                SubmitMsgColor = "Red";
                SubmitMsg = "Failed to update Product.\nIf original data is needed, reselect product.";
            }


        }

        private void RemoveProduct()
        {
            if(SelectedProduct != null)
            {
                ProductColor = "Gray";
                ProductError = "";
                NameColor = "Gray";
                NameError = "";
                DescColor = "Gray";
                DescError = "";
                PriceColor = "Gray";
                PriceError = "";
                QuantityColor = "Gray";
                QuantityError = "";

                _productBook.RemoveRecord(SelectedProduct.Product);
                GatherProductViews(_productBook);
                SubmitMsgColor = "Green";
                SubmitMsg = "Product Removed";
            }
            else
            {
                ProductColor = "Red";
                ProductError = "Please Select a Product.";

                SubmitMsgColor = "Red";
                SubmitMsg = "Failed to delete Product.";
            }
        }
    }
}