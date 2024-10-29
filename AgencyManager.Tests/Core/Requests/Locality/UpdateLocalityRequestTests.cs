using AgencyManager.Core.Requests.Locality;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Requests.Locality
{
    [TestClass]
    public class UpdateLocalityRequestTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenLocalityIsValid()
        {
            var request = new UpdateLocalityRequest
            {
                Id = 1,
                City = "Araras",
                State = "SP"
            };

            request.Validate();
            Assert.IsTrue(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenIdIsNull()
        {
            var request = new UpdateLocalityRequest
            {               
                City = "Araras",
                State = "SP"
            };

            request.Validate();
            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCityIsNull()
        {
            var request = new UpdateLocalityRequest
            {
                Id = 1,
                City = null!,
                State = "SP"
            };

            request.Validate();
            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCityIsEmpty()
        {
            var request = new UpdateLocalityRequest
            {
                Id = 1,
                City = string.Empty,
                State = "SP"
            };

            request.Validate();
            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCityIsLowerThan3Characteres()
        {
            var request = new UpdateLocalityRequest
            {
                Id = 1,
                City = "AB",
                State = "SP"
            };

            request.Validate();
            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCityIsGreaterThan70Characteres()
        {
            var request = new UpdateLocalityRequest
            {
                Id = 1,
                City = "ALPINOPOLIS MIRIM DAS CRUZ DO PARDO BRANCO DO SUDOESTE PAULISTA E MINEIRO DAS TERRAS SELVAGENS DE MARACATU",
                State = "SP"
            };

            request.Validate();
            Assert.IsFalse(request.IsValid);            
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenStateIsNull()
        {
            var request = new UpdateLocalityRequest
            {
                Id = 1,
                City = "Araras",
                State = null!
            };

            request.Validate();
            Assert.IsFalse(request.IsValid); 
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenStateIsEmpty()
        {
            var request = new UpdateLocalityRequest
            {
                Id = 1,
                City = "Araras",
                State = string.Empty
            };

            request.Validate();
            Assert.IsFalse(request.IsValid); 
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenStateIsLowerThan2Characteres()
        {
            var request = new UpdateLocalityRequest
            {
                Id = 1,
                City = "Araras",
                State = "A"
            };

            request.Validate();
            Assert.IsFalse(request.IsValid); 
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenStateIsGreaterThan2Characteres()
        {
           var request = new UpdateLocalityRequest
            {
                Id = 1,
                City = "Araras",
                State = "JAU"
            };

            request.Validate();
            Assert.IsFalse(request.IsValid); 
        }
    }
}