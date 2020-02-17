using CalculationSummary.Common;
using ContactInformation.BLL.Interface;
using ContactInformation.DAL.Interface;
using ContactInformation.Entities.BusinessObjects;
using ContactInformation.Utilities;
using System;
using System.Collections.Generic;

namespace ContactInformation.BLL
{
    public class ContactInformationService : IContactInformationService
    {
        public IContactInformationDataManager ContactInformationDataManager { get; set; }

        /// <summary>
        /// Get all contacts in the system
        /// </summary>
        /// <returns></returns>
        public List<ContactBO> GetAllContacts()
        {
            var contacts = ContactInformationDataManager.GetAllContacts();
            return ContactConverter.FromDOToBOList(contacts);
        }

        /// <summary>
        /// Get Contact information for a single contact
        /// </summary>
        /// <param name="Id">Id of the contact to be retrived</param>
        /// <returns></returns>
        public ContactBO GetContactById(int Id)
        {
            var contact = ContactInformationDataManager.GetContactById(Id);
            
            return ContactConverter.FromDOToBO(contact);
        }

        /// <summary>
        /// Insert contact.
        /// </summary>
        /// <param name="contact">Contact to be inserted</param>
        public int InsertContact(ContactBO contact)
        {
            var contactDO = ContactConverter.FromBOToDO(contact);
            var contactId = ContactInformationDataManager.InsertContact(contactDO);
            return contactId;
        }

        /// <summary>
        /// Update contact
        /// </summary>
        /// <param name="contact">Contact to be updated</param>
        public void UpdateContact(ContactBO contact)
        {
           if (!ContactExists(contact.Id))
                throw new ContactNotFoundException();

            var contactDO = ContactConverter.FromBOToDO(contact);
            ContactInformationDataManager.UpdateContact(contactDO);
        }

        /// <summary>
        /// Delete contact
        /// </summary>
        /// <param name="Id">Id of te contact to be deleted</param>
        public void DeleteContact(int Id)
        {
            if (!ContactExists(Id))
                return;

            ContactInformationDataManager.DeleteContact(Id);
        }

        private bool ContactExists(int Id)
        {
            var existingcontact = ContactInformationDataManager.GetContactById(Id);
            return existingcontact != null;
        }
    }
}
