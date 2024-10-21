using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgencyManager.Core.Models.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Models.Entities
{
    [TestClass]
    public class CashTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenCashIsValid()
        {
            var cash = new Cash("teste@teste.com", DateTime.Now, 100, 150); 
            Assert.IsTrue(cash.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenEmailIsInvalid()
        {
           var cash = new Cash("teste@teste", DateTime.Now, 100, 150); 
            Assert.IsFalse(cash.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenDataIsFuture()
        {
           var cash = new Cash("teste@teste.com", DateTime.Now.AddDays(1), 100, 150); 
            Assert.IsFalse(cash.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenStartValueIsNegative()
        {
            var cash = new Cash("teste@teste.com", DateTime.Now, -100, 150); 
            Assert.IsFalse(cash.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenEndValueIsNegative()
        {
           var cash = new Cash("teste@teste.com", DateTime.Now, 100, -150); 
            Assert.IsFalse(cash.IsValid);
        }

    }
}