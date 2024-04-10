using MVVMvsMVCMAUI.Models;
using MVVMvsMVCMAUI.Services;
using MVVMvsMVCMAUI.ViewModels;

namespace MVVMvsMVCMAUI.Pages;

public partial class ContactsPage : ContentPage
{
    ContactsViewModel _viewModel;

    public ContactsPage()
	{
		InitializeComponent();
        //Esta propiedad permite
        //vincular el view model con nuestra
        //vista
        BindingContext = _viewModel = new ContactsViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.AppearingCommand.Execute(null);
    }
}
