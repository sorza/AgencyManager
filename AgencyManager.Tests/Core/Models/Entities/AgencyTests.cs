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

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenDescriptionIsEmpty()
        {
            Agency _agency = new(string.Empty, "31521273000105", _address, [],[], "");

            Assert.IsFalse(_agency.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenDescriptionIsGreaterThanSixthCharacteres()
        {
            Agency agency = new("ABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJKL",
                                 "31521273000105", _address, [],[], ""); 

            Assert.IsFalse(agency.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenDescriptionIsLowerThanTwoCharacteres()
        {
            Agency _agency = new("A","31521273000105", _address, [],[], "");
            
            Assert.IsFalse(_agency.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenDescriptionIsValid()
        {
            Agency _agency = new("AGENCIA","31521273000105", _address, [],[], "");
            
            Assert.IsTrue(_agency.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCnpjIsNotOnlyNumeric()
        {
            Agency _agency = new("AGENCIA","ASD98710DSA651", _address, [],[], "");
            
            Assert.IsFalse(_agency.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCnpjLengthIsNotEqualsFourteen()
        {
            Agency _agency = new("AGENCIA","0123456789101", _address, [],[], "");
            
            Assert.IsFalse(_agency.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
         public void ShouldReturnErrorWhenCnpjIsEmpty()
        {
            Agency _agency = new("AGENCIA",string.Empty, _address, [],[], "");
            
            Assert.IsFalse(_agency.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
         public void ShouldReturnSuccessWhenCnpjIsValid()
        {
            Agency _agency = new("AGENCIA","31521273000105", _address, [],[], "");
            
            Assert.IsTrue(_agency.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
         public void ShouldReturnErrorWhenAddresIsNull()
        {
            Agency _agency = new("AGENCIA","31521273000105", null!, [],[], "");
          
            Assert.IsFalse(_agency.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
         public void ShouldReturnSuccessWhenAddresIsValid()
        {
            Agency _agency = new("AGENCIA","31521273000105", _address, [],[], "");
          
            Assert.IsTrue(_agency.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenAddAnInvalidContact()
        {          
           var contact = new Contact(EContactType.Email, "teste@teste", "pessoal");
           Agency _agency = new("Agencia 01", "31521273000105", _address, [],[], "");

           _agency.AddContact(contact);

           Assert.AreEqual(0,_agency.Contacts?.Count);
        }
        
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenAddAValidContact()
        {           
           var contact = new Contact(EContactType.Email, "teste@teste.com", "pessoal");
           Agency _agency = new("Agencia 01", "31521273000105", _address, [],[], "");
           _agency.AddContact(contact);

           Assert.AreEqual(1,_agency.Contacts?.Count);
        }
        
        [TestMethod]
        [TestCategory("Domain")]
        public void ReturnSuccessWhenRemoveAContact()
        {          
           Agency _agency = new("Agencia 01", "31521273000105", _address, [],[], "");
           var contact = new Contact(EContactType.Email, "teste@teste.com", "pessoal");
           _agency.AddContact(contact);
           _agency.RemoveContact(contact);

           Assert.AreEqual(0,_agency.Contacts?.Count);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ReturnSuccesWhenUpdateAContact()
        {
            Agency agency = new("Agencia 01", "31521273000105", _address, [],[], "");           
            var contact2 = new Contact(EContactType.Phone, "1933527436", "pessoal");
           
            agency.AddContact(contact2);          

            var newContact = new Contact(EContactType.Phone, "7777777777", "ATUALIZADO");
            
            agency.UpdateContact(newContact, contact2.Id);

            Assert.AreEqual(agency.Contacts!.FirstOrDefault(x => x.Id == contact2.Id), newContact);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenAddAnInvalidPosition()
        {
            Agency agency = new("Agencia 01", "31521273000105", _address, [],[], "");   
            Position position = new("Vendedor","Vender bilhetes", 0, agency);
            
            agency.AddPosition(position);

            Assert.AreEqual(0, agency.Positions?.Count);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenAddAValidPosition()
        {
            Agency agency = new("Agencia 01", "31521273000105", _address, [],[], "");   
            Position position = new("Vendedor","Vender bilhetes", 1500, agency);
            
            agency.AddPosition(position);

            Assert.AreEqual(1, agency.Positions?.Count);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenRemoveAPosition()
        {
            Agency agency = new("Agencia 01", "31521273000105", _address, [],[], "");   
            Position position = new("Vendedor","Vender bilhetes", 1500, agency);
            
            agency.AddPosition(position);
            agency.RemovePosition(position);

            Assert.AreEqual(0, agency.Positions?.Count);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccesWhenUpdateAPosition()
        {
            Agency agency = new("Agencia 01", "31521273000105", _address, [],[], "");           
            Position position = new("Vendedor","Vender bilhetes", 1500, agency);
           
            agency.AddPosition(position);          

            var newPosition = new Position("Vendedor","RESPONSABILIDADES ATUALIZADAS", 3500, agency);
            
            agency.UpdatePosition(newPosition, position.Id);

            Assert.AreEqual(agency.Positions!.FirstOrDefault(x => x.Id == position.Id), newPosition);
        }
    }
}