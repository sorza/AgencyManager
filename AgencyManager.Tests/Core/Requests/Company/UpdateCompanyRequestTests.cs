using AgencyManager.Core.Requests.Address;
using AgencyManager.Core.Requests.Company;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Requests.Company
{
    [TestClass]
    public class UpdateCompanyRequestTests
    {
        private static readonly UpdateAddressRequest _address = new()
        {
            ZipCode = "13477696", Street = "Rua Um", Number = "12345", Neighborhood = "Centro", City = "Araras", State = "SP",Complement = "Ap 500"
        };
        
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenCompanyIsValid()
        {
            var request = new UpdateCompanyRequest
            {                
                Id = 1,
                Name = "EMPRESA GONTIJO DE TRANSPORTES S/A",
                TradingName = "GONTIJO",
                Cnpj = "31521273000105",
                Address = _address,
                Contacts = []
            };

            request.Validate();

            Assert.IsTrue(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenIdIsEmpty()
        {
            var request = new UpdateCompanyRequest
            {                               
                Name = null!,
                TradingName = "GONTIJO",
                Cnpj = "31521273000105",
                Address = _address,
                Contacts = []
            };
           
            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNameIsNull()
        {
            var request = new UpdateCompanyRequest
            {                
                Id = 1,
                Name = null!,
                TradingName = "GONTIJO",
                Cnpj = "31521273000105",
                Address = _address,
                Contacts = []
            };
           
            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNameIsEmpty()
        {
           var request = new UpdateCompanyRequest
            {          
                Id = 1,      
                Name = "",
                TradingName = "GONTIJO",
                Cnpj = "31521273000105",
                Address = _address,
                Contacts = []
            };
           
            request.Validate();
            
            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNameIsGreaterThan60Characteres()
        {
            var request = new UpdateCompanyRequest
            {       
                Id = 1,         
                Name = "EMPRESA GONTIJO EMPRESA GONTIJO EMPRESA GONTIJO EMPRESA GONTIJO EMPRESA GONTIJO EMPRESA GONTIJO",
                TradingName = "GONTIJO",
                Cnpj = "31521273000105",
                Address = _address,
                Contacts = []
            };
           
            request.Validate();
            
            Assert.IsFalse(request.IsValid);          
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenTradingNameIsNull()
        {
            var request = new UpdateCompanyRequest
            {       
                Id = 1,         
                Name = "EMPRESA GONTIJO DE TRANSPORTES S/A",
                TradingName = null!,
                Cnpj = "31521273000105",
                Address = _address,
                Contacts = []
            };

             request.Validate();
            
            Assert.IsFalse(request.IsValid);               
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenTradingNameIsEmpty()
        {
            var request = new UpdateCompanyRequest
            {       
                Id = 1,         
                Name = "EMPRESA GONTIJO DE TRANSPORTES S/A",
                TradingName = string.Empty,
                Cnpj = "31521273000105",
                Address = _address,
                Contacts = []
            };

             request.Validate();
            
            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenTradingNameIsGreaterThan60Characteres()
        {
            var request = new UpdateCompanyRequest
            {      
                Id = 1,          
                Name = "EMPRESA GONTIJO DE TRANSPORTES S/A",
                TradingName = "EMPRESA GONTIJO EMPRESA GONTIJO EMPRESA GONTIJO EMPRESA GONTIJO EMPRESA GONTIJO",
                Cnpj = "31521273000105",
                Address = _address,
                Contacts = []
            };

             request.Validate();
            
            Assert.IsFalse(request.IsValid);           
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCnpjIsLowerThan14Characteres()
        {
            var request = new UpdateCompanyRequest
            {      
                Id = 1,          
                Name = "EMPRESA GONTIJO DE TRANSPORTES S/A",
                TradingName = "EMPRESA GONTIJO",
                Cnpj = "3152127300010",
                Address = _address,
                Contacts = []
            };

             request.Validate();
            
            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCnpjIsGreaterThan14Characteres()
        {
            var request = new UpdateCompanyRequest
            {       
                Id = 1,         
                Name = "EMPRESA GONTIJO DE TRANSPORTES S/A",
                TradingName = "EMPRESA GONTIJO",
                Cnpj = "315212730001050",
                Address = _address,
                Contacts = []
            };

             request.Validate();
            
            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCnpjIsNotNumeric()
        {
            var request = new UpdateCompanyRequest
            {       
                Id = 1,         
                Name = "EMPRESA GONTIJO DE TRANSPORTES S/A",
                TradingName = "EMPRESA GONTIJO",
                Cnpj = "31521273000A",
                Address = _address,
                Contacts = []
            };

             request.Validate();
            
            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenAddressIsNull()
        {
             var request = new UpdateCompanyRequest
            {        
                Id = 1,        
                Name = "EMPRESA GONTIJO DE TRANSPORTES S/A",
                TradingName = "EMPRESA GONTIJO",
                Cnpj = "3152127300010",
                Address = null!,
                Contacts = []
            };

             request.Validate(); 
        }   
    }
}