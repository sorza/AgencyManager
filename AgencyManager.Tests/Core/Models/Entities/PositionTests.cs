using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Models.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Models.Entities
{
    [TestClass]
    public class PositionTests
    {
        private static readonly Address _address = new("13477696", "Rua Um", "12345", "Centro", "Araras", "SP", "Apto 32");
        private static readonly Agency _agency = new("AGENCIA","31521273000105", _address);

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenPositionIsValid()
        {
            var position = new Position("VENDEDOR", "VENDER PASSAGENS E ENCOMENDAS", 1000, _agency);
            Assert.IsTrue(position.IsValid);
        }

        
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenDescriptionIsEmpty()
        {
            var position = new Position(string.Empty, "VENDER PASSAGENS E ENCOMENDAS", 1000, _agency);
            Assert.IsFalse(position.IsValid);
        }

         [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenDescriptionIsNull()
        {
            var position = new Position(null!, "VENDER PASSAGENS E ENCOMENDAS", 1000, _agency);
            Assert.IsFalse(position.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenDescriptionIsLowerThanThreeCharacteres()
        {
            var position = new Position("AB", "VENDER PASSAGENS E ENCOMENDAS", 1000, _agency);
            Assert.IsFalse(position.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenDescriptionIsGreaterThan70Characteres()
        {
            var position = new Position("DESCRICAO DE TESTE UM DESCRICAO DE TESTE UM DESCRICAO DE TESTE UM DESCRICAO DE TESTE UM DESCRICAO DE TESTE UM DESCRICAO DE TESTE UM ",
                                 "VENDER PASSAGENS E ENCOMENDAS", 1000, _agency);
            Assert.IsFalse(position.IsValid);
        }

         [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenResponsabilitiesIsEmpty()
        {
            var position = new Position("VENDEDOR", string.Empty, 1000, _agency);
            Assert.IsFalse(position.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenResponsabilitiesIsNull()
        {
            var position = new Position("VENDEDOR", null!, 1000, _agency);
            Assert.IsFalse(position.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenResponsabilitiesIsLowerThan10Characteres()
        {
            var position = new Position("VENDEDOR", "VENDER", 1000, _agency);
            Assert.IsFalse(position.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenResponsabilitiesIsGreaterThan500Characteres()
        {
            var position = new Position("VENDEDOR",
                                 "Estas são as responsabilidades de um vendedor com mais de 500 caracteres Estas são as responsabilidades de um vendedor com mais de 500 caracteres Estas são as responsabilidades de um vendedor com mais de 500 caracteres Estas são as responsabilidades de um vendedor com mais de 500 caracteres Estas são as responsabilidades de um vendedor com mais de 500 caracteres Estas são as responsabilidades de um vendedor com mais de 500 caracteres Estas são as responsabilidades de um vendedor com mais de 500 caracteres Estas são as responsabilidades de um vendedor com mais de 500 caracteres Estas são as responsabilidades de um vendedor com mais de 500 caracteres Estas são as responsabilidades de um vendedor com mais de 500 caracteres",
                                  1000, _agency);
            Assert.IsFalse(position.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenSalaryIsZero()
        {
            var position = new Position("VENDEDOR",
                                 "VENDER PASSAGENS, HOTEIS, PACOTES E ENCOMENDAS",
                                 0, _agency);
            Assert.IsFalse(position.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenSalaryIsGreaterThan20000()
        {
            var position = new Position("VENDEDOR",
                                 "VENDER PASSAGENS, HOTEIS, PACOTES E ENCOMENDAS",
                                 20001, _agency);
            Assert.IsFalse(position.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenAgencyIsNull()
        {
            var position = new Position("VENDEDOR",
                                 "VENDER PASSAGENS, HOTEIS, PACOTES E ENCOMENDAS",
                                 2000, null!);
            Assert.IsFalse(position.IsValid);
        }
    }
}