using AppOracleMaui.MVVM.View;
using AppOracleMaui.Repository;
using ModelOracleDemo;

namespace AppOracleMaui
{
    public partial class App : Application
    {

        public static IBaseRepository<Transaction> TransactionRepository { get; set; }


       

        public App(IBaseRepository<Transaction> tr)
        {
            InitializeComponent();
            TransactionRepository = tr;
            MainPage = new NavigationPage(new DashboardPage());
        }
    }
}
