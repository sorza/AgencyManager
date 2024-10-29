using AgencyManager.Core.Requests.Address;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Requests.Employee;
using AgencyManager.Core.Requests.Position;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Requests.Employee
{
    [TestClass]
    public class CreateEmployeeTests
    {
        private static readonly CreateAddressRequest _address = new CreateAddressRequest
        {
            ZipCode = "13477696",
            Street = "Rua Um",
            Number = "12345",
            Neighborhood = "Centro",
            City="Araras",
            State = "SP",
            Complement = "Apto 50"
        };  
        private static readonly CreateAgencyRequest _agency = new CreateAgencyRequest
        {
            Description = "AGENCIA TESTE",
            Cnpj = "31521273000105",
            Address = _address            
        };       
        private static readonly CreatePositionRequest _position = new CreatePositionRequest
        {
            Description = "VENDEDOR",
            Responsabilities = "VENDER PASSAGENS E ENCOMENDAS",
            Salary = 2000,
            AgencyId = 1
        }; 
                     
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccesWhenEmplooyIsValid()
        {            
            CreateEmployeeRequest _request = new()
            {
                Name = "Alexandre Zordan",
                Cpf = "45057894897",
                Rg = "409830318",
                BirthDay = new DateTime(1995,09,23),
                Address = _address,
                PositionId = 1,
                AgencyId = 1
            };

            _request.Validate();

            Assert.IsTrue(_request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNameIsNull()
        {
            CreateEmployeeRequest _request = new()
            {
                Name = null!,
                Cpf = "45057894897",
                Rg = "409830318",
                BirthDay = new DateTime(1995,09,23),
                Address = _address,
                PositionId = 1,
                AgencyId = 1
            };

            _request.Validate();

            Assert.IsFalse(_request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNameIsEmpty()
        {
           CreateEmployeeRequest _request = new()
            {
                Name = string.Empty,
                Cpf = "45057894897",
                Rg = "409830318",
                BirthDay = new DateTime(1995,09,23),
                Address = _address,
                PositionId = 1,
                AgencyId = 1
            };

            _request.Validate();

            Assert.IsFalse(_request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNameIsLowerThan5Characteres()
        {
           CreateEmployeeRequest _request = new()
            {
                Name = "Caio"!,
                Cpf = "45057894897",
                Rg = "409830318",
                BirthDay = new DateTime(1995,09,23),
                Address = _address,
                PositionId = 1,
                AgencyId = 1
            };

            _request.Validate();

            Assert.IsFalse(_request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNameGreaterThan100Characteres()
        {
            CreateEmployeeRequest _request = new()
            {
                Name = "ALEXANDRE LUIS RAMOS DA SILVA JUNIOR JORDANO CAMARGO SOARES BENTO SOARES OLIVEIRA DE PADUA ARANTES DO NASCIMENTO RUFINO",
                Cpf = "45057894897",
                Rg = "409830318",
                BirthDay = new DateTime(1995,09,23),
                Address = _address,
                PositionId = 1,
                AgencyId = 1
            };

            _request.Validate();

            Assert.IsFalse(_request.IsValid);            
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCPFIsEmpty()
        {
            CreateEmployeeRequest _request = new()
            {
                Name = "ALEXANDRE ZORDAN DURAES"!,
                Cpf = "",
                Rg = "409830318",
                BirthDay = new DateTime(1995,09,23),
                Address = _address,
                PositionId = 1,
                AgencyId = 1
            };

            _request.Validate();

            Assert.IsFalse(_request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCPFIsNull()
        {
            CreateEmployeeRequest _request = new()
            {
                Name = "ALEXANDRE ZORDAN DURAES"!,
                Cpf = null!,
                Rg = "409830318",
                BirthDay = new DateTime(1995,09,23),
                Address = _address,
                PositionId = 1,
                AgencyId = 1
            };

            _request.Validate();

            Assert.IsFalse(_request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCPFIsLowerThan11Characteres()
        {
            CreateEmployeeRequest _request = new()
            {
                Name = "ALEXANDRE ZORDAN DURAES"!,
                Cpf = "4505789489",
                Rg = "409830318",
                BirthDay = new DateTime(1995,09,23),
                Address = _address,
                PositionId = 1,
                AgencyId = 1
            };

            _request.Validate();

            Assert.IsFalse(_request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCPFIsGreaterThan11Characteres()
        {
           CreateEmployeeRequest _request = new()
            {
                Name = "ALEXANDRE ZORDAN DURAES"!,
                Cpf = "450578948977",
                Rg = "409830318",
                BirthDay = new DateTime(1995,09,23),
                Address = _address,
                PositionId = 1,
                AgencyId = 1
            };

            _request.Validate();

            Assert.IsFalse(_request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCPFIsNotNumeric()
        {
            CreateEmployeeRequest _request = new()
            {
                Name = "ALEXANDRE ZORDAN DURAES"!,
                Cpf = "4505789489A",
                Rg = "409830318",
                BirthDay = new DateTime(1995,09,23),
                Address = _address,
                PositionId = 1,
                AgencyId = 1
            };

            _request.Validate();

            Assert.IsFalse(_request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorAgeIsLowerThan16()
        {
            CreateEmployeeRequest _request = new()
            {
                Name = "ALEXANDRE ZORDAN DURAES"!,
                Cpf = "45057894897",
                Rg = "409830318",
                BirthDay = new DateTime(2009,09,23),
                Address = _address,
                PositionId = 1,
                AgencyId = 1
            };

            _request.Validate();

            Assert.IsFalse(_request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorAgeIsGreaterThan60()
        {
           CreateEmployeeRequest _request = new()
            {
                Name = "ALEXANDRE ZORDAN DURAES"!,
                Cpf = "45057894897",
                Rg = "409830318",
                BirthDay = new DateTime(1960,09,23),
                Address = _address,
                PositionId = 1,
                AgencyId = 1
            };

            _request.Validate();

            Assert.IsFalse(_request.IsValid);
        }
    }
}