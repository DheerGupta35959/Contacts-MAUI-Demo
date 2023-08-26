using Contacts.Maui.Models;
using Contacts.Maui.Repository;
using System.Collections.ObjectModel;

namespace Contacts.Maui.Views;

public partial class ContactsPage : ContentPage
{
    public ContactsPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        SearchBar.Text = string.Empty;

        LoadContacts();
    }

    private async void list_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (listContacts.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(EditContactsPage)}?Id={((ContactModel)listContacts.SelectedItem).Id}");
        }
    }

    private void list_ItemTapped(object sender, ItemTappedEventArgs e)
    {

    }

    private async void btnAdd_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddContactsPage));
    }

    private void LoadContacts()
    {
        var contactsList = new ObservableCollection<ContactModel>(ContactRepository.GetAll());

        listContacts.ItemsSource = contactsList;

    }

    private void btnDeleteClicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact = menuItem.CommandParameter as ContactModel;
        ContactRepository.Delete(contact.Id);

        LoadContacts();
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var contacts = new ObservableCollection<ContactModel>(ContactRepository.SearchContacts(((SearchBar)sender).Text));

        listContacts.ItemsSource = contacts;
    }
}