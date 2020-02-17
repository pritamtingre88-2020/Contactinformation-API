using ContactInformation.Entities;
using System.Collections.Generic;

namespace ContactInformation.DAL.Interface
{
    /// <summary>
    /// Interface that performs CRUD operations on Contact
    /// </summary>
    public interface IContactInformationDataManager
    {
        /// <summary>
        /// Get all contacts in the system
        /// </summary>
        /// <returns></returns>
        List<ContactDO> GetAllContacts();        

        /// <summary>
        /// Get Contact information for a single contact
        /// </summary>
        /// <param name="Id">Id of the contact to be retrived</param>
        /// <returns></returns>
        ContactDO GetContactById(int Id);        

        /// <summary>
        /// Insert contact.
        /// </summary>
        /// <param name="contact">Contact to be inserted</param>
        int InsertContact(ContactDO contact);

        /// <summary>
        /// Update contact
        /// </summary>
        /// <param name="contact">Contact to be updated</param>
        void UpdateContact(ContactDO contact);

        /// <summary>
        /// Delete contact
        /// </summary>
        /// <param name="Id">Id of te contact to be deleted</param>
        void DeleteContact(int Id);
    }
}
