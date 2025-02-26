using AppOracleMaui.MVVM.ViewModel;

namespace AppOracleMaui.MVVM.View;

public partial class StatisticsPage : ContentPage
{
	private StatisticsViewModel vm = new StatisticsViewModel();
	public StatisticsPage()
	{
		InitializeComponent();
		BindingContext = vm;
	}
}