using AgencyManager.Core.Enums;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Models.Entities.ValueObjects;
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
            contact.Id = 1;

            var contact2 = new Contact(EContactType.Phone, "1933527436", "pessoal");
            contact2.Id = 2;

            var contact3 = new Contact(EContactType.WhatsApp, "1933527436", "pessoal");
            contact3.Id = 3;
            
            agency.AddContact(contact);
            agency.AddContact(contact2);
            agency.AddContact(contact3);

            var contactUpdate = new Contact(EContactType.Email, "EMAIL-ALTERADO2@teste.com", "ALTERADO");
            contactUpdate.Id = 3;

            agency.UpdateContact(contactUpdate);
            
            Assert.AreEqual(true, agency.Contacts?.FirstOrDefault(x=>x.Id == 3)!.Equals(contactUpdate));
        }
    }
}