using AgencyManager.Core.Requests.Cash;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Requests.Cash
{
    [TestClass]
    public class UpdateCashRequestTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenCashIsValid()
        {
            var request = new UpdateCashRequest
            {
                Id = 1,
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
        public void ShouldReturnErrorWhenIdIsEmpty()
        {
            var request = new UpdateCashRequest
            {               
                UserId = "teste@teste.com",
                Date =  DateTime.Now,
                StartValue = 100,
                EndValue = 150
            };

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenEmailIsInvalid()
        {
            var request = new UpdateCashRequest
            {
                Id = 1,
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
            var request = new UpdateCashRequest
            {
                Id = 1,
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
            var request = new UpdateCashRequest
            {
                Id = 1,
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
           var request = new UpdateCashRequest
            {
                Id = 1,
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