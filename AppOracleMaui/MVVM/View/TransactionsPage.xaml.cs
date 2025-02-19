using AppOracleMaui.MVVM.ViewModel;

namespace AppOracleMaui.MVVM.View;

public partial class TransactionsPage : ContentPage
{
	private TransactionsViewModel viewModel= new TransactionsViewModel();
	public TransactionsPage()
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}