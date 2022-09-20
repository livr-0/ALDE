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

        private ObservableCollection<SalesViewModel> _sales;
        public IEnumerable<SalesViewModel> Sales => _sales;

        public ICommand HomePage { get; }

        public ViewSalesViewModel(Book<Sales> salesBook, NavigateService navService)
        {
            HomePage = new NavigateCommand(navService, nameof(HomeViewModel));
            _salesBook = salesBook;
            _sales = new ObservableCollection<SalesViewModel>();
            GatherSalesViews(salesBook);
        }

        private void GatherSalesViews(Book<Sales> saleBook)
        {
            _sales.Clear();
            IEnumerable<Sales> sales = saleBook.Records;
            foreach(Sales sale in sales)
            {
                _sales.Add(new SalesViewModel(sale));
            }
        }




        //private void OnSalesChanged(object sender, NotifyCollectionChangedEventArgs e)
        //{
        //    OnPropertyChanged(nameof(HasSales));
        //}
    }
}