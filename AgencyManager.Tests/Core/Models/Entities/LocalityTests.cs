using AgencyManager.Core.Models.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Models
{
    [TestClass]
    public class LocalityTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenLocalityIsValid()
        {
            var locality = new Locality("Araras","SP");
            Assert.IsTrue(locality.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCityIsNull()
        {
            var locality = new Locality(null!,"SP");
            Assert.IsFalse(locality.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCityIsEmpty()
        {
            var locality = new Locality("","SP");
            Assert.IsFalse(locality.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCityIsLowerThan3Characteres()
        {
            var locality = new Locality("AB","SP");
            Assert.IsFalse(locality.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCityIsGreaterThan70Characteres()
        {
             var locality = new Locality("ALPINOPOLIS MIRIM DAS CRUZ DO PARDO BRANCO DO SUDOESTE PAULISTA E MINEIRO DAS TERRAS SELVAGENS DE MARACATU","SP");
            Assert.IsFalse(locality.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenStateIsNull()
        {
            var locality = new Locality("ARARAS",null!);
            Assert.IsFalse(locality.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenStateIsEmpty()
        {
            var locality = new Locality("ARARAS", string.Empty);
            Assert.IsFalse(locality.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenStateIsLowerThan2Characteres()
        {
            var locality = new Locality("ARARAS","S"!);
            Assert.IsFalse(locality.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenStateIsGreaterThan2Characteres()
        {
            var locality = new Locality("ARARAS","SSP"!);
            Assert.IsFalse(locality.IsValid);
        }
    }
}