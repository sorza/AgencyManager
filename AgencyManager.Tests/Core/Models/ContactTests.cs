using AgencyManager.Core.Enums;
using AgencyManager.Core.Models.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Models
{
    [TestClass]
    public class ContactTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenPhoneIsInvalid()
        {
            var contact = new Contact(EContactType.Phone,"199977373a","Pessoal");
            Assert.IsFalse(contact.Validate());
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenPhoneIsValid()
        {
            var contact = new Contact(EContactType.Phone,"1933527436","Pessoal");
            Assert.IsTrue(contact.Validate());
        }
        [TestMethod]
        public void ShouldReturnErrorWhenCellPhoneIsInvalid()
        {
            var contact = new Contact(EContactType.CellPhone,"199977373a","Pessoal");
            Assert.IsFalse(contact.Validate());
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCellPhoneIsValid()
        {
            var contact = new Contact(EContactType.CellPhone,"19997737436","Pessoal");
            Assert.IsTrue(contact.Validate());
        }

        [TestMethod]
        public void ShouldReturnErrorWhenEmailAddressIsInvalid()
        {
            var contact = new Contact(EContactType.Email,"teste@teste","Pessoal");
            Assert.IsFalse(contact.Validate());
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenEmailAddresslIsValid()
        {
            var contact = new Contact(EContactType.Email,"teste@teste.com","Pessoal");
            Assert.IsTrue(contact.Validate());
        }

        [TestMethod]
        public void ShouldReturnErrorWhenWhatsAppIsInvalid()
        {
            var contact = new Contact(EContactType.WhatsApp,"teste@teste","Pessoal");
            Assert.IsFalse(contact.Validate());
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenWhatsAppIsValid()
        {
            var contact = new Contact(EContactType.WhatsApp,"19999998888","Pessoal");
            Assert.IsTrue(contact.Validate());
        }
    }
}