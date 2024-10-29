using AgencyManager.Core.Enums;
using AgencyManager.Core.Requests.Transaction;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Requests.Transaction
{
    [TestClass]
    public class UpdateTransactionRequestTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenTransactionWithDescriptionIsValid()
        {
            var request = new UpdateTransactionRequest
            {
                Id = 1,
                Type = ETransactionType.Entry,
                Description = "Entrada de valores",
                Amount = 100,
                UserId = "teste@teste.com"
            };
            request.Validate();

            Assert.IsTrue(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenTransactionWithoutDescriptionIsValid()
        {
            var request = new UpdateTransactionRequest
            {
                Id = 1,
                Type = ETransactionType.Output,
                Amount = 100,
                UserId = "teste@teste.com"
            };

            request.Validate();

            Assert.IsTrue(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenTransactionWithoutType()
        {
            var request = new UpdateTransactionRequest
            {
                Id = 1,
                Amount = 100,
                UserId = "teste@teste.com"
            };

            request.Validate();

            Assert.IsTrue(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenIdIsEmpty()
        {
            var request = new UpdateTransactionRequest
            {
                Amount = 100,
                UserId = "teste@teste.com"
            };

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenAmountIsEqualsThanZero()
        {
            var request = new UpdateTransactionRequest
            {
                Id = 1,
                Amount = 0,
                UserId = "teste@teste.com"
            };

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenDescriptionLenghtIsGreaterThan100()
        {
            var request = new UpdateTransactionRequest
            {
                Id = 1,
                Amount = 100,
                Description = "Esta é uma descrição que com certeza possuirá mais de 100 caracteres, sem sobra de dúvidas, realmente é maior que 100",
                UserId = "teste@teste.com"
            };

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }
    }
}