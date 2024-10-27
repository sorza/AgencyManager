using AgencyManager.Core.Enums;
using AgencyManager.Core.Requests.Transaction;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Requests.Transaction
{
    [TestClass]
    public class CreateTransactionRequestTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenTransactionWithDescriptionIsValid()
        {
            var request = new CreateTransactionRequest
            {
                CashId = Guid.NewGuid(),
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
            var request = new CreateTransactionRequest
            {
                CashId = Guid.NewGuid(),
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
            var request = new CreateTransactionRequest
            {
                CashId = Guid.NewGuid(),
                Amount = 100,
                UserId = "teste@teste.com"
            };

            request.Validate();

            Assert.IsTrue(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCashIdIsEmpty()
        {
            var request = new CreateTransactionRequest
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
            var request = new CreateTransactionRequest
            {
                CashId = Guid.NewGuid(),
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
            var request = new CreateTransactionRequest
            {
                CashId = Guid.NewGuid(),
                Amount = 100,
                Description = "Esta é uma descrição que com certeza possui mais de 100 caracteres, sem sombra de dúvidas, realmente é maior que 100",
                UserId = "teste@teste.com"
            };

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }
    }
}