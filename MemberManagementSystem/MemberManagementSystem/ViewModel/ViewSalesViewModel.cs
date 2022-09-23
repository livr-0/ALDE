using MemberManagementSystem.Commands;
using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;

namespace MemberManagementSystem.ViewModel
{
    internal class ViewSalesViewModel : ViewModelBase
    {
        Book<Sales> _salesBook;
        Book<Product> _productBook;
        Book<Member> _memberBook;

        private ObservableCollection<SalesViewModel> _sales;
        public IEnumerable<SalesViewModel> Sales => _sales;

        public ICommand HomePage { get; }

        public ICommand UpdateSalesPage { get; }

        public ViewSalesViewModel(Book<Sales> salesBook, NavigateService navService, Book<Member> memberBook, Book<Product> productBook)
        {
            HomePage = new NavigateCommand(navService, nameof(HomeViewModel));
            _salesBook = salesBook;
            _sales = new ObservableCollection<SalesViewModel>();
            _memberBook = memberBook;
            _productBook = productBook;
            GatherSalesViews(salesBook);
            UpdateSalesPage = new NavigateCommand(navService, nameof(UpdateSalesViewModel));
        }

        private void GatherSalesViews(Book<Sales> salesBook)
        {
            _sales.Clear();
            IEnumerable<Sales> sales = salesBook.Records;
            foreach(Sales s in sales)
            {
                _sales.Add(new SalesViewModel(s, _memberBook, _productBook));
            }
        }




        //private void OnSalesChanged(object sender, NotifyCollectionChangedEventArgs e)
        //{
        //    OnPropertyChanged(nameof(HasSales));
        //}
    }
}