using ContactInformation.Entities;
using ContactInformation.Entities.BusinessObjects;
using System.Collections.Generic;

namespace ContactInformation.Utilities
{
    public static class ContactConverter
    {
        public static ContactBO FromDOToBO(ContactDO contactDO)
        {
            if (contactDO == null)
                return null;

            return new ContactBO
            {
                Id = contactDO.Id,
                FirstName = contactDO.FirstName,
                LastName = contactDO.LastName,
                PhoneNumber = contactDO.PhoneNumber,
                Email = contactDO.Email,
                Status = contactDO.IsActive ? Constants.Active : Constants.Inactive
            };
        }

        public static List<ContactBO> FromDOToBOList(List<ContactDO> contactsDO)
        {
            if (contactsDO == null)
                return null;

            var contactsBO = new List<ContactBO>();
            foreach (var contactDO in contactsDO)
            {
                var contactBO = FromDOToBO(contactDO);
                if (contactBO != null)
                {
                    contactsBO.Add(contactBO);
                }
            }
            return contactsBO;
        }

        public static ContactDO FromBOToDO(ContactBO contactBO)
        {
            if (contactBO == null)
                return null;

            return new ContactDO
            {
                Id = contactBO.Id,
                FirstName = contactBO.FirstName,
                LastName = contactBO.LastName,
                PhoneNumber = contactBO.PhoneNumber,
                Email = contactBO.Email,
                IsActive = (!string.IsNullOrEmpty(contactBO.Status) && contactBO.Status.Equals(Constants.Active, System.StringComparison.InvariantCultureIgnoreCase)) ? true : false
            };
        }

        public static List<ContactDO> FromBOToDOList(List<ContactBO> contactsBO)
        {
            if (contactsBO == null)
                return null;

            var contactsDO = new List<ContactDO>();
            foreach (var contactBO in contactsBO)
            {
                var contactDO = FromBOToDO(contactBO);
                if (contactDO != null)
                {
                    contactsBO.Add(contactBO);
                }
            }
            return contactsDO;
        }
    }
}
