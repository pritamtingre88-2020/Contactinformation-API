using CalculationSummary.Common;
using ContactInformation.BLL.Interface;
using ContactInformation.Entities.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ContactInformation.Controllers
{
    [RoutePrefix("api/v1/contact")]
    public class ContactController : ApiController
    {
        public IContactInformationService ContactInformationService { get; set; }

        /// <summary>
        /// Get all contacts in the system
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getallcontacts")]
        public IHttpActionResult GetAllContacts()
        {
            return Ok(ContactInformationService.GetAllContacts());
        }

        /// <summary>
        /// Get Contact information for a single contact
        /// </summary>
        /// <param name="Id">Id of the contact to be retrived</param>
        /// <returns></returns>
        [HttpGet]
        [Route("getcontact")]
        public IHttpActionResult GetContactById(int Id)
        {
            if (Id <= 0)
                return BadRequest("Invalid Id");

            var contact = ContactInformationService.GetContactById(Id);

            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        /// <summary>
        /// Insert contact.
        /// </summary>
        /// <param name="contact">Contact to be inserted</param>
        [HttpPost]
        [Route("createcontact")]
        public IHttpActionResult CreateContact(ContactBO contact)
        {
            try
            {
                var contactId = ContactInformationService.InsertContact(contact);
                return Ok(contactId);
            }
            catch (InvalidContactException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update contact
        /// </summary>
        /// <param name="contact">Contact to be updated</param>
        [HttpPut]
        [Route("updatecontact")]
        public IHttpActionResult UpdateContact(ContactBO contact)
        {
            if (contact == null)
                return BadRequest("Contact cannot be null");
            try
            {
                ContactInformationService.UpdateContact(contact);
            }
            catch (ContactNotFoundException)
            {
                return NotFound();
            }
            catch (InvalidContactException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        /// <summary>
        /// Delete contact
        /// </summary>
        /// <param name="Id">Id of contact to be deleted</param>
        [HttpDelete]
        [Route("deletecontact")]
        public void DeleteContact(int Id)
        {
            ContactInformationService.DeleteContact(Id);
        }
    }
}
