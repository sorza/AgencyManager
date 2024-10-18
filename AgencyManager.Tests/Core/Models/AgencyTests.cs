using AgencyManager.Core.Enums;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Models.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Models
{
    [TestClass]
    public class AgencyTests
    {    
        Agency agency = new Agency("Agencia 01",
                                   "31521273000105", 
                                    new Address("13477696", "Rua Um", "12345", "Centro", "Araras", "SP", "Apto 32"),
                                    [],[],"" );

        [TestMethod]
        public void ReturnErrorWhenAddAnInvalidContact()
        {          
           var contact = new Contact(EContactType.Email, "teste@teste", "pessoal");
           agency.AddContact(contact);

           Assert.AreEqual(0,agency.Contacts?.Count);
        }

        [TestMethod]
        public void ReturnSuccessWhenAddAValidContact()
        {           
           var contact = new Contact(EContactType.Email, "teste@teste.com", "pessoal");
           agency.AddContact(contact);

           Assert.AreEqual(1,agency.Contacts?.Count);
        }

        [TestMethod]
        public void ReturnSuccessWhenRemoveAContact()
        {          
           var contact = new Contact(EContactType.Email, "teste@teste.com", "pessoal");
           agency.AddContact(contact);
           agency.RemoveContact(contact);

           Assert.AreEqual(0,agency.Contacts?.Count);
        }

        [TestMethod]
        public void ReturnSuccesWhenUpdateAContact()
        {
            var contact = new Contact(EContactType.Email, "teste@teste.com", "pessoal");
            var contact2 = new Contact(EContactType.Phone, "1933527436", "pessoal");
            var contact3 = new Contact(EContactType.WhatsApp, "1933527436", "pessoal");

            agency.AddContact(contact);
            agency.AddContact(contact2);
            agency.AddContact(contact3);
        }
    }
}