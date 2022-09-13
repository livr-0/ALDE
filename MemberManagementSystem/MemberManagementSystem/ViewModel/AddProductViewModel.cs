using MemberManagementSystem.Commands;
using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using System;
using System.Windows.Input;

namespace MemberManagementSystem.ViewModel
{
    internal class AddProductViewModel : ViewModelBase
    {
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



        public AddProductViewModel(NavigateService navService, Book<Product> productBook)
        {
            HomePage = new NavigateCommand(navService, nameof(HomeViewModel));
            SubmitProduct = new AddRecordCommand<Product>(productBook, CreateProduct);
        }



        public ICommand HomePage { get; }
        public ICommand SubmitProduct { get; }

        private Product CreateProduct()
        {
            float price = float.Parse(Price);
            int quantity = int.Parse(Quantity);
            return new Product(App.ID, Name, Description ,price, quantity);
        }
    }
}