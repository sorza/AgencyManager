using AgencyManager.Core.Models.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Models.Entities
{
    [TestClass]
    public class SaleTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void ReturnSuccessWhenSaleIsValid()
        {
            var sale = new Sale(0, 0, 800, 200);
            Assert.IsTrue(sale.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ReturnErrorWhenMoneyIsNegative()
        {
            var sale = new Sale(0, 0, -800, 200);
            Assert.IsFalse(sale.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ReturnErrorWhenDigitalIsNegative()
        {
            var sale = new Sale(0, 0, 800, -200);
            Assert.IsFalse(sale.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ReturnErrorWhenTotalIsNot1000()
        {
            var sale = new Sale(0, 0, 801, 200);            
            Assert.AreNotEqual(1000, sale.Total);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ReturnSuccessWhenTotalIs1000()
        {
            var sale = new Sale(0, 0, 800, 200);            
            Assert.AreEqual(1000, sale.Total);
        }      
    }
}