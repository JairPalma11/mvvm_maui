using System;
using System.Windows.Input;
using MVVMvsMVCMAUI.Models;
using MVVMvsMVCMAUI.Services;

namespace MVVMvsMVCMAUI.ViewModels
{
	public class ContactDetailViewModel : BaseViewModel
    {
		private string? _firstName;
		private string? _lastName;
		private string? _phone;
		private string? _email;
        MyContact? _currentContact;

        public string? FirstName
		{
			get => _firstName;
			set => SetProperty(ref _firstName, value);
		}

        public string? LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        public string? Phone
        {
            get => _phone;
            set => SetProperty(ref _phone, value);
        }

        public string? Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public ICommand SaveCommand { get; private set; }

        public ContactDetailViewModel()
        {
            SaveCommand = new Command(async () => await OnSaveCommand());
        }

        private async Task OnSaveCommand()
        {
            if (_currentContact == null)
            {
                //nuevo contacto
                _currentContact = new MyContact
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    PhoneNumber = Phone,
                    Email = Email
                };

                MyDatabase.Instance.Database.Insert(_currentContact);
            }
            else
            {
                //actualizar contacto
                _currentContact.FirstName = FirstName;
                _currentContact.LastName = LastName;
                _currentContact.PhoneNumber = Phone;
                _currentContact.Email = Email;
                MyDatabase.Instance.Database.Update(_currentContact);
            }

            //cerramos la pagina actual y regresamos
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public void SetContact(MyContact? contact)
		{
            _currentContact = contact;
            FirstName = contact?.FirstName;
            LastName = contact?.LastName;
            Phone = contact?.PhoneNumber;
            Email = contact?.Email;
		}
	}
}

