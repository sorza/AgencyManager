using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Models.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Models.Entities
{
    [TestClass]
    public class EmployeeTests
    {
        private static readonly Address _address = new("13477696", "Rua Um", "12345", "Centro", "Araras", "SP", "Apto 32");
        private static readonly Agency _agency = new("AGENCIA","31521273000105", _address);
        private static readonly Position _position = new("VENDEDOR", "VENDER PASSAGENS E ENCOMENDAS", 1000, _agency.Id);       
                     
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccesWhenEmplooyIsValid()
        {            
            Employee _employee = new("Alexandre Zordan","45057894897","409830318", new DateTime(1995,09,23), _address, 1,_position.Id);
            Assert.IsTrue(_employee.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNameIsNull()
        {
            Employee employee = new(null!,"45057894897","409830318", new DateTime(1995,09,23), _address, _agency.Id,_position.Id);
            Assert.IsFalse(employee.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNameIsEmpty()
        {
            Employee employee = new(string.Empty,"45057894897","409830318", new DateTime(1995,09,23), _address, _agency.Id,_position.Id);
            Assert.IsFalse(employee.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNameIsLowerThan5Characteres()
        {
           Employee employee = new("ALEX","45057894897","409830318", new DateTime(1995,09,23), _address, _agency.Id,_position.Id);
           Assert.IsFalse(employee.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNameGreaterThan100Characteres()
        {
            Employee employee = new("ALEXANDRE LUIS RAMOS DA SILVA JUNIOR JORDANO CAMARGO SOARES BENTO SOARES OLIVEIRA DE PADUA ARANTES DO NASCIMENTO RUFINO",
                                    "45057894897","409830318", new DateTime(1995,09,23), _address, _agency.Id,_position.Id);
           Assert.IsFalse(employee.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCPFIsEmpty()
        {
           Employee employee = new("ALEXANDRE ZORDAN","","409830318", new DateTime(1995,09,23), _address, _agency.Id,_position.Id);
           Assert.IsFalse(employee.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCPFIsNull()
        {
            Employee employee = new("ALEXANDRE ZORDAN",null!,"409830318", new DateTime(1995,09,23), _address, _agency.Id,_position.Id);
            Assert.IsFalse(employee.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCPFIsLowerThan11Characteres()
        {
            Employee employee = new("ALEXANDRE ZORDAN","4505789489","409830318", new DateTime(1995,09,23), _address, _agency.Id,_position.Id);
            Assert.IsFalse(employee.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCPFIsGreaterThan11Characteres()
        {
            Employee employee = new("ALEXANDRE ZORDAN","450578948970","409830318", new DateTime(1995,09,23), _address, _agency.Id,_position.Id);
            Assert.IsFalse(employee.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCPFIsNotNumeric()
        {
            Employee employee = new("ALEXANDRE ZORDAN","4505A89489G0","409830318", new DateTime(1995,09,23), _address, _agency.Id,_position.Id);
            Assert.IsFalse(employee.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorAgeIsLowerThan16()
        {
           Employee employee = new("ALEXANDRE ZORDAN","45057894897","409830318", new DateTime(2009,09,23), _address, _agency.Id,_position.Id);
           Assert.IsFalse(employee.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorAgeIsGreaterThan60()
        {
           Employee employee = new("ALEXANDRE ZORDAN","45057894897","409830318", new DateTime(1960,09,23), _address, _agency.Id,_position.Id);
           Assert.IsFalse(employee.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenAddressIsNull()
        {
           Employee employee = new("ALEXANDRE ZORDAN","45057894897","409830318", new DateTime(1990,09,23), null!, _agency.Id,_position.Id);
           Assert.IsFalse(employee.IsValid);
        }  
    }
}