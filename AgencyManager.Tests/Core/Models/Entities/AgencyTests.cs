using AgencyManager.Core.Enums;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Models.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Models.Entities
{
    [TestClass]
    public class AgencyTests
    {    
        private static readonly Address _address = new("13477696", "Rua Um", "12345", "Centro", "Araras", "SP", "Apto 32");        
        private readonly Agency _agency = new("Agencia 01", "31521273000105", _address); 
        private static readonly Position _position = new("VENDEDOR", "VENDER PASSAGENS E ENCOMENDAS", 1000, new("Agencia 01", "31521273000105", _address));
        private readonly Employee _employee = new("Alexandre Zordan","45057894897","409830318", new DateTime(1995,09,23), _address, new("Agencia 01", "31521273000105", _address),_position);


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

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenAddAnInvalidContact()
        {          
           var contact = new Contact(EContactType.Email, "teste@teste", "pessoal");
           _agency.AddContact(contact);

           Assert.AreEqual(0,_agency.Contacts?.Count);
        }
        
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenAddAValidContact()
        {           
           var contact = new Contact(EContactType.Email, "teste@teste.com", "pessoal");
           _agency.AddContact(contact);

           Assert.AreEqual(1,_agency.Contacts?.Count);
        }
        
        [TestMethod]
        [TestCategory("Domain")]
        public void ReturnSuccessWhenRemoveAContact()
        {                    
           var contact = new Contact(EContactType.Email, "teste@teste.com", "pessoal");
           _agency.AddContact(contact);
           _agency.RemoveContact(contact);

           Assert.AreEqual(0,_agency.Contacts?.Count);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ReturnSuccesWhenUpdateAContact()
        {
               
            var contact = new Contact(EContactType.Phone, "1933527436", "pessoal");           
            _agency.AddContact(contact);          

            var newContact = new Contact(EContactType.Phone, "7777777777", "ATUALIZADO");            
            _agency.UpdateContact(newContact, contact.Id);

            Assert.AreEqual(_agency.Contacts!.FirstOrDefault(x => x.Id == contact.Id), newContact);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenAddAnInvalidPosition()
        {             
            Position position = new("Vendedor","Vender bilhetes", 0, _agency);            
            _agency.AddPosition(position);

            Assert.AreEqual(0, _agency.Positions?.Count);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenAddAValidPosition()        
        {           
            Position position = new("Vendedor","Vender bilhetes", 1500, _agency);            
            _agency.AddPosition(position);

            Assert.AreEqual(1, _agency.Positions?.Count);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenRemoveAPosition()
        {           
            Position position = new("Vendedor","Vender bilhetes", 1500, _agency);

            _agency.AddPosition(position);
            _agency.RemovePosition(position);

            Assert.AreEqual(0, _agency.Positions?.Count);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccesWhenUpdateAPosition()
        {                 
            Position position = new("Vendedor","Vender bilhetes", 1500, _agency);           
            _agency.AddPosition(position);          

            var newPosition = new Position("Vendedor","RESPONSABILIDADES ATUALIZADAS", 3500, _agency);            
            _agency.UpdatePosition(newPosition, position.Id);

            Assert.AreEqual(_agency.Positions!.FirstOrDefault(x => x.Id == position.Id), newPosition);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccesWhenActivateAgency()
        {           
            _agency.Deactivate();
            _agency.Activate();
            Assert.AreEqual(true, _agency.Active);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccesWhenDeactivateAgency()
        {      
            _agency.Activate();
            _agency.Deactivate();
            Assert.AreEqual(false, _agency.Active);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccesWhenHireAnEmployee()
        {
            _agency.HireAnEmployee(_employee);
            Assert.AreEqual(1, _agency.Employees!.Count);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccesWhenDismissAnEmployee()
        {
             _agency.HireAnEmployee(_employee);
             _agency.DismissAnEmployee(_employee);
             
            Assert.AreEqual(false, _employee.Active);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccesWhenUpdateAnEmployee()
        {
            _agency.HireAnEmployee(_employee);
            var employee = _agency.Employees!.FirstOrDefault(x=>x.Id == _employee.Id);

            var updateEmployee = new Employee("EMPLOY ATUALIZADO","12345678910","12301238", new DateTime(1995,09,23), _address, new("Agencia 01", "31521273000105", _address),_position);

            _agency.UpdateAnEmployee(updateEmployee, employee!.Id);

            bool isEqual = updateEmployee.Equals(_employee);

            Assert.AreEqual(employee, updateEmployee);
        
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccesWhenRenmoveAnEmployee()
        {
            _agency.HireAnEmployee(_employee);
            _agency.RemoveAnEmployee(_employee);

            Assert.IsFalse(_agency.Employees!.Contains(_employee));
        }
    }
}

