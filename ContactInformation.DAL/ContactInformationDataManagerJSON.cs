using ContactInformation.DAL.Interface;
using ContactInformation.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ContactInformation.DAL
{
    /// <summary>
    /// This class performs CRUD operations on the contacts. 
    /// The data source for the contact data is a simple json file.
    /// </summary>
    public class ContactInformationDataManagerJSON : IContactInformationDataManager
    {
        private List<ContactDO> Contacts;

        private string JsonFilePath
        {
            get
            {
                return System.Web.Hosting.HostingEnvironment.MapPath("~/Contacts.json");
            }
        }
        public ContactInformationDataManagerJSON()
        {
            LoadContacts();
        }

        private void LoadContacts()
        {
            if (!string.IsNullOrEmpty(JsonFilePath))
            {
                // read file into a string and deserialize JSON to a type
                Contacts = JsonConvert.DeserializeObject<List<ContactDO>>(File.ReadAllText(JsonFilePath));
            }

            if (Contacts == null || !Contacts.Any())
            {
                Contacts = new List<ContactDO>
                {
                    new ContactDO
                    {
                        Id = 1,
                        FirstName = "Pritam",
                        LastName = "Tingre",
                        Email ="pritam.tingre@exmple.com",
                        IsActive = true,
                        PhoneNumber = "123-456-789"
                    },
                    new ContactDO
                    {
                        Id = 2,
                        FirstName = "Ravi",
                        LastName = "Srivastava",
                        Email ="ravi.srivastava@exmple.com",
                        IsActive = true,
                        PhoneNumber = "123-456-555"
                    }
                };
            }
        }

        /// <summary>
        /// Get all contacts in the system
        /// </summary>
        /// <returns></returns>
        public List<ContactDO> GetAllContacts()
        {
            return Contacts;
        }

        /// <summary>
        /// Get Contact information for a single contact
        /// </summary>
        /// <param name="Id">Id of the contact to be retrived</param>
        /// <returns></returns>
        public ContactDO GetContactById(int Id)
        {
            return Contacts.FirstOrDefault(c => c.Id == Id);
        }

        /// <summary>
        /// Insert contact.
        /// </summary>
        /// <param name="contact">Contact to be inserted</param>
        public int InsertContact(ContactDO contact)
        {
            contact.Id = Contacts.Select(c => c.Id).Max() + 1;
            Contacts.Add(contact);
            CommitChangesToFile();
            return contact.Id;
        }

        /// <summary>
        /// Update contact
        /// </summary>
        /// <param name="contact">Contact to be updated</param>
        public void UpdateContact(ContactDO contact)
        {
            var contactToUpdate = Contacts.FirstOrDefault(c => c.Id == contact.Id);
            if (contactToUpdate == null)
                return;

            int index = Contacts.IndexOf(contactToUpdate);
            Contacts.RemoveAt(index);
            Contacts.Insert(index, contact);
            CommitChangesToFile();
        }

        /// <summary>
        /// Delete contact
        /// </summary>
        /// <param name="Id">Id of te contact to be deleted</param>
        public void DeleteContact(int Id)
        {
            var contactToDelete = Contacts.FirstOrDefault(c => c.Id == Id);
            if (contactToDelete == null)
                return;

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
