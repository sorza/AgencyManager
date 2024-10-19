using AgencyManager.Core.Enums;
using AgencyManager.Core.Models.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Models.Entities
{
    [TestClass]
    public class ContactTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenPhoneIsInvalid()
        {
            var contact = new Contact(EContactType.Phone,"199977373a","Pessoal");
            Assert.IsFalse(contact.Validate());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenPhoneIsValid()
        {
            var contact = new Contact(EContactType.Phone,"1933527436","Pessoal");
            Assert.IsTrue(contact.Validate());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCellPhoneIsInvalid()
        {
            var contact = new Contact(EContactType.CellPhone,"199977373a","Pessoal");
            Assert.IsFalse(contact.Validate());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenCellPhoneIsValid()
        {
            var contact = new Contact(EContactType.CellPhone,"19997737436","Pessoal");
            Assert.IsTrue(contact.Validate());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenEmailAddressIsInvalid()
        {
            var contact = new Contact(EContactType.Email,"teste@teste","Pessoal");
            Assert.IsFalse(contact.Validate());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenEmailAddresslIsValid()
        {
            var contact = new Contact(EContactType.Email,"teste@teste.com","Pessoal");
            Assert.IsTrue(contact.Validate());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenWhatsAppIsInvalid()
        {
            var contact = new Contact(EContactType.WhatsApp,"teste@teste","Pessoal");
            Assert.IsFalse(contact.Validate());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenWhatsAppIsValid()
        {
            var contact = new Contact(EContactType.WhatsApp,"19999998888","Pessoal");
            Assert.IsTrue(contact.Validate());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenContactDescriptionIsEmpty()
        {
            var contact = new Contact(EContactType.Phone, string.Empty,"Pessoal");
            Assert.IsFalse(contact.IsValid);           
        }
        
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenContactDescriptionIsLowerThanSevenChatacteres()
        {
            var contact = new Contact(EContactType.Phone, "123456","Pessoal");
            Assert.IsFalse(contact.IsValid);           
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenContactDescriptionIsGreaterThanSeventyChatacteres()
        {
            var contact = new Contact(EContactType.Phone,
                                 "12345678901234567890123456789012345678901234567890123456789012345678901",
                                 "Pessoal");
            Assert.IsFalse(contact.IsValid);           
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenContactDepartamentIsEmpty()
        {
            var contact = new Contact(EContactType.Phone, "1933527436", string.Empty);
            Assert.IsFalse(contact.IsValid);           
        }
        
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenContactDepartamentIsLowerThanTwoChatacteres()
        {
            var contact = new Contact(EContactType.Phone, "A","Pessoal");
            Assert.IsFalse(contact.IsValid);           
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenContactDepartamentIsGreaterThanSeventyChatacteres()
        {
            var contact = new Contact(EContactType.Phone,
                                 "12345678901234567890123456789012345678901234567890123456789012345678901",
                                 "Pessoal");
            Assert.IsFalse(contact.IsValid);           
        }
    }
}