using MemberManagementSystem.Commands;
using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using System;
using System.Windows.Input;

namespace MemberManagementSystem.ViewModel
{
    internal class AddProductViewModel : ViewModelBase
    {
        private string _productID;

        public string ProductID
        {
            get { return _productID; }
            set { _productID = value; OnPropertyChanged(nameof(ProductID)); }
        }

        private string _memberID;

        public string MemberID
        {
            get { return _memberID; }
            set { _memberID = value; OnPropertyChanged(nameof(MemberID)); }
        }

        private string _dateTime;

        public string DateTime
        {
            get { return _dateTime; }
            set { _dateTime = value; OnPropertyChanged(nameof(DateTime)); }
        }

        private int _quantity;

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; OnPropertyChanged(nameof(Quantity)); }
        }



        public AddSalesViewModel(NavigateService navService, Book<Sales> salesBook)
        {
            HomePage = new NavigateCommand(navService, nameof(HomeViewModel));
            SubmitSales = new AddRecordCommand<Sales>(salesBook, CreateSales);
        }



        public ICommand HomePage { get; }
        public ICommand SubmitSales { get; }

        private Product CreateSales()
        {
            int quantity = int.Parse(Quantity);
            return new Product(App.ID, ProductID, MemberID, DateTime, quantity);
        }
    }
}