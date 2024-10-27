using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgencyManager.Core.Requests.Address;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Requests.Employee;
using AgencyManager.Core.Requests.Position;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Requests.Employee
{
    [TestClass]
    public class UpdateEmployeeTests
    {
        private static readonly UpdateAddressRequest _address = new UpdateAddressRequest
        {
            ZipCode = "13477696",
            Street = "Rua Um",
            Number = "12345",
            Neighborhood = "Centro",
            City="Araras",
            State = "SP",
            Complement = "Apto 50"
        };  
        private static readonly UpdateAgencyRequest _agency = new UpdateAgencyRequest
        {
            Description = "AGENCIA TESTE",
            Cnpj = "31521273000105",
            Address = _address            
        };       
        private static readonly UpdatePositionRequest _position = new UpdatePositionRequest
        {
            Description = "VENDEDOR",
            Responsabilities = "VENDER PASSAGENS E ENCOMENDAS",
            Salary = 2000,
            AgencyId = Guid.NewGuid()
        }; 
                     
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccesWhenEmplooyIsValid()
        {            
            UpdateEmployeeRequest _request = new()
            {
                Id = Guid.NewGuid(),
                Name = "Alexandre Zordan",
                Cpf = "45057894897",
                Rg = "409830318",
                BirthDay = new DateTime(1995,09,23),
                Address = _address,
                PositionId = Guid.NewGuid(),
                AgencyId = Guid.NewGuid(),
            };

            _request.Validate();

            Assert.IsTrue(_request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenIdIsEmpty()
        {
            UpdateEmployeeRequest _request = new()
            {                                
                Name = "Alexandre Zordan"!,
                Cpf = "45057894897",
                Rg = "409830318",
                BirthDay = new DateTime(1995,09,23),
                Address = _address,
                PositionId = Guid.NewGuid(),
                AgencyId = Guid.NewGuid(),
            };

            _request.Validate();

            Assert.IsFalse(_request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNameIsNull()
        {
            UpdateEmployeeRequest _request = new()
            {
                Id = Guid.NewGuid(),
                Name = null!,
                Cpf = "45057894897",
                Rg = "409830318",
                BirthDay = new DateTime(1995,09,23),
                Address = _address,
                PositionId = Guid.NewGuid(),
                AgencyId = Guid.NewGuid(),
            };

            _request.Validate();

            Assert.IsFalse(_request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNameIsEmpty()
        {
           UpdateEmployeeRequest _request = new()
            {
                Id = Guid.NewGuid(),
                Name = string.Empty,
                Cpf = "45057894897",
                Rg = "409830318",
                BirthDay = new DateTime(1995,09,23),
                Address = _address,
                PositionId = Guid.NewGuid(),
                AgencyId = Guid.NewGuid()
            };

            _request.Validate();

            Assert.IsFalse(_request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNameIsLowerThan5Characteres()
        {
           UpdateEmployeeRequest _request = new()
            {
                Id = Guid.NewGuid(),
                Name = "Caio"!,
                Cpf = "45057894897",
                Rg = "409830318",
                BirthDay = new DateTime(1995,09,23),
                Address = _address,
                PositionId = Guid.NewGuid(),
                AgencyId =Guid.NewGuid()
            };

            _request.Validate();

            Assert.IsFalse(_request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNameGreaterThan100Characteres()
        {
            UpdateEmployeeRequest _request = new()
            {
                Id = Guid.NewGuid(),
                Name = "ALEXANDRE LUIS RAMOS DA SILVA JUNIOR JORDANO CAMARGO SOARES BENTO SOARES OLIVEIRA DE PADUA ARANTES DO NASCIMENTO RUFINO",
                Cpf = "45057894897",
                Rg = "409830318",
                BirthDay = new DateTime(1995,09,23),
                Address = _address,
                PositionId = Guid.NewGuid(),
                AgencyId = Guid.NewGuid()
            };

            _request.Validate();

            Assert.IsFalse(_request.IsValid);            
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCPFIsEmpty()
        {
            UpdateEmployeeRequest _request = new()
            {
                Id = Guid.NewGuid(),
                Name = "ALEXANDRE ZORDAN DURAES"!,
                Cpf = "",
                Rg = "409830318",
                BirthDay = new DateTime(1995,09,23),
                Address = _address,
                PositionId = Guid.NewGuid(),
                AgencyId = Guid.NewGuid()
            };

            _request.Validate();

            Assert.IsFalse(_request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCPFIsNull()
        {
            UpdateEmployeeRequest _request = new()
            {
                Id = Guid.NewGuid(),
                Name = "ALEXANDRE ZORDAN DURAES"!,
                Cpf = null!,
                Rg = "409830318",
                BirthDay = new DateTime(1995,09,23),
                Address = _address,
                PositionId = Guid.NewGuid(),
                AgencyId = Guid.NewGuid()
            };

            _request.Validate();

            Assert.IsFalse(_request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCPFIsLowerThan11Characteres()
        {
            UpdateEmployeeRequest _request = new()
            {
                Id = Guid.NewGuid(),
                Name = "ALEXANDRE ZORDAN DURAES"!,
                Cpf = "4505789489",
                Rg = "409830318",
                BirthDay = new DateTime(1995,09,23),
                Address = _address,
                PositionId = Guid.NewGuid(),
                AgencyId = Guid.NewGuid()
            };

            _request.Validate();

            Assert.IsFalse(_request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCPFIsGreaterThan11Characteres()
        {
           UpdateEmployeeRequest _request = new()
            {
                Id = Guid.NewGuid(),
                Name = "ALEXANDRE ZORDAN DURAES"!,
                Cpf = "450578948977",
                Rg = "409830318",
                BirthDay = new DateTime(1995,09,23),
                Address = _address,
                PositionId = Guid.NewGuid(),
                AgencyId = Guid.NewGuid()
            };

            _request.Validate();

            Assert.IsFalse(_request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCPFIsNotNumeric()
        {
            UpdateEmployeeRequest _request = new()
            {
                Id = Guid.NewGuid(),
                Name = "ALEXANDRE ZORDAN DURAES"!,
                Cpf = "4505789489A",
                Rg = "409830318",
                BirthDay = new DateTime(1995,09,23),
                Address = _address,
                PositionId = Guid.NewGuid(),
                AgencyId = Guid.NewGuid()
            };

            _request.Validate();

            Assert.IsFalse(_request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorAgeIsLowerThan16()
        {
            UpdateEmployeeRequest _request = new()
            {
                Id = Guid.NewGuid(),
                Name = "ALEXANDRE ZORDAN DURAES"!,
                Cpf = "45057894897",
                Rg = "409830318",
                BirthDay = new DateTime(2009,09,23),
                Address = _address,
                PositionId = Guid.NewGuid(),
                AgencyId = Guid.NewGuid()
            };

            _request.Validate();

            Assert.IsFalse(_request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorAgeIsGreaterThan60()
        {
           UpdateEmployeeRequest _request = new()
            {
                Id = Guid.NewGuid(),
                Name = "ALEXANDRE ZORDAN DURAES"!,
                Cpf = "45057894897",
                Rg = "409830318",
                BirthDay = new DateTime(1960,09,23),
                Address = _address,
                PositionId = Guid.NewGuid(),
                AgencyId = Guid.NewGuid()
            };

            _request.Validate();

            Assert.IsFalse(_request.IsValid);
        }
    }
}