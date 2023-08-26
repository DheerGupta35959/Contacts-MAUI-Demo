using Contacts.Maui.Models;
using Contacts.Maui.Repository;

namespace Contacts.Maui.Views;

[QueryProperty(nameof(Id), "Id")]
public partial class EditContactsPage : ContentPage
{
    private ContactModel contact;
    public EditContactsPage()
    {
        InitializeComponent();
    }

    public string Id
    {
        set
        {
            contact = ContactRepository.GetById(int.Parse(value));
            if (contact != null)
            {
                contactControl.Name = contact.Name;
                contactControl.Email = contact.Email;
                contactControl.Phone = contact.Phone;
                contactControl.Address = contact.Address;
            }
        }
    }

    private async void btnCancel_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void btnUpdate_Clicked(object sender, EventArgs e)
    {

        contact.Name = contactControl.Name;
        contact.Email = contactControl.Email;
        contact.Phone = contactControl.Phone;
        contact.Address = contactControl.Address;

        ContactRepository.UpdateContact(contact);

        await Shell.Current.GoToAsync("..");
    }

    private void contactControlError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");

    }
}