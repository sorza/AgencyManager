using AgencyManager.Core.Requests.Address;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Requests.Address
{
    [TestClass]
    public class CreateAddressRequestTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenAddressIsValid()
        {
            var request = new CreateAddressRequest
            {
                ZipCode = "13477696",
                Street = "Rua Um",
                Neighborhood = "Centro",
                Number = "85",
                City = "Araras",
                State = "SP",
                Complement = "Apto 32"               
            };

            request.Validate();

            Assert.IsTrue(request.IsValid);
        }
        
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenZipCodeCharacteresIsLowerThanEightCaracteres()
        {
            var request = new CreateAddressRequest
            {
                ZipCode = "1347769",
                Street = "Rua Um",
                Neighborhood = "Centro",
                Number = "85",
                City = "Araras",
                State = "SP",
                Complement = "Apto 32"               
            };

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenZipCodeCharacteresIsGreaterThanEightCaracteres()
        {
            var request = new CreateAddressRequest
            {
                ZipCode = "134776920",
                Street = "Rua Um",
                Number = "815",
                Neighborhood = "Centro",
                City = "Araras",
                State = "SP",
                Complement = "Apto 32"
            };          

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenZipCodeIsNotNumeric()
        {
            var request = new CreateAddressRequest
            {
                ZipCode = "F347A6920",
                Street = "Rua Um",
                Neighborhood = "Centro",
                Number = "815",
                City = "Araras",
                State = "SP",
                Complement = "Apto 32"
            };          

           request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenStreetIsGreaterThan100Characteres()
        {
             var request = new CreateAddressRequest
            {
                ZipCode = "F347A6920",
                Street = "Rua Um Dois Tres Quatro Rua Um Dois Tres Quatro Rua Um Dois Tres Quatro Rua Um Dois Tres Quatro Rua Um Dois Tres Quatro Cinco",
                Neighborhood = "Centro",
                Number = "815",
                City = "Araras",
                State = "SP",
                Complement = "Apto 32"
            };          

           request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenStreetIsEmpty()
        {
            var request = new CreateAddressRequest
            {
                ZipCode = "F347A6920",
                Street = string.Empty,
                Neighborhood = "Centro",
                Number = "815",
                City = "Araras",
                State = "SP",
                Complement = "Apto 32"
            };          

            request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNumberIsNotNumeric()
        {
            var request = new CreateAddressRequest
            {
                ZipCode = "F347A6920",
                Street = "Rua Um",
                Number = "Dois",
                Neighborhood = "Centro",
                City = "Araras",
                State = "SP",
                Complement = "Apto 32"
            };          

           request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNumberIsGreaterThanSeven()
        {
           var request = new CreateAddressRequest
            {
                ZipCode = "F347A6920",
                Street = "Rua Um",
                Number = "12345678",
                Neighborhood = "Centro",
                City = "Araras",
                State = "SP",
                Complement = "Apto 32"
            }; 

           request.Validate();

            Assert.IsFalse(request.IsValid);
        }       

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNeighborhoodtIsGreaterThanSeventhCharacteres()
        {
            var request = new CreateAddressRequest
            {
                ZipCode = "F347A6920",
                Street = "Rua Um",
                Number = "Dois",
                Neighborhood = "Bairro Um Dois Tres Quatro Bairro Um Dois Tres Quatro Bairro Um Dois Tres Quatro Bairro Um Dois Tres Quatro Cinco", 
                City = "Araras",
                State = "SP",
                Complement = "Apto 32"
            };  

           request.Validate();

            Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNeighborhoodtIsLowerThanThreeCharacteres()
        {
            var request = new CreateAddressRequest
            {
                ZipCode = "F347A6920",
                Street = "Rua Um",
                Number = "Dois",
                Neighborhood = "Ba", 
                City = "Araras",
                State = "SP",
                Complement = "Apto 32"
            };  

           request.Validate();

           Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNeighborhoodIsEmpty()
        {
            var request = new CreateAddressRequest
            {
                ZipCode = "F347A6920",
                Street = "Rua Um",
                Number = "Dois",
                Neighborhood = string.Empty, 
                City = "Araras",
                State = "SP",
                Complement = "Apto 32"
            };  

           request.Validate();

           Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCityIsGreaterThanSeventhCharacteres()
        {
            var request = new CreateAddressRequest
            {
                ZipCode = "F347A6920",
                Street = "Rua Um",
                Number = "Dois",
                Neighborhood = "Centro", 
                City = "Cidade Um Dois Tres Quatro Bairro Um Dois Tres Quatro Bairro Um Dois Tres Quatro Bairro Um Dois Tres Quatro Cinco", 
                State = "SP",
                Complement = "Apto 32"
            };  

            request.Validate();

           Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCityIsLowerThanThreeCharacteres()
        {
            var request = new CreateAddressRequest
            {
                ZipCode = "F347A6920",
                Street = "Rua Um",
                Number = "Dois",
                Neighborhood = "Centro", 
                City = "Ci", 
                State = "SP",
                Complement = "Apto 32"
            };  

           request.Validate();

           Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCityIsEmpty()
        {
            var request = new CreateAddressRequest
            {
                ZipCode = "F347A6920",
                Street = "Rua Um",
                Number = "Dois",
                Neighborhood = "Centro", 
                City = string.Empty, 
                State = "SP",
                Complement = "Apto 32"
            };  

           request.Validate();

           Assert.IsFalse(request.IsValid);
        }


        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenStateIsEmpty()
        {
            var request = new CreateAddressRequest
            {
                ZipCode = "F347A6920",
                Street = "Rua Um",
                Number = "Dois",
                Neighborhood = "Centro", 
                City = "Araras", 
                State = string.Empty,
                Complement = "Apto 32"
            };  

           request.Validate();

           Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenStateIsLowerThanTwoCharacteres()
        {
            var request = new CreateAddressRequest
            {
                ZipCode = "F347A6920",
                Street = "Rua Um",
                Number = "Dois",
                Neighborhood = "Centro", 
                City = "Araras", 
                State = "S",
                Complement = "Apto 32"
            };  

           request.Validate();

           Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenStateIsGreaterThanTwoCharacteres()
        {
            var request = new CreateAddressRequest
            {
                ZipCode = "F347A6920",
                Street = "Rua Um",
                Number = "Dois",
                Neighborhood = "Centro", 
                City = "Araras", 
                State = "SSP",
                Complement = "Apto 32"
            };  

           request.Validate();

           Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenStateIsNotAlfabetic()
        {
           var request = new CreateAddressRequest
            {
                ZipCode = "F347A6920",
                Street = "Rua Um",
                Number = "Dois",
                Neighborhood = "Centro", 
                City = "Araras", 
                State = "S2",
                Complement = "Apto 32"
            };  

            request.Validate();

           Assert.IsFalse(request.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenComplementIsGreaterThanFifithCharacteres()
        {
            var request = new CreateAddressRequest
            {
                ZipCode = "F347A6920",
                Street = "Rua Um",
                Number = "Dois",
                Neighborhood = "Centro", 
                City = "Araras", 
                State = "SP",
                Complement = "Apto 32 dois Tres Quatro Apto 32 dois Tres Quatro Apto 32 dois Tres Quatro Apto 32 dois Tres Quatro"
            };  

            request.Validate();

           Assert.IsFalse(request.IsValid);
        }
    }
}