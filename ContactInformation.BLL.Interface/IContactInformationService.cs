using ContactInformation.Entities.BusinessObjects;
using System.Collections.Generic;

namespace ContactInformation.BLL.Interface
{
    public interface IContactInformationService
    {
        /// <summary>
        /// Get all contacts in the system
        /// </summary>
        /// <returns></returns>
        List<ContactBO> GetAllContacts();

        /// <summary>
        /// Get Contact information for a single contact
        /// </summary>
        /// <param name="Id">Id of the contact to be retrived</param>
        /// <returns></returns>
        ContactBO GetContactById(int Id);

        /// <summary>
        /// Insert contact.
        /// </summary>
        /// <param name="contact">Contact to be inserted</param>
        int InsertContact(ContactBO contact);

        /// <summary>
        /// Update contact
        /// </summary>
        /// <param name="contact">Contact to be updated</param>
        void UpdateContact(ContactBO contact);

        /// <summary>
        /// Delete contact
        /// </summary>
        /// <param name="Id">Id of te contact to be deleted</param>
        void DeleteContact(int Id);
    }
}
