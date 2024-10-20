using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Models.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Models.Entities
{
    [TestClass]
    public class AgencyTests
    {    
        private static readonly Address _address = new("13477696", "Rua Um", "12345", "Centro", "Araras", "SP", "Apto 32");    

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenDescriptionIsEmpty()
        {
            Agency agency = new(string.Empty, "31521273000105", _address);

            Assert.IsFalse(agency.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenDescriptionIsGreaterThanSixthCharacteres()
        {
            Agency agency = new("ABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJKL",
                                 "31521273000105", _address); 

            Assert.IsFalse(agency.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenDescriptionIsLowerThanTwoCharacteres()
        {
            Agency agency = new("A","31521273000105", _address);
            
            Assert.IsFalse(agency.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenDescriptionIsValid()
        {
            Agency agency = new("AGENCIA","31521273000105", _address);
            
            Assert.IsTrue(agency.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCnpjIsNotOnlyNumeric()
        {
            Agency agency = new("AGENCIA","ASD98710DSA651", _address);
            
            Assert.IsFalse(agency.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCnpjLengthIsNotEqualsFourteen()
        {
            Agency agency = new("AGENCIA","0123456789101", _address);
            
            Assert.IsFalse(agency.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
         public void ShouldReturnErrorWhenCnpjIsEmpty()
        {
            Agency agency = new("AGENCIA",string.Empty, _address);
            
            Assert.IsFalse(agency.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
         public void ShouldReturnSuccessWhenCnpjIsValid()
        {
            Agency agency = new("AGENCIA","31521273000105", _address);
            
            Assert.IsTrue(agency.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
         public void ShouldReturnErrorWhenAddresIsNull()
        {
            Agency agency = new("AGENCIA","31521273000105", null!);
          
            Assert.IsFalse(agency.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
         public void ShouldReturnSuccessWhenAddresIsValid()
        {
            Agency agency = new("AGENCIA","31521273000105", _address);
          
            Assert.IsTrue(agency.IsValid);
        }           
    }
}

