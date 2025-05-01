using MauiCalc.ViewModel;
namespace MauiCalc.View;

public partial class MainPage : ContentPage
{
	readonly CalcViewModel _ViewModel = new();

	public MainPage()
	{
		InitializeComponent();
		BindingContext = _ViewModel;
	}
}

