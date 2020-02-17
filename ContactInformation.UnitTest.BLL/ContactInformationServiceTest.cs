using System;
using System.Collections.Generic;
using CalculationSummary.Common;
using ContactInformation.BLL;
using ContactInformation.DAL.Interface;
using ContactInformation.Entities;
using ContactInformation.Entities.BusinessObjects;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContactInformation.UnitTest.BLL
{
    [TestClass]
    public class ContactInformationServiceTest
    {

        private ContactInformationService service;
        private IContactInformationDataManager contactInformationDataManager;

        [TestInitialize]
        public void Initialize()
        {
            service = new ContactInformationService();
            contactInformationDataManager = A.Fake<IContactInformationDataManager>();
            service.ContactInformationDataManager = contactInformationDataManager;
        }

        [TestMethod]
        public void GetAllContacts_Success()
        {
            //Arrange
            A.CallTo(() => contactInformationDataManager.GetAllContacts()).Returns(GetContacts());

            //Assert
            var result = service.GetAllContacts();

            //Act
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetContactById_Success()
        {
            //Arrange
            A.CallTo(() => contactInformationDataManager.GetContactById(A<int>.Ignored)).Returns(GetContacts()[0]);

            //Assert
            var result = service.GetContactById(1);

            //Act
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
        }

        [TestMethod]
        public void InsertContact_Success()
        {
            //Arrange
            A.CallTo(() => contactInformationDataManager.InsertContact(A<ContactDO>.Ignored)).Returns(5);

            //Assert
            var result = service.InsertContact(new ContactBO { FirstName = "Test" });

            //Act
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void UpdateContact_Success()
        {
            //Arrange
            A.CallTo(() => contactInformationDataManager.GetContactById(A<int>.Ignored)).Returns(GetContacts()[0]);

            //Assert
            service.UpdateContact(new ContactBO { Id = 5, FirstName = "Test" });

        }

        [TestMethod]
        [ExpectedException(typeof(ContactNotFoundException))]
        public void UpdateContact_NotExistingContact()
        {
            //Arrange
            A.CallTo(() => contactInformationDataManager.GetContactById(A<int>.Ignored)).Returns(null);  

            //Assert
            service.UpdateContact(new ContactBO {Id=5, FirstName = "Test" });

        }

        [TestMethod]
        public void DelateContact_Success()
        {
            //Arrange
            A.CallTo(() => contactInformationDataManager.GetContactById(A<int>.Ignored)).Returns(GetContacts()[0]);

            //Assert
            service.DeleteContact(1);

        }

        private List<ContactDO> GetContacts()
        {
            return new List<ContactDO>
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
}
