using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgencyManager.Core.Enums;
using AgencyManager.Core.Models.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Models.Entities
{
    [TestClass]
    public class TransactionTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenTransactionIsValid()
        {
            var transaction = new Transaction(0,ETransactionType.Output, 500, "teste");
            Assert.IsTrue(transaction.IsValid);
        }       
    }
}