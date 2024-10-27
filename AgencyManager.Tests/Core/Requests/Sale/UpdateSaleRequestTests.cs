using AgencyManager.Core.Requests.Sale;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Requests.Sale
{
    [TestClass]
    public class UpdateSaleRequestTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenSaleIsValid()
        {
           var request = new UpdateSaleRequest
           {
                Id = Guid.NewGuid(),
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
        public void ShouldReturnErrorWhenIdIsEmpty()
        {
           var request = new UpdateSaleRequest
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
        public void ShouldReturnErrorWhenUserIdIsInvalid()
        {
           var request = new UpdateSaleRequest
           {
                Id = Guid.NewGuid(),
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
           var request = new UpdateSaleRequest
           {    
                Id = Guid.NewGuid(),
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
           var request = new UpdateSaleRequest
           {
                Id = Guid.NewGuid(),
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