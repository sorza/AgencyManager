using AgencyManager.Core.Requests.Cash;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Requests.Cash
{
    [TestClass]
    public class CreateCashRequestTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenCashIsValid()
        {
            var request = new CreateCashRequest
            {
                UserId = "teste@teste.com",
                Date =  DateTime.Now,
                StartValue = 100,
                EndValue = 150
            };

            request.Validate();

            Assert.IsTrue(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenEmailIsInvalid()
        {
            var request = new CreateCashRequest
            {
                UserId = "teste@teste",
                Date =  DateTime.Now,
                StartValue = 100,
                EndValue = 150
            };

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenDataIsFuture()
        {
            var request = new CreateCashRequest
            {
                UserId = "teste@teste.com",
                Date =  DateTime.Now.AddDays(1),
                StartValue = 100,
                EndValue = 150
            };

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenStartValueIsNegative()
        {
            var request = new CreateCashRequest
            {
                UserId = "teste@teste.com",
                Date =  DateTime.Now,
                StartValue = -50,
                EndValue = 150
            };

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenEndValueIsNegative()
        {
           var request = new CreateCashRequest
            {
                UserId = "teste@teste.com",
                Date =  DateTime.Now,
                StartValue = 50,
                EndValue = -150
            };

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }
    }
}