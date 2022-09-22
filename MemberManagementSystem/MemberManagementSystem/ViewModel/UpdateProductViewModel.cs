using MemberManagementSystem.Commands;
using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;

namespace MemberManagementSystem.ViewModel
{
    internal class UpdateProductViewModel : ViewModelBase
    {
        Book<Product> _productBook;

        private ObservableCollection<ProductViewModel> _product;
        public IEnumerable<ProductViewModel> Products => _product;
        public ICommand HomePage { get; }

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
        }

        private void GatherProductViews(Book<Product> productBook)
        {
            _product.Clear();
            IEnumerable<Product> products = productBook.Records; 
            foreach (Product product in products)
            {
                _product.Add(new ProductViewModel(product));
            }
        }

        private void updateTextBoxes()
        {
            Name = SelectedProduct.Name.ToString();
            Description = SelectedProduct.Description.ToString();
            Quantity = SelectedProduct.Quantity.ToString();
            Price = SelectedProduct.Price.ToString();   
        }
    }
}