using MVVMvsMVCMAUI.ViewModels;

namespace MVVMvsMVCMAUI.Pages;

public partial class BMICalculatorPage : ContentPage
{
	public BMICalculatorPage()
	{
		InitializeComponent();
		BindingContext = new BMICalculatorViewModel();
    }
}
