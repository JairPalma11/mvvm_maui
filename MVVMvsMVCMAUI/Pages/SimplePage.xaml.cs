using MVVMvsMVCMAUI.ViewModels;

namespace MVVMvsMVCMAUI.Pages;

public partial class SimplePage : ContentPage
{
	public SimplePage()
	{
		InitializeComponent();
		BindingContext = new SimpleViewModel();
    }
}
