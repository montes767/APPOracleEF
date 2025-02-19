using AppOracleMaui.MVVM.View;

namespace AppOracleMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TransactionsPage();
        }
    }
}
