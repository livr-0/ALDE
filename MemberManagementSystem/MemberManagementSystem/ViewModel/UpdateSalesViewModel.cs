using MemberManagementSystem.Commands;
using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;

namespace MemberManagementSystem.ViewModel
{
    internal class UpdateSalesViewModel : ViewModelBase
    {
        Book<Sales> _salesBook;
        Book<Product> _productBook;
        Book<Member> _memberBook;

        private ObservableCollection<SalesViewModel> _sales;
        public IEnumerable<SalesViewModel> Sales => _sales;
        public ICommand HomePage { get; }
        public ICommand AlterSales { get; }
        public ICommand DeleteSales { get; }

        private string _quantity;

        public string Quantity
        {
            get { return _quantity; }
            set { _quantity = value; OnPropertyChanged(nameof(Quantity)); }
        }

        private string _memberID;

        public string MemberID
        {
            get { return _memberID; }
            set { _memberID = value; OnPropertyChanged(nameof(MemberID)); }
        }

        private string _productID;

        public string ProductID
        {
            get { return _productID; }
            set { _productID = value; OnPropertyChanged(nameof(ProductID)); }
        }

        private string _dateTime;

        public string DateTime
        {
            get { return _dateTime; }
            set { _dateTime = value; OnPropertyChanged(nameof(DateTime)); }
        }

        private SalesViewModel _selectedSales;
        public SalesViewModel SelectedSales
        {
            get { return _selectedSales; }
            set
            {
                _selectedSales = value;
                updateTextBoxes(); OnPropertyChanged("SelectedSales");
            }
        }

        public UpdateSalesViewModel(Book<Sales> salesBook, NavigateService navService, Book<Product> productBook, Book<Member> memberBook)
        {
            HomePage = new NavigateCommand(navService, nameof(HomeViewModel));
            _salesBook = salesBook;
            _productBook = productBook;
            _memberBook = memberBook;
            _sales = new ObservableCollection<SalesViewModel>();
            GatherSalesViews(salesBook);
            AlterSales = new UpdateRecordCommand<Sales>(salesBook, UpdateSales);
            DeleteSales = new RemoveRecordCommand<Sales>(salesBook, RemoveSales);
        }

        private void GatherSalesViews(Book<Sales> salesBook)
        {
            _sales.Clear();
            IEnumerable<Sales> salesRecords = salesBook.Records;
            foreach (Sales sales in salesRecords)
            {
                _sales.Add(new SalesViewModel(sales, _memberBook, _productBook));
            }
        }

        private void updateTextBoxes() 
        {
            ProductID = SelectedSales.ProductID.ToString();
            MemberID = SelectedSales.MemberID.ToString();
            DateTime = SelectedSales.DateTime.ToString();
            Quantity = SelectedSales.Quantity.ToString();
        }

        private void UpdateSales()
        {
            if (!string.IsNullOrEmpty(ProductID) && !string.IsNullOrEmpty(MemberID) && !string.IsNullOrEmpty(Quantity))
            {
                int productID = int.Parse(ProductID);
                int memberID = int.Parse(MemberID);
                int quantity = int.Parse(Quantity);

                Sales sChanged = _salesBook.GetSingleRecord(int.Parse(_selectedSales.SalesID));

                sChanged.ProductID = productID;
                sChanged.MemberID = memberID;
                sChanged.Quantity = quantity;
                sChanged.DateTime = DateTime;
            }
        }

        private void RemoveSales()
        {
            if (SelectedSales != null)
            {
                _salesBook.RemoveRecord(SelectedSales.Sale);
            }
        }
    }
}