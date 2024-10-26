using AgencyManager.Core.Enums;
using AgencyManager.Core.Requests.Contact;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Requests.Contact
{
    [TestClass]
    public class UpdateContactRequestTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenPhoneIsValid()
        {
            var request = new UpdateContactRequest
            {
                Id = Guid.NewGuid(),
                ContactType = EContactType.Phone,
                Description = "1933527436",
                Departament = "Guichê"                
            };
           
           request.Validate();
           Assert.IsTrue(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenIdIsEmpty()
        {
            var request = new UpdateContactRequest
            {                
                ContactType = EContactType.Phone,
                Description = "19335274360",
                Departament = "Guichê"                
            };
           
           request.Validate();
           Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenPhoneIsInvalid()
        {
            var request = new UpdateContactRequest
            {
                Id = Guid.NewGuid(),
                ContactType = EContactType.Phone,
                Description = "19335274360",
                Departament = "Guichê"                
            };
           
           request.Validate();
           Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCellPhoneIsInvalid()
        {
            var request = new UpdateContactRequest
            {
                Id = Guid.NewGuid(),
                ContactType = EContactType.CellPhone,
                Description = "1933527436",
                Departament = "Guichê"                
            };
           
           request.Validate();
           Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenCellPhoneIsValid()
        {
            var request = new UpdateContactRequest
            {
                Id = Guid.NewGuid(),
                ContactType = EContactType.CellPhone,
                Description = "19997737436",
                Departament = "Alexandre Pessoal"                
            };
           
           request.Validate();
          
           Assert.IsTrue(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenEmailAddressIsInvalid()
        {
            var request = new UpdateContactRequest
            {
                Id = Guid.NewGuid(),
                ContactType = EContactType.Email,
                Description = "teste@teste",
                Departament = "Guichê"                
            };
           
           request.Validate();
           Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenEmailAddresslIsValid()
        {
           var request = new UpdateContactRequest
            {
                Id = Guid.NewGuid(),
                ContactType = EContactType.Email,
                Description = "teste@teste.com.br",
                Departament = "Guichê"                
            };
           
           request.Validate();
           Assert.IsTrue(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenWhatsAppIsInvalid()
        {
            var request = new UpdateContactRequest
            {
                Id = Guid.NewGuid(),
                ContactType = EContactType.WhatsApp,
                Description = "teste@teste",
                Departament = "Guichê Whats"                
            };
           
           request.Validate();
           Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenWhatsAppIsValid()
        {
            var request = new UpdateContactRequest
            {
                Id = Guid.NewGuid(),
                ContactType = EContactType.WhatsApp,
                Description = "1997737436",
                Departament = "Guichê"                
            };
           
           request.Validate();
           Assert.IsTrue(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenContactDescriptionIsEmpty()
        {
            var request = new UpdateContactRequest
            {
                Id = Guid.NewGuid(),
                ContactType = EContactType.WhatsApp,
                Description = string.Empty,
                Departament = "Guichê"                
            };
           
           request.Validate();
           Assert.IsFalse(request.IsValid);       
        }
        
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenContactDescriptionIsLowerThanSevenChatacteres()
        {
            var request = new UpdateContactRequest
            {
                Id = Guid.NewGuid(),
                ContactType = EContactType.WhatsApp,
                Description = "123456",
                Departament = "Guichê"                
            };
           
           request.Validate();
           Assert.IsFalse(request.IsValid);          
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenEmailIsGreaterThanSeventyChatacteres()
        {
            var request = new UpdateContactRequest
            {
                Id = Guid.NewGuid(),
                ContactType = EContactType.Email,
                Description = "12345678901234567890123456789012345678901234567890123456789012345678901",
                Departament = "Guichê"                
            };
           
           request.Validate();
           Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenContactDepartamentIsEmpty()
        {
            var request = new UpdateContactRequest
            {
                Id = Guid.NewGuid(),
                ContactType = EContactType.WhatsApp,
                Description = "19998852083",
                Departament = string.Empty            
            };
           
           request.Validate();
           Assert.IsFalse(request.IsValid); 
        }
        
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenContactDepartamentIsLowerThanTwoChatacteres()
        {
            var request = new UpdateContactRequest
            {
                Id = Guid.NewGuid(),
                ContactType = EContactType.WhatsApp,
                Description = "19998852083",
                Departament = "A"            
            };
           
           request.Validate();
           Assert.IsFalse(request.IsValid);           
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenContactDepartamentIsGreaterThanSeventyChatacteres()
        {
            var request = new UpdateContactRequest
            {
                Id = Guid.NewGuid(),
                ContactType = EContactType.WhatsApp,
                Description = "19998852083",
                Departament = "12345678901234567890123456789012345678901234567890123456789012345678901"            
            };
           
           request.Validate();
           Assert.IsFalse(request.IsValid);     
        }
    }
}