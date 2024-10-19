using AgencyManager.Core.Models.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Models.Entities.ValueObjects
{
    [TestClass]
    public class AddressTests
    {

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenZipCodeCharacteresIsLowerThanEightCaracteres()
        {
            Address address = new("1347769", "Rua Um", "12345", "Centro", "Araras", "SP", "Apto 32"); 

            Assert.IsFalse(address.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenZipCodeCharacteresIsGreaterThanEightCaracteres()
        {
           Address address = new("13477691011", "Rua Um", "12345", "Centro", "Araras", "SP", "Apto 32"); 

            Assert.IsFalse(address.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenZipCodeIsNotNumeric()
        {
           Address address = new("ABCDEFGH", "Rua Um", "12345", "Centro", "Araras", "SP", "Apto 32"); 

            Assert.IsFalse(address.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenAddressIsValid()
        {
            Address address = new("13477696", "Rua Um", "12345", "Centro", "Araras", "SP", "Apto 32"); 

            Assert.IsTrue(address.IsValid);
        }
        
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenStreetIsGreaterThan100Characteres()
        {
            Address address = new("13477696", 
                                    "Rua Um Dois Tres Quatro Rua Um Dois Tres Quatro Rua Um Dois Tres Quatro Rua Um Dois Tres Quatro Rua Um Dois Tres Quatro Cinco",
                                    "12345", "Centro", "Araras", "SP", "Apto 32"); 

            Assert.IsFalse(address.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenStreetIsEmpty()
        {
            Address address = new("13477696", 
                                    string.Empty,
                                    "12345", "Centro", "Araras", "SP", "Apto 32"); 

            Assert.IsFalse(address.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNumberIsNotNumeric()
        {
           Address address = new("13477696", 
                                    "Rua Um",
                                    "1abc", "Centro", "Araras", "SP", "Apto 32"); 

            Assert.IsFalse(address.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNumberIsGreaterThanSeven()
        {
           Address address = new("13477696", 
                                    "Rua Um",
                                    "12345678", "Centro", "Araras", "SP", "Apto 32"); 

            Assert.IsFalse(address.IsValid);
        }       

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNeighborhoodtIsGreaterThanSeventhCharacteres()
        {
           Address address = new("13477696", 
                                    "Rua Um",
                                    "12345678", 
                                    "Bairro Um Dois Tres Quatro Bairro Um Dois Tres Quatro Bairro Um Dois Tres Quatro Bairro Um Dois Tres Quatro Cinco", 
                                    "Araras", "SP", "Apto 32"); 

            Assert.IsFalse(address.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNeighborhoodtIsLowerThanThreeCharacteres()
        {
            Address address = new("13477696", 
                                    "Rua Um",
                                    "12345678", 
                                    "Ba", 
                                    "Araras", "SP", "Apto 32"); 

            Assert.IsFalse(address.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNeighborhoodIsEmpty()
        {
            Address address = new("13477696", 
                                    "Rua Um",
                                    "12345678", 
                                    string.Empty, 
                                    "Araras", "SP", "Apto 32"); 

            Assert.IsFalse(address.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCityIsGreaterThanSeventhCharacteres()
        {
            Address address = new("13477696", 
                                    "Rua Um",
                                    "12345678",
                                    "Centro", 
                                    "Cidade Um Dois Tres Quatro Bairro Um Dois Tres Quatro Bairro Um Dois Tres Quatro Bairro Um Dois Tres Quatro Cinco", 
                                    "SP", "Apto 32"); 

            Assert.IsFalse(address.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCityIsLowerThanThreeCharacteres()
        {
            Address address = new("13477696", 
                                    "Rua Um",
                                    "12345678",
                                    "Centro", 
                                    "Ci", 
                                    "SP", "Apto 32"); 

            Assert.IsFalse(address.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCityIsEmpty()
        {
            Address address = new("13477696", 
                                    "Rua Um",
                                    "12345678",
                                    "Centro", 
                                    string.Empty, 
                                    "SP", "Apto 32"); 

            Assert.IsFalse(address.IsValid);
        }


        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenStateIsEmpty()
        {
            Address address = new("13477696", 
                                    "Rua Um",
                                    "12345678",
                                    "Centro", 
                                    "Araras",
                                    string.Empty, 
                                    "Apto 32"); 

            Assert.IsFalse(address.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenStateIsLowerThanTwoCharacteres()
        {
            Address address = new("13477696", 
                                    "Rua Um",
                                    "12345678",
                                    "Centro", 
                                    "Araras",
                                    "S", 
                                    "Apto 32"); 

            Assert.IsFalse(address.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenStateIsGreaterThanTwoCharacteres()
        {
            Address address = new("13477696", 
                                    "Rua Um",
                                    "12345678",
                                    "Centro", 
                                    "Araras",
                                    "SPP", 
                                    "Apto 32"); 
                                    
            Assert.IsFalse(address.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenStateIsNotAlfabetic()
        {
           Address address = new("13477696", 
                                    "Rua Um",
                                    "12345678",
                                    "Centro", 
                                    "Araras",
                                    "S2", 
                                    "Apto 32"); 
                                    
            Assert.IsFalse(address.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenComplementIsGreaterThanFifithCharacteres()
        {
            Address address = new("13477696", 
                                    "Rua Um",
                                    "12345678",
                                    "Centro", 
                                    "Araras",
                                    "S2", 
                                    "Apto 32 dois Tres Quatro Apto 32 dois Tres Quatro Apto 32 dois Tres Quatro Apto 32 dois Tres Quatro"); 
                                    
            Assert.IsFalse(address.IsValid);
        }
    }
}