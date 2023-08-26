using Contacts.Maui.Models;
using Contacts.Maui.Repository;

namespace Contacts.Maui.Views;

public partial class AddContactsPage : ContentPage
{
    public AddContactsPage()
    {
        InitializeComponent();
    }

    private async void btnAdd_Clicked(object sender, EventArgs e)
    {
        var contact = new ContactModel
        {
            Name = contactControl.Name,
            Email = contactControl.Email,
            Phone = contactControl.Phone,
            Address = contactControl.Address,
        };

        ContactRepository.AddContact(contact);

        await Shell.Current.GoToAsync("..");
    }

    private async void btnCancel_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private void contactControlError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");

    }
}