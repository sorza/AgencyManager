using AgencyManager.Core.Enums;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Models.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Models.Entities
{
    [TestClass]
    public class EmployeeTests
    {
        private static readonly Address _address = new("13477696", "Rua Um", "12345", "Centro", "Araras", "SP", "Apto 32");
        private static readonly Agency _agency = new("AGENCIA","31521273000105", _address, [],[], "");
        private static readonly Position _position = new("VENDEDOR", "VENDER PASSAGENS E ENCOMENDAS", 1000, _agency);
        private Employee _employee = new("Alexandre Zordan","45057894897","409830318", new DateTime(1995,09,23), _address, _agency,_position,[], null);
       
        
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenAddAnInvalidContact()
        {          
           var contact = new Contact(EContactType.Email, "teste@teste", "pessoal");
           Employee employee = new("Alexandre Zordan","45057894897","409830318", new DateTime(1995,09,23), _address, _agency,_position,[], null);

           _employee.AddContact(contact);

           Assert.AreEqual(0, _employee.Contacts?.Count);
        }
        
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenAddAValidContact()
        {               
           var contact = new Contact(EContactType.Email, "teste@teste.com", "pessoal");
           _employee.AddContact(contact);

           Assert.AreEqual(1,_employee.Contacts?.Count);
        }
        
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenRemoveAContact()
        {                     
           var contact = new Contact(EContactType.Email, "teste@teste.com", "pessoal");        

           _employee.AddContact(contact);
           _employee.RemoveContact(contact);

           Assert.AreEqual(0, _employee.Contacts?.Count);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccesWhenUpdateAContact()
        {                           
            var contact2 = new Contact(EContactType.Phone, "1933527436", "pessoal");
           
            _employee.AddContact(contact2);          

            var newContact = new Contact(EContactType.Phone, "7777777777", "ATUALIZADO");
            
            _employee.UpdateContact(newContact, contact2.Id);

            Assert.AreEqual(_employee.Contacts!.FirstOrDefault(x => x.Id == contact2.Id), newContact);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccesWhenActivateEmplooy()
        {           
            _employee.Deactivate();
            _employee.Activate();
            Assert.AreEqual(true, _employee.Active);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccesWhenEmplooyIsValid()
        {            
            Assert.IsTrue(_employee.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNameIsNull()
        {
            Employee employee = new(null!,"45057894897","409830318", new DateTime(1995,09,23), _address, _agency,_position,[], null);
            Assert.IsFalse(employee.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNameIsEmpty()
        {
            Employee employee = new(string.Empty,"45057894897","409830318", new DateTime(1995,09,23), _address, _agency,_position,[], null);
            Assert.IsFalse(employee.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNameIsLowerThan5Characteres()
        {
           Employee employee = new("ALEX","45057894897","409830318", new DateTime(1995,09,23), _address, _agency,_position,[], null);
           Assert.IsFalse(employee.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNameGreaterThan100Characteres()
        {
            Employee employee = new("ALEXANDRE LUIS RAMOS DA SILVA JUNIOR JORDANO CAMARGO SOARES BENTO SOARES OLIVEIRA DE PADUA ARANTES DO NASCIMENTO RUFINO",
                                    "45057894897","409830318", new DateTime(1995,09,23), _address, _agency,_position,[], null);
           Assert.IsFalse(employee.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCPFIsEmpty()
        {
           Employee employee = new("ALEXANDRE ZORDAN","","409830318", new DateTime(1995,09,23), _address, _agency,_position,[], null);
           Assert.IsFalse(employee.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCPFIsNull()
        {
            Employee employee = new("ALEXANDRE ZORDAN",null!,"409830318", new DateTime(1995,09,23), _address, _agency,_position,[], null);
            Assert.IsFalse(employee.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCPFIsLowerThan11Characteres()
        {
            Employee employee = new("ALEXANDRE ZORDAN","4505789489","409830318", new DateTime(1995,09,23), _address, _agency,_position,[], null);
            Assert.IsFalse(employee.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCPFIsGreaterThan11Characteres()
        {
            Employee employee = new("ALEXANDRE ZORDAN","450578948970","409830318", new DateTime(1995,09,23), _address, _agency,_position,[], null);
            Assert.IsFalse(employee.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCPFIsNotNumeric()
        {
            Employee employee = new("ALEXANDRE ZORDAN","4505A89489G0","409830318", new DateTime(1995,09,23), _address, _agency,_position,[], null);
            Assert.IsFalse(employee.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorAgeIsLowerThan16()
        {
           Employee employee = new("ALEXANDRE ZORDAN","45057894897","409830318", new DateTime(2009,09,23), _address, _agency,_position,[], null);
           Assert.IsFalse(employee.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorAgeIsGreaterThan60()
        {
           Employee employee = new("ALEXANDRE ZORDAN","45057894897","409830318", new DateTime(1960,09,23), _address, _agency,_position,[], null);
           Assert.IsFalse(employee.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenAddressIsNull()
        {
           Employee employee = new("ALEXANDRE ZORDAN","45057894897","409830318", new DateTime(1990,09,23), null!, _agency,_position,[], null);
           Assert.IsFalse(employee.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenAgencyIsNull()
        {
            Employee employee = new("ALEXANDRE ZORDAN","45057894897","409830318", new DateTime(1990,09,23), _address, null!,_position,[], null);
           Assert.IsFalse(employee.IsValid);
        }
    }
}