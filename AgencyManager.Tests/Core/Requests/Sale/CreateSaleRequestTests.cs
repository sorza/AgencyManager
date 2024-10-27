using AgencyManager.Core.Requests.Sale;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Requests.Sale
{
    [TestClass]
    public class CreateSaleRequestTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenSaleIsValid()
        {
           var request = new CreateSaleRequest
           {
                UserId = "teste@teste.com",
                CashId = Guid.NewGuid(),                
                CompanyId = Guid.NewGuid(),
                Money = 100,
                Digital = 500
           };

           request.Validate();

           Assert.IsTrue(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenUserIdIsInvalid()
        {
           var request = new CreateSaleRequest
           {
                UserId = "teste@teste",
                CashId = Guid.NewGuid(),                
                CompanyId = Guid.NewGuid(),
                Money = 100,
                Digital = 500
           };

           request.Validate();

           Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCashIdIsEmpty()
        {
           var request = new CreateSaleRequest
           {
                UserId = "teste@teste",
                CashId = Guid.Empty,              
                CompanyId = Guid.NewGuid(),
                Money = 100,
                Digital = 500
           };

           request.Validate();

           Assert.IsFalse(request.IsValid);
        }

         [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenComapnyIdIsEmpty()
        {
           var request = new CreateSaleRequest
           {
                UserId = "teste@teste",
                CashId =  Guid.NewGuid(),       
                CompanyId = Guid.Empty,
                Money = 100,
                Digital = 500
           };

           request.Validate();

           Assert.IsFalse(request.IsValid);
        }
    }
}