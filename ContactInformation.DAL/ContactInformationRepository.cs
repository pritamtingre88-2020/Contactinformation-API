using ContactInformation.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ContactInformation.DAL
{
    public class ContactInformationRepository
    {
        private List<ContactDO> Contacts;

        private string JsonFilePath
        {
            get
            {
                return string.Empty;
            }
        }

        private void LoadContacts()
        {
            // read file into a string and deserialize JSON to a type
            Contacts = JsonConvert.DeserializeObject<List<ContactDO>>(File.ReadAllText(JsonFilePath));

            if (!Contacts.Any())
            {
                Contacts = new List<ContactDO>
                {
                    new ContactDO
                    {
                        FirstName = "Pritam",
                        LastName = "Tingre",
                        Email ="pritam.tingre@exmple.com",
                        IsActive = true,
                        PhoneNumber = "123-456-789"
                    },
                    new ContactDO
                    {
                        FirstName = "Ravi",
                        LastName = "Srivastava",
                        Email ="ravi.srivastava@exmple.com",
                        IsActive = true,
                        PhoneNumber = "123-456-555"
                    }
                };
            }
        }

        public List<ContactDO> GetAllContacts()
        {
            return Contacts;
        }

        public ContactDO GetContact(int id)
        {
            return Contacts.FirstOrDefault(c => c.Id == id);
        }

        public void Insert(ContactDO contact)
        {
            contact.Id = Contacts.Select(c => c.Id).Max() + 1;
            Contacts.Add(contact);
            CommitChangesToFile();
        }

        public void Update(ContactDO contact)
        {
            var contactToUpdate = Contacts.FirstOrDefault(c => c.Id == contact.Id);
            int index = Contacts.IndexOf(contactToUpdate);
            Contacts.RemoveAt(index);
            Contacts.Insert(index, contact);
            CommitChangesToFile();
        }

        public void Delete(int id)
        {
            var contactToDelete = Contacts.FirstOrDefault(c => c.Id == id);
            int index = Contacts.IndexOf(contactToDelete);
            Contacts.RemoveAt(index);
            CommitChangesToFile();
        }


        private void CommitChangesToFile()
        {
            File.WriteAllText(JsonFilePath, JsonConvert.SerializeObject(Contacts));
            LoadContacts();
        }
    }
}
