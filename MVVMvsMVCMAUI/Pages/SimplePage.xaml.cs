using MVVMvsMVCMAUI.ViewModels;

namespace MVVMvsMVCMAUI.Pages;

public partial class SimplePage : ContentPage
{
	public SimplePage()
	{
		InitializeComponent();
        //para conectar un view model con la vista
        //debemos asignar la propiedad  BindingContext
        //esta propiedad esta en todos los bindable objects
        BindingContext = new SimpleViewModel();
    }
}
