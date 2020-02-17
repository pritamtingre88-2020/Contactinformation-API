using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using CalculationSummary.Common;
using ContactInformation.BLL.Interface;
using ContactInformation.Controllers;
using ContactInformation.Entities;
using ContactInformation.Entities.BusinessObjects;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContactInformation.UnitTest.Api
{
    [TestClass]
    public class ContactControllerTest
    {
        private ContactController controller;
        private IContactInformationService contactInformationService;

        [TestInitialize]
        public void Initialize()
        {
            controller = new ContactController();
            contactInformationService = A.Fake<IContactInformationService>();
            controller.ContactInformationService = contactInformationService;
        }

        [TestMethod]
        public void GetAllContactsTest()
        {
            //Arrange
            A.CallTo(() => contactInformationService.GetAllContacts()).Returns(GetContacts());

            //Act
            var response = controller.GetAllContacts() as OkNegotiatedContentResult<List<ContactBO>>;

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content.Count, 2);
        }

        [TestMethod]
        public void GetContactById_ValidId_Succeds()
        {
            //Arrange
            A.CallTo(() => contactInformationService.GetContactById(1)).Returns(GetContacts()[0]);

            //Act
            var response = controller.GetContactById(1) as OkNegotiatedContentResult<ContactBO>;

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content.Id, 1);
        }

        [TestMethod]
        public void GetContactById_InvalidId_ReturnsBadRequest()
        {

            //Act
            var response = controller.GetContactById(-1) as BadRequestErrorMessageResult;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GetContactById_NonExistingId_ReturnsNotFound()
        {
            //Arrange
            A.CallTo(() => contactInformationService.GetContactById(5)).Returns(null);

            //Act
            var response = controller.GetContactById(5) as NotFoundResult;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void CreateContacts_Succeds()
        {
            //Arrange
            A.CallTo(() => contactInformationService.InsertContact(A<ContactBO>.Ignored)).Returns(5);

            //Act
            var response = controller.CreateContact(new ContactBO { Id = 5, FirstName = "Test" }) as OkNegotiatedContentResult<int>;

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content, 5);
        }

        [TestMethod]
        public void UpdateContact_Success()
        {

            //Act
            var response = controller.UpdateContact(new ContactBO { Id = 5, FirstName = "Test" }) as OkResult;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void UpdateContact_NullContact_ReturnsBadRequest()
        {

            //Act
            var response = controller.UpdateContact(null) as BadRequestErrorMessageResult;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void UpdateContact_NonExistingId_ReturnsNotFound()
        {
            //Arrange
            A.CallTo(() => contactInformationService.UpdateContact(A<ContactBO>.Ignored)).Throws(new ContactNotFoundException());

            //Act
            var response = controller.UpdateContact(new ContactBO { Id = 5, FirstName = "Test" }) as NotFoundResult;

            //Assert
            Assert.IsNotNull(response);
        }

        private List<ContactBO> GetContacts()
        {
            return new List<ContactBO>
             {
                    new ContactBO
                    {
                        Id = 1,
                        FirstName = "Pritam",
                        LastName = "Tingre",
                        Email ="pritam.tingre@exmple.com",
                        Status = Constants.Active,
                        PhoneNumber = "123-456-789"
                    },
                    new ContactBO
                    {
                        Id = 2,
                        FirstName = "Ravi",
                        LastName = "Srivastava",
                        Email ="ravi.srivastava@exmple.com",
                        Status = Constants.Active,
                        PhoneNumber = "123-456-555"
                    }

            };
        }
    }
}
