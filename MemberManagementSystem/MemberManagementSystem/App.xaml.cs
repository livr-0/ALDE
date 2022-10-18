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
        private readonly string _memberPath = "../../../Database/MemberDatabase.csv";
        private readonly string _productPath = "../../../Database/ProductDatabase.csv";
        private readonly string _salesPath = "../../../Database/SalesDatabase.csv";
        private readonly string _userPath = "../../../Database/UserDatabase.csv";


        private readonly NavigateStore _navStore;
        private readonly Service.NavigateService _navService;
        private readonly Service.ViewModelFactory _factory;
        private readonly Book<Member> _memberBook;
        private readonly Book<Product> _productBook;
        private readonly Book<Sales> _salesBook;
        private readonly Book<User> _userBook;
        public App()
        {



            //Creation of Models
            try
            {
                _memberBook = Book<Member>.LoadBook(_memberPath);
                _productBook = Book<Product>.LoadBook(_productPath);
                _salesBook = Book<Sales>.LoadBook(_salesPath);
                _userBook = Book<User>.LoadBook(_userPath);
                //Creation of Stores and Services            
                _navStore = new NavigateStore();
                _navService = new Service.NavigateService(_navStore);
                _factory = new Service.ViewModelFactory(_navService, _memberBook, _productBook, _salesBook, _userBook);
                _navService.Creator = _factory;
            } catch (System.IO.IOException e)
            {
                Console.WriteLine("file not found");
            }
            

          

          
            
        }

        public void AppExiting(object sender, EventArgs e)
        {
            _memberBook.SaveBook(_memberPath);
            _salesBook.SaveBook(_salesPath);
            _productBook.SaveBook(_productPath);
            _userBook.SaveBook(_userPath);
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            _navService.Navigate(nameof(LoginViewModel));
            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = new MainViewModel(_navStore);
            mainWindow.WindowClosing += AppExiting;
            MainWindow = mainWindow;        
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

////reading in sales database
//try
//{
//    string[] salesDatabase = System.IO.File.ReadAllLines("../Database/SalesDatabase.csv");
//    foreach (string record in salesDatabase)
//    {
//        if (salesDatabase[0] != salesDatabase)
//        {
//            string[] salesAttributes = record.Split(',');
//            int ID = Int32.Parse(salesAttributes[0]);
//            int productID = Int32.Parse(salesAttributes[1]);
//            int memberID = Int32.Parse(salesAttributes[2]);
//            int dateTime = salesAttributes[3];
//            int quantity = Int32.Parse(productDetails[4]);

//            salesBook.AddRecord(new Sales(ID, productID, memberID, dateTime, quantity));
//        }
//    }
//}
//catch (System.IO.IOException e)
//{
//    Console.WriteLine("file not found");
//}