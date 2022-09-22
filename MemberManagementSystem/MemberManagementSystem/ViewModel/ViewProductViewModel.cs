using MemberManagementSystem.Commands;
using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;

namespace MemberManagementSystem.ViewModel
{
    internal class ViewProductViewModel : ViewModelBase
    {
        Book<Product> _productBook;

        private ObservableCollection<ProductViewModel> _product;
        public IEnumerable<ProductViewModel> Products => _product;
        public ICommand HomePage { get; }

        public ICommand UpdateProductPage { get; }

        public ViewProductViewModel(Book<Product> productBook, NavigateService navService)
        {
            HomePage = new NavigateCommand(navService, nameof(HomeViewModel));
            UpdateProductPage = new NavigateCommand(navService, nameof(UpdateProductViewModel));
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
    }
}