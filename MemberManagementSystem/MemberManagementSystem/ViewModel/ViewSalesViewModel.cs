using MemberManagementSystem.Commands;
using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using MemberManagementSystem.Stores;
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
        RecordViewModelStore _salesStore;

        public IEnumerable<ViewModelBase> Sales => _salesStore.RecordsToDisplay ;

        private string _memberSearch;

        public string MemberSearch
        {
            get { return _memberSearch; }
            set { _memberSearch = value; OnPropertyChanged(nameof(MemberSearch)); }
        }

        public ICommand HomePage { get; }

        public ICommand UpdateSalesPage { get; }

        public ICommand ClearSearch { get; }
        public ICommand Search { get; }
        public ICommand Export { get; }

        public ViewSalesViewModel(Book<Sales> salesBook, NavigateService navService, RecordViewModelFactory recordViewModelFactory, Book<Member> memberBook, Book<Product> productBook)
        {
            _salesStore = new RecordViewModelStore();
            _salesBook = salesBook;
            _memberBook = memberBook;
            _productBook = productBook;

            HomePage = new NavigateCommand(navService, nameof(HomeViewModel));
            UpdateSalesPage = new NavigateCommand(navService, nameof(UpdateSalesViewModel));
            ClearSearch = new ResetRecordViewStoreCommand<Sales>(_salesStore, _salesBook, recordViewModelFactory);
            ClearSearch.Execute(null);

            Search = new SearchByMemberCommand(memberBook, salesBook, _salesStore, recordViewModelFactory, this);
            Export = new ExportCSVCommand<Sales>(_salesStore, "Sales Report");
        }

       




        //private void OnSalesChanged(object sender, NotifyCollectionChangedEventArgs e)
        //{
        //    OnPropertyChanged(nameof(HasSales));
        //}
    }
}