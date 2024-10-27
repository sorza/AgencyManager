using AgencyManager.Core.Requests.VirtualSale;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Requests.VirtualSale
{
    [TestClass]
    public class CreateVirtualSaleRequestTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenVirtualSaleIsValidWithoutObservation()
        {
            var request = new CreateVirtualSaleRequest
            {
                UserId = "teste@teste.com",
                CashId = Guid.NewGuid(),
                CompanyId = Guid.NewGuid(),
                OrignId = Guid.NewGuid(),
                DestinationId = Guid.NewGuid(),
                Amount = 120
            };

            request.Validate();

            Assert.IsTrue(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenVirtualSaleIsValidWithObservation()
        {
            var request = new CreateVirtualSaleRequest
            {
                UserId = "teste@teste.com",
                CashId = Guid.NewGuid(),
                CompanyId = Guid.NewGuid(),
                OrignId = Guid.NewGuid(),
                DestinationId = Guid.NewGuid(),
                Amount = 120,
                Paid = false,
                Observation = "Vai pagar na próxima segunda"
            };

            request.Validate();

            Assert.IsTrue(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCashIdIsEmpty()
        {
            var request = new CreateVirtualSaleRequest
            {
                UserId = "teste@teste.com",                
                CompanyId = Guid.NewGuid(),
                OrignId = Guid.NewGuid(),
                DestinationId = Guid.NewGuid(),
                Amount = 120,
            };

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCompanyIdIsEmpty()
        {
            var request = new CreateVirtualSaleRequest
            {
                UserId = "teste@teste.com",                
                CashId = Guid.NewGuid(),
                OrignId = Guid.NewGuid(),
                DestinationId = Guid.NewGuid(),
                Amount = 120
            };

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenOrignIdIsEmpty()
        {
            var request = new CreateVirtualSaleRequest
            {
                UserId = "teste@teste.com",                
                CashId = Guid.NewGuid(),
                CompanyId = Guid.NewGuid(),
                DestinationId = Guid.NewGuid(),
                Amount = 120
            };

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenDestinationIdIsEmpty()
        {
            var request = new CreateVirtualSaleRequest
            {
                UserId = "teste@teste.com",                
                CashId = Guid.NewGuid(),
                CompanyId = Guid.NewGuid(),
                OrignId = Guid.NewGuid(),
                Amount = 120               
            };

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenAmountIsLowerOrEqualsThanZero()
        {
            var request = new CreateVirtualSaleRequest
            {
                UserId = "teste@teste.com",                
                CashId = Guid.NewGuid(),
                CompanyId = Guid.NewGuid(),
                OrignId = Guid.NewGuid(),
                DestinationId = Guid.NewGuid(),
                Amount = -100
            };

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenObservationIsGreaterThan100()
        {
            var request = new CreateVirtualSaleRequest
            {
                UserId = "teste@teste.com",                
                CashId = Guid.NewGuid(),
                CompanyId = Guid.NewGuid(),
                OrignId = Guid.NewGuid(),
                DestinationId = Guid.NewGuid(),
                Amount = 100,
                Paid = false,
                Observation = "Esta observação certamente tem mais de 100 caracteres expressos um campo de array de char chamado string dentro de uma classe de teste"
            };

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }        
    }
}