using MemberManagementSystem.Model;
using MemberManagementSystem.Stores;
using MemberManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace MemberManagementSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static int _id = 0;
        public static int ID { get { _id++;  return _id; } }

        private readonly NavigateStore _navStore;
        private readonly Service.NavigateService _navService;
        private readonly Service.ViewModelFactory _factory;

        public App()
        {
            //Creation of Models
            Book<Member> memberBook = new Book<Member>();
            Book<Product> productBook = new Book<Product>();

            //Creation of Stores and Services            
            _navStore = new NavigateStore();
            _navService = new Service.NavigateService(_navStore);
            _factory = new Service.ViewModelFactory(_navService, memberBook, productBook);
            _navService.Creator = _factory;
            
        }


        protected override void OnStartup(StartupEventArgs e)
        {

            _navService.Navigate(nameof(HomeViewModel));

            MainWindow = new MainWindow()
            {
               DataContext = new MainViewModel(_navStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
