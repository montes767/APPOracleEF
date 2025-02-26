using AppOracleMaui.MVVM.ViewModel;
using System.Threading.Tasks;
namespace AppOracleMaui.MVVM.View;

public partial class DashboardPage : ContentPage
{
	private DashboardViewModel viewModel { get; set; } = new DashboardViewModel();
	public DashboardPage()
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new TransactionsPage());
    }

	//protected async override void OnAppearing()
	//{
	//	await viewModel.GetTransactions();
	//}

  //  private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
  //  {
		//await Navigation.PushAsync(new TransactionsPage());
  //  }


}