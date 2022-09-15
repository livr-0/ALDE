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
            Book<Member> memberBook = Book<Member>.LoadBook("../Database/MemberDatabase.csv");
            Book<Product> productBook = Book<Product>.LoadBook("../Database/ProductDatabase.csv");
            Book<Sales> salesBook =  Book<Sales>.LoadBook("../Database/SalesDatabase.csv");

          

            //Creation of Stores and Services            
            _navStore = new NavigateStore();
            _navService = new Service.NavigateService(_navStore);
            _factory = new Service.ViewModelFactory(_navService, memberBook, productBook, salesBook);
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

////reading in product database
//try
//{
//    string[] productsCSV = System.IO.File.ReadAllLines("../Database/ProductDatabase.csv");

//    foreach (string productCSV in productsCSV)
//    {
//        if (productsCSV[0] != productCSV)
//        {
//            string[] productDetails = productCSV.Split(',');
//            int num = Int32.Parse(productDetails[0]);

//            // incase a description has a comma
//            string desc = productDetails[2].Substring(1);
//            int currentIndex = 2;
//            if (productDetails[2][0] == '"')
//            {
//                for (int i = 3; i < productDetails.Length; i++)
//                {
//                    desc += productDetails[i];
//                    currentIndex++;
//                    if (productDetails[i].EndsWith('"'))
//                    {
//                        desc = desc.Substring(0, desc.Length - 1);
//                        break;
//                    }
//                }
//            }

//            float price = float.Parse(productDetails[currentIndex + 1].Substring(1));
//            int quantity = Int32.Parse(productDetails[currentIndex + 2]);

//            productBook.AddRecord(new Product(num, productDetails[1], desc, price, quantity));
//        }
//    }
//}
//catch (System.IO.IOException e)
//{
//    Console.WriteLine("file not found");
//}
