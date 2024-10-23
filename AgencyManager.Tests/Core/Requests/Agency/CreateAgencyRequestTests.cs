using AgencyManager.Core.Requests.Address;
using AgencyManager.Core.Requests.Agency;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Requests.Agency
{
    [TestClass]
    public class CreateAgencyRequestTests
    {
        private static readonly CreateAddressRequest _address = new CreateAddressRequest
        { 
            ZipCode = "13477696",
            Street = "Rua Um",
            Number = "12345",
            Neighborhood = "Centro",
            City = "Araras",
            State = "SP",
            Complement = "Apto 32"  
        };


        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenAgencyIsValid()
        {
            var request = new CreateAgencyRequest
            {
                Description = "AGENCIA",
                Cnpj = "31521273000105",
                Address = _address
            };            

            request.Validate();

            Assert.IsTrue(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenDescriptionIsEmpty()
        {
            var request = new CreateAgencyRequest
            {
                Description = string.Empty,
                Cnpj = "31521273000105",
                Address = _address
            };            

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenDescriptionIsGreaterThanSixthCharacteres()
        {
            var request = new CreateAgencyRequest
            {
                Description = "ABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJKL",
                Cnpj = "31521273000105",
                Address = _address
            };            

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenDescriptionIsLowerThanTwoCharacteres()
        {
            var request = new CreateAgencyRequest
            {
                Description = "A",
                Cnpj = "31521273000105",
                Address = _address
            };            

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }       

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCnpjIsNotOnlyNumeric()
        {
            var request = new CreateAgencyRequest
            {
                Description = "AGENCIA",
                Cnpj = "ASD98710DSA651",
                Address = _address
            };            

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCnpjLengthIsNotEqualsFourteen()
        {
            var request = new CreateAgencyRequest
            {
                Description = "AGENCIA",
                Cnpj = "0123456789101",
                Address = _address
            };            

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
         public void ShouldReturnErrorWhenCnpjIsEmpty()
        {
            var request = new CreateAgencyRequest
            {
                Description = "AGENCIA",
                Cnpj = string.Empty,
                Address = _address
            };            

            request.Validate();

            Assert.IsFalse(request.IsValid);           
        }      

        [TestMethod]
        [TestCategory("Domain")]
         public void ShouldReturnErrorWhenAddresIsNull()
        {
            var request = new CreateAgencyRequest
            {
                Description = "AGENCIA",
                Cnpj = "31521273000105",
                Address = null!
            };            

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
         public void ShouldReturnErrorWhenAddresIsInvalid()
        {
            var address = new CreateAddressRequest
            {
                City = "ARARAS",
                Complement = "AP 32",
                Neighborhood = "CENTRO",
                Number = "815",
                Street = "SANTA CRUZ",
                State = "MMG",
                ZipCode = "13477696",
            };

            var request = new CreateAgencyRequest
            {
                Description = "AGENCIA",
                Cnpj = "31521273000105",
                Address = address
            };            

            request.Validate();

            Assert.IsFalse(request.IsValid);            
        }   
    }
}