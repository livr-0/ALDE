﻿using MemberManagementSystem.Commands;
using MemberManagementSystem.Model;
using MemberManagementSystem.Service;
using MemberManagementSystem.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using MemberManagementSystem.Commands;
using System.Windows.Input;

namespace MemberManagementSystem.ViewModel
{
    internal class ViewProductViewModel : ViewModelBase
    {
        Book<Product> _productBook;
        RecordViewModelStore _productStore;
        public IEnumerable<ViewModelBase> Products => _productStore.RecordsToDisplay;
        public ICommand HomePage { get; }
        public ICommand UpdateProductPage { get; }
        public ICommand ClearSearch { get; }
        public ICommand Sort { get; }

        private IEnumerable<SortProductCommand.Option> _options;
        public IEnumerable<SortProductCommand.Option> Options => _options;
        public SortProductCommand.Option Option { get; }

        public ViewProductViewModel(Book<Product> productBook, NavigateService navService, RecordViewModelFactory recordViewModelFactory)
        {
            HomePage = new NavigateCommand(navService, nameof(HomeViewModel));
            UpdateProductPage = new NavigateCommand(navService, nameof(UpdateProductViewModel));
            _productBook = productBook;
            _productStore = new RecordViewModelStore();

            ClearSearch = new ResetRecordViewStoreCommand<Product>(_productStore, _productBook, recordViewModelFactory);
            ClearSearch.Execute(null);
        }

        //private void GatherProductViews(Book<Product> productBook)
        //{
        //    _product.Clear();
        //    IEnumerable<Product> products = productBook.Records; 
        //    foreach (Product product in products)
        //    {
        //        _product.Add(new ProductViewModel(product));
        //    }
        //}
    }
}