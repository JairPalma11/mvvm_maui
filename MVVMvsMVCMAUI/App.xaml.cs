using MVVMvsMVCMAUI.Pages;

namespace MVVMvsMVCMAUI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		//MainPage = new NavigationPage(new ContactsPage());

		//descomenta para ejemplo de MVVM y bindings
		MainPage = new NavigationPage(new SimplePage()); 
    }
}

