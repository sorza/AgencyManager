using AgencyManager.Core.Enums;
using AgencyManager.Core.Requests.ContractService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Requests.ContractService
{
    [TestClass]
    public class CreateContractServiceRequestTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenContractIsValid()
        {
            var request = new CreateContractServiceRequest
            {
                AgencyId = Guid.NewGuid(),
                CompanyId = Guid.NewGuid(),
                ServiceType = EServiceType.Ticket,
                Comission = 15,
                StartDate = DateTime.Now
            };

            request.Validate();
            Assert.IsTrue(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenComissionInLowerThan1()
        {
            var request = new CreateContractServiceRequest
            {
                AgencyId = Guid.NewGuid(),
                CompanyId = Guid.NewGuid(),
                ServiceType = EServiceType.Ticket,
                Comission = 0,
                StartDate = DateTime.Now
            };

            request.Validate();
            Assert.IsFalse(request.IsValid);     
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenComissionInGreaterThan50()
        {
           var request = new CreateContractServiceRequest
            {
                AgencyId = Guid.NewGuid(),
                CompanyId = Guid.NewGuid(),
                ServiceType = EServiceType.Ticket,
                Comission = 51,
                StartDate = DateTime.Now
            };

            request.Validate();
            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenAgencyIsEmpty()
        {
           var request = new CreateContractServiceRequest
            {              
                CompanyId = Guid.NewGuid(),
                Comission = 15,
                StartDate = DateTime.Now,
                 ServiceType = EServiceType.Ticket,
                
            };

            request.Validate();
            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCompanyIsEmpty()
        {
           var request = new CreateContractServiceRequest
            {              
                AgencyId = Guid.NewGuid(),
                Comission = 15,
                StartDate = DateTime.Now,
                ServiceType = EServiceType.Ticket,
                
            };

            request.Validate();
            Assert.IsFalse(request.IsValid);
        }
    }
}