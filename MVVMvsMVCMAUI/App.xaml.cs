using MVVMvsMVCMAUI.Pages;

namespace MVVMvsMVCMAUI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        //descomenta para vista a vista bindings
        MainPage = new BindingPage();

        //descomenta para ejemplo de MVVM y bindings
        //MainPage = new NavigationPage(new SimplePage());

        //descomenta para ver la refactorizacion de MVC a MVVM
        //MainPage = new NavigationPage(new ContactsPage());

    }
}

