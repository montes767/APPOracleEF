using AppOracleMaui.MVVM.ViewModel;
using ModelOracleDemo;
using System.Threading.Tasks;

namespace AppOracleMaui.MVVM.View;

public partial class TransactionsPage : ContentPage
{
	private TransactionsViewModel viewModel= new TransactionsViewModel();
	public TransactionsPage()
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
    public TransactionsPage(Transaction trans)
    {
        InitializeComponent();
		TransactionsViewModel vm = new TransactionsViewModel(trans);
        BindingContext = vm;
    }

    private async void Boton_save(object sender, EventArgs e)
    {
		await viewModel.SaveTransaction();
		await DisplayAlert("info", "registro insertado", "Ok");
		await Navigation.PopToRootAsync();
		
    }

	private async void buttonCancel(object sender, EventArgs e)
	{
        await Navigation.PopToRootAsync();
    }
}