using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using MVVMvsMVCMAUI.Models;
using MVVMvsMVCMAUI.Pages;
using MVVMvsMVCMAUI.Services;

namespace MVVMvsMVCMAUI.ViewModels
{
	public class ContactsViewModel : BaseViewModel
	{
		private ObservableCollection<MyContact> _contacts;

		public ObservableCollection<MyContact> Contacts
		{
			get => _contacts;
			set => SetProperty(ref _contacts, value);
		}

		public ICommand DeleteCommand { get; private set; }
        public ICommand TestCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand AppearingCommand { get; private set; }

        public ContactsViewModel()
		{
            Contacts = new ObservableCollection<MyContact>();
            UpdateCommand = new Command<MyContact>(async (contact) => await OnUpdateCommand(contact));
            AddCommand = new Command(async () => await OnAddCommand());
            TestCommand = new Command(async () => await OnTestCommand());
            DeleteCommand = new Command<MyContact>(OnDeleteCommand);
            AppearingCommand = new Command(OnAppearingCommand);
        }

        private void OnAppearingCommand()
        {
            //NOTA: esto se puede mejorar
            //mas adelante se hara una refactorizacion
            //final
            var contacts = MyDatabase.Instance.Database!.Table<MyContact>().ToList();
            Contacts = new ObservableCollection<MyContact>(contacts);
        }

        private async Task OnUpdateCommand(MyContact contact)
        {
            //NOTA: esto se puede mejorar, sin embargo
            //sera hasta ver Dependency Injection
            //Shell navigation
            await Application.Current.MainPage.Navigation.PushAsync(new ContactDetailPage(contact));
        }

        private async Task OnAddCommand()
        {
            //NOTA: esto se puede mejorar, sin embargo
            //sera hasta ver Dependency Injection
            await Application.Current.MainPage.Navigation.PushAsync(new ContactDetailPage());
        }

        private async Task OnTestCommand()
		{
            try
            {
                var contacts = ContactService.GetContacts(10);
                //guardamos todos los contactos
                MyDatabase.Instance.Database.InsertAll(contacts);

                //refrescamos la lista
                //con los nuevos contactos
                contacts = MyDatabase.Instance.Database!.Table<MyContact>().ToList();
                Contacts = new ObservableCollection<MyContact>(contacts);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void OnDeleteCommand(MyContact contact)
        {
            MyDatabase.Instance.Database.Delete(contact);
            //refrescamos la lista
            var contacts = MyDatabase.Instance.Database!.Table<MyContact>().ToList();
			Contacts = new ObservableCollection<MyContact>(contacts);
        }
    }
}

