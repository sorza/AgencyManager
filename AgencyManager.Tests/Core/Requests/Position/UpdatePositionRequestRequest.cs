using AgencyManager.Core.Requests.Address;
using AgencyManager.Core.Requests.Position;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Requests.Position
{
    [TestClass]
    public class UpdatePositionRequestRequest
    {private static readonly UpdateAddressRequest _address = new UpdateAddressRequest
        {
            ZipCode = "13477696",
            Street = "Rua Um",
            Number = "12345",
            Neighborhood = "Centro",
            City="Araras",
            State = "SP",
            Complement = "Apto 50"
        };     

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenPositionIsValid()
        {
            var request = new UpdatePositionRequest
            {
                Id = 1,
                Description = "VENDEDOR",
                Responsabilities = "VENDER PASSAGENS E ENCOMENDAS",
                Salary = 2000,
                AgencyId = 1
            };

            request.Validate();

            Assert.IsTrue(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenIdIsEmpty()
        {
           var request = new UpdatePositionRequest
            {
                Description = "",
                Responsabilities = "VENDER PASSAGENS E ENCOMENDAS",
                Salary = 2000,
                AgencyId = 1
            };

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }
        
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenDescriptionIsEmpty()
        {
           var request = new UpdatePositionRequest
            {                
                Id = 1,
                Description = "",
                Responsabilities = "VENDER PASSAGENS E ENCOMENDAS",
                Salary = 2000,
                AgencyId = 1
            };

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenDescriptionIsNull()
        {
            var request = new UpdatePositionRequest
            {
                Id = 1,
                Description = null!,
                Responsabilities = "VENDER PASSAGENS E ENCOMENDAS",
                Salary = 2000,
                AgencyId = 1
            };

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenDescriptionIsLowerThanThreeCharacteres()
        {
            var request = new UpdatePositionRequest
            {
                Id = 1,
                Description = "CX",
                Responsabilities = "VENDER PASSAGENS E ENCOMENDAS",
                Salary = 2000,
                AgencyId = 1
            };

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenDescriptionIsGreaterThan70Characteres()
        {
            var request = new UpdatePositionRequest
            {
                Id = 1,
                Description = "",
                Responsabilities = "DESCRICAO DE TESTE UM DESCRICAO DE TESTE UM DESCRICAO DE TESTE UM DESCRICAO DE TESTE UM DESCRICAO DE TESTE UM DESCRICAO DE TESTE UM ",
                Salary = 2000,
                AgencyId = 1
            };

            request.Validate();
          
            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenResponsabilitiesIsEmpty()
        {
            var request = new UpdatePositionRequest
            {
                Id = 1,
                Description = "VENDEDOR",
                Responsabilities = "",
                Salary = 2000,
                AgencyId = 1
            };

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenResponsabilitiesIsNull()
        {
            var request = new UpdatePositionRequest
            {
                Id = 1,
                Description = "VENDEDOR",
                Responsabilities = null!,
                Salary = 2000,
                AgencyId = 1
            };

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenResponsabilitiesIsLowerThan10Characteres()
        {
            var request = new UpdatePositionRequest
            {
                Id = 1,
                Description = "VENDEDOR",
                Responsabilities = "RESPONSE",
                Salary = 2000,
                AgencyId = 1
            };

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenResponsabilitiesIsGreaterThan500Characteres()
        {
            var request = new UpdatePositionRequest
            {
                Id = 1,
                Description = "VENDEDOR",
                Responsabilities = "Estas são as responsabilidades de um vendedor com mais de 500 caracteres Estas são as responsabilidades de um vendedor com mais de 500 caracteres Estas são as responsabilidades de um vendedor com mais de 500 caracteres Estas são as responsabilidades de um vendedor com mais de 500 caracteres Estas são as responsabilidades de um vendedor com mais de 500 caracteres Estas são as responsabilidades de um vendedor com mais de 500 caracteres Estas são as responsabilidades de um vendedor com mais de 500 caracteres Estas são as responsabilidades de um vendedor com mais de 500 caracteres Estas são as responsabilidades de um vendedor com mais de 500 caracteres Estas são as responsabilidades de um vendedor com mais de 500 caracteres",
                Salary = 2000,
                AgencyId = 1
            };

            request.Validate();

            Assert.IsFalse(request.IsValid);           
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenSalaryIsZero()
        {
            var request = new UpdatePositionRequest
            {
                Id = 1,
                Description = "VENDEDOR",
                Responsabilities = "VENDER PASSAGENS E ENCOMENDAS",
                Salary = 0,
                AgencyId = 1
            };

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenSalaryIsGreaterThan20000()
        {
            var request = new UpdatePositionRequest
            {
                Id = 1,
                Description = "VENDEDOR",
                Responsabilities = "VENDER PASSAGENS E ENCOMENDAS",
                Salary = 20001,
                AgencyId = 1
            };

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }
    }
}