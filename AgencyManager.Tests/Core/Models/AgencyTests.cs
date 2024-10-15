using System.Reflection.PortableExecutable;
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
                                    [],"" );

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
            agency.AddContact(contact);
            var contact2 = new Contact(EContactType.Email, "teste2@teste.com", "profissional");
            var contact3 = new Contact(EContactType.Email, "teste2@teste.com", "profissional");
            
            agency.UpdateContact(0, contact2);
            Assert.AreEqual(contact3, agency.Contacts?.First());
        }
    }
}