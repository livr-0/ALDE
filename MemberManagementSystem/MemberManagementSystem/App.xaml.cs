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
        private readonly NavigationStore _navStore;
        private readonly Service.NavigationService _navService;
        private readonly Service.ViewModelFactory _factory;

        public App()
        {
            //Creation of Models

            //Creation of Stores and Services
            _factory = new Service.ViewModelFactory();
            _navStore = new NavigationStore();
            _navService = new Service.NavigationService(_navStore, _factory);
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
