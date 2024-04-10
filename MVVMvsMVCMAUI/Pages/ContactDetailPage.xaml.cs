using MVVMvsMVCMAUI.Models;
using MVVMvsMVCMAUI.ViewModels;

namespace MVVMvsMVCMAUI.Pages;

public partial class ContactDetailPage : ContentPage
{
    public ContactDetailPage(MyContact? contact = null)
	{
		InitializeComponent();
        var viewModel = new ContactDetailViewModel();
        viewModel.SetContact(contact);
        BindingContext = viewModel;
    }
}
