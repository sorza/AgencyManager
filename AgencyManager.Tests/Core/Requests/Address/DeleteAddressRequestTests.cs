using AgencyManager.Core.Requests.Address;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Requests.Address
{
    [TestClass]
    public class DeleteAddressRequestTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldBeValidWhenIdIsGreaterThanZero()
        {
            var request = new DeleteAddressRequest{ Id = 1};

            request.Validate();

            Assert.IsTrue(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldBeInValidWhenIdIsZeroOrLess()
        {
            var request = new DeleteAddressRequest{ Id = 0};

            request.Validate();

            Assert.IsFalse(request.IsValid);
            Assert.AreEqual(1, request.Notifications.Count);
        }
    }
}