using MVVMvsMVCMAUI.Pages;

namespace MVVMvsMVCMAUI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new ContactsTabbedPage();
	}
}

