using Contacts.Maui.Models;

namespace Contacts.Maui.Repository
{
    public static class ContactRepository
    {
        public static List<ContactModel> _contacts = new List<ContactModel>()
        {
            new ContactModel { Id = 1, Name = "John Doe", Email = "a@a.com", Phone = "123", Address="112" },
            new ContactModel { Id = 2, Name = "John Doe 2", Email = "a@a.com", Phone = "123", Address="112"  },
            new ContactModel { Id = 3, Name = "John Doe 3", Email = "a@a.com", Phone = "123", Address="112"  }
        };

        public static List<ContactModel> GetAll() => _contacts;

        public static ContactModel GetById(int id)
        {
            var contact = _contacts.FirstOrDefault(x => x.Id == id);

            if (contact != null)
            {
                return new ContactModel
                {
                    Id = contact.Id,
                    Name = contact.Name,
                    Email = contact.Email,
                    Phone = contact.Phone,
                    Address = contact.Address,
                };
            }

            return null;
        }

        public static void UpdateContact(ContactModel model)
        {
            var contactToUpdate = _contacts.FirstOrDefault(x => x.Id == model.Id);
            if (contactToUpdate != null)
            {
                contactToUpdate.Name = model.Name;
                contactToUpdate.Email = model.Email;
                contactToUpdate.Phone = model.Phone;
                contactToUpdate.Address = model.Address;
            }
        }

        public static void AddContact(ContactModel model)
        {
            if (model != null)
            {
                if (model.Id == 0)
                {
                    model.Id = _contacts.LastIndexOf(model);
                }

                _contacts.Add(model);
            }
        }

        public static void Delete(int id)
        {
            if (id != 0)
            {
                _contacts.Remove(_contacts.First(x => x.Id == id));
            }
        }

        public static List<ContactModel> SearchContacts(string search)
        {
            var contacts = _contacts.Where(x => x.Name.StartsWith(search, StringComparison.OrdinalIgnoreCase))?.ToList();

            return contacts;
        }
    }
}
