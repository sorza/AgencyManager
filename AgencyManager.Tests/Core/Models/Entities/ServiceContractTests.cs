using AgencyManager.Core.Enums;
using AgencyManager.Core.Models.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Models.Entities
{
    [TestClass]
    public class ServiceContractTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenContractIsValid()
        {
            var serviceContract = new ServiceContract(1,1, EServiceType.Ticket, 15, DateTime.Now);
            Assert.IsTrue(serviceContract.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenComissionInLowerThan1()
        {
            var serviceContract = new ServiceContract(1,1, EServiceType.Ticket, 0, DateTime.Now);
            Assert.IsFalse(serviceContract.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenComissionInGreaterThan50()
        {
            var serviceContract = new ServiceContract(1,1, EServiceType.Ticket, 51, DateTime.Now);
            Assert.IsFalse(serviceContract.IsValid);
        }
    }
}