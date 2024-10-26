using AgencyManager.Core.Enums;
using AgencyManager.Core.Requests.Address;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Requests.Contact;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Requests.Agency
{
    [TestClass]
    public class UpdateAgencyRequestTests
    {
         private static readonly UpdateAddressRequest _address = new UpdateAddressRequest
        { 
            ZipCode = "13477696",
            Street = "Rua Um",
            Number = "12345",
            Neighborhood = "Centro",
            City = "Araras",
            State = "SP",
            Complement = "Apto 32"  
        };
        private static readonly IList<UpdateContactRequest> _contacts = new List<UpdateContactRequest>
        {
            new UpdateContactRequest
            {
                ContactType = EContactType.Phone,
                Description = "1933527436",
                Departament = "Guichê"
            }
        };

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenAgencyIsValid()
        {
            var request = new UpdateAgencyRequest
            {
                Description = "AGENCIA",
                Cnpj = "31521273000105",
                Address = _address,      
                Contacts = _contacts          
            };            

            request.Validate();

            Assert.IsTrue(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenDescriptionIsEmpty()
        {
            var request = new UpdateAgencyRequest
            {
                Description = string.Empty,
                Cnpj = "31521273000105",
                Address = _address,      
                Contacts = _contacts 
            };            

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenDescriptionIsGreaterThanSixthCharacteres()
        {
            var request = new UpdateAgencyRequest
            {
                Description = "ABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJKL",
                Cnpj = "31521273000105",
                Address = _address,      
                Contacts = _contacts 
            };            

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenDescriptionIsLowerThanTwoCharacteres()
        {
            var request = new UpdateAgencyRequest
            {
                Description = "A",
                Cnpj = "31521273000105",
                Address = _address,      
                Contacts = _contacts 
            };            

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }       

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCnpjIsNotOnlyNumeric()
        {
            var request = new UpdateAgencyRequest
            {
                Description = "AGENCIA",
                Cnpj = "ASD98710DSA651",
                Address = _address,      
                Contacts = _contacts 
            };            

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCnpjLengthIsNotEqualsFourteen()
        {
            var request = new UpdateAgencyRequest
            {
                Description = "AGENCIA",
                Cnpj = "0123456789101",
                Address = _address,      
                Contacts = _contacts 
            };            

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
         public void ShouldReturnErrorWhenCnpjIsEmpty()
        {
            var request = new UpdateAgencyRequest
            {
                Description = "AGENCIA",
                Cnpj = string.Empty,
                Address = _address,      
                Contacts = _contacts 
            };            

            request.Validate();

            Assert.IsFalse(request.IsValid);           
        }      

        [TestMethod]
        [TestCategory("Domain")]
         public void ShouldReturnErrorWhenAddresIsNull()
        {
            var request = new UpdateAgencyRequest
            {
                Description = "AGENCIA",
                Cnpj = "31521273000105",
                Address = null!,      
                Contacts = _contacts 
            };            

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
         public void ShouldReturnErrorWhenAddresIsInvalid()
        {
            var address = new UpdateAddressRequest
            {
                City = "ARARAS",
                Complement = "AP 32",
                Neighborhood = "CENTRO",
                Number = "815",
                Street = "SANTA CRUZ",
                State = "MMG",
                ZipCode = "13477696",
            };

            var request = new UpdateAgencyRequest
            {
                Description = "AGENCIA",
                Cnpj = "31521273000105",
                Address = address,      
                Contacts = _contacts 
            };            

            request.Validate();

            Assert.IsFalse(request.IsValid);            
        }   

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenContactsIsEmpty()
        {
            var request = new UpdateAgencyRequest
            {
                Description = "AGENCIA",
                Cnpj = "31521273000105",
                Address = null!,      
                Contacts = []
            };            

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenContactsIsInvalid()
        {
            var request = new UpdateAgencyRequest
            {
                Description = "AGENCIA",
                Cnpj = "31521273000105",
                Address = _address,      
                Contacts =
                [
                    new UpdateContactRequest {ContactType = EContactType.Email, Description = "teste@teste.com", Departament = "Email da Agencia"},
                    new UpdateContactRequest {ContactType = EContactType.Phone, Description = "INVALIDO", Departament = "INVALIDO"},
                ]
            };            

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }
    }
}