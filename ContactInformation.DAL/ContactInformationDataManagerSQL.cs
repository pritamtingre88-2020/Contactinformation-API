using ContactInformation.DAL.Interface;
using ContactInformation.Entities;
using System;
using System.Collections.Generic;

namespace ContactInformation.DAL
{

    /*
     * This is another implemetation of IContactInformationDataManager.
     * We can simply inject this implementation of IContactInformationDataManager in our business layer
     * at a later point in time, when we are ready with our DB implementation
     */
    public class ContactInformationDataManagerSQL : IContactInformationDataManager
    {
        public void DeleteContact(int Id)
        {
            throw new NotImplementedException();
        }

        public List<ContactDO> GetAllContacts()
        {
            throw new NotImplementedException();
        }

        public ContactDO GetContactById(int Id)
        {
            throw new NotImplementedException();
        }

        public int InsertContact(ContactDO contact)
        {
            throw new NotImplementedException();
        }

        public void UpdateContact(ContactDO contact)
        {
            throw new NotImplementedException();
        }
    }
}
