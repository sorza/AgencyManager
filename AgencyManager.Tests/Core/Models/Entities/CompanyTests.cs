using AgencyManager.Core.Enums;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Models.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgencyManager.Tests.Core.Models.Entities
{
    [TestClass]
    public class CompanyTests
    {
        private static readonly Address _address = new("13477696", "Rua Um", "12345", "Centro", "Araras", "SP", "Apto 32");
        
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenCompanyIsValid()
        {
            var company = new Company("EMPRESA GONTIJO DE TRANSPORTES S/A", "GONTIJO", "31521273000105", _address,[],null);
            Assert.IsTrue(company.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNameIsNull()
        {
            var company = new Company(null!, "GONTIJO", "31521273000105", _address,[],null);
            Assert.IsFalse(company.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNameIsEmpty()
        {
           var company = new Company(string.Empty, "GONTIJO", "31521273000105", _address,[],null);
           Assert.IsFalse(company.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenNameIsGreaterThan60Characteres()
        {
           var company = new Company("EMPRESA GONTIJO EMPRESA GONTIJO EMPRESA GONTIJO EMPRESA GONTIJO EMPRESA GONTIJO EMPRESA GONTIJO",
                                     "GONTIJO", "31521273000105", _address,[],null);
           Assert.IsFalse(company.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenTradingNameIsNull()
        {
            var company = new Company("EMPRESA GONTIJO DE TRANSPORTES S/A",
                                     null!,
                                     "31521273000105", _address,[],null);
           Assert.IsFalse(company.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenTradingNameIsEmpty()
        {
             var company = new Company("EMPRESA GONTIJO DE TRANSPORTES S/A",
                                     string.Empty,
                                     "31521273000105", _address,[],null);
           Assert.IsFalse(company.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenTradingNameIsGreaterThan60Characteres()
        {
           var company = new Company("EMPRESA GONTIJO DE TRANSPORTES S/A",
                                     "EMPRESA GONTIJO EMPRESA GONTIJO EMPRESA GONTIJO EMPRESA GONTIJO EMPRESA GONTIJO",
                                     "31521273000105", _address,[],null);
                                     
           Assert.IsFalse(company.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCnpjIsLowerThan14Characteres()
        {
            var company = new Company("EMPRESA GONTIJO DE TRANSPORTES S/A",
                                     "EMPRESA GONTIJO",
                                     "3152127300010", _address,[],null);

           Assert.IsFalse(company.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCnpjIsGreaterThan14Characteres()
        {
            var company = new Company("EMPRESA GONTIJO DE TRANSPORTES S/A",
                                     "EMPRESA GONTIJO",
                                     "315212730001005", _address,[],null);
           Assert.IsFalse(company.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenCnpjIsNotNumeric()
        {
            var company = new Company("EMPRESA GONTIJO DE TRANSPORTES S/A",
                                     "EMPRESA GONTIJO",
                                     "3F5212A30E0105", _address,[],null);
           Assert.IsFalse(company.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenAddressIsNull()
        {
            var company = new Company("EMPRESA GONTIJO DE TRANSPORTES S/A",
                                     "EMPRESA GONTIJO",
                                     "31521273000105", null!,[],null);
           Assert.IsFalse(company.IsValid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnErrorWhenAddAnInvalidContact()
        {          
           var contact = new Contact(EContactType.Email, "teste@teste", "pessoal");
           var company = new Company("EMPRESA GONTIJO DE TRANSPORTES S/A", "GONTIJO", "31521273000105", _address,[],null);

           company.AddContact(contact);

           Assert.AreEqual(0, company.Contacts?.Count);
        }
        
        [TestMethod]
        [TestCategory("Domain")]
        public void ShouldReturnSuccessWhenAddAValidContact()
        {           
           var contact = new Contact(EContactType.Email, "teste@teste.com", "pessoal");
           var company = new Company("EMPRESA GONTIJO DE TRANSPORTES S/A", "GONTIJO", "31521273000105", _address,[],null);
           company.AddContact(contact);

           Assert.AreEqual(1,company.Contacts?.Count);
        }
        
        [TestMethod]
        [TestCategory("Domain")]
        public void ReturnSuccessWhenRemoveAContact()
        {          
           var company = new Company("EMPRESA GONTIJO DE TRANSPORTES S/A", "GONTIJO", "31521273000105", _address,[],null);
           var contact = new Contact(EContactType.Email, "teste@teste.com", "pessoal");

           company.AddContact(contact);
           company.RemoveContact(contact);

           Assert.AreEqual(0, company.Contacts?.Count);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void ReturnSuccesWhenUpdateAContact()
        {
            var company = new Company("EMPRESA GONTIJO DE TRANSPORTES S/A", "GONTIJO", "31521273000105", _address,[],null);         
            var contact2 = new Contact(EContactType.Phone, "1933527436", "pessoal");
           
            company.AddContact(contact2);          

            var newContact = new Contact(EContactType.Phone, "7777777777", "ATUALIZADO");
            
            company.UpdateContact(newContact, contact2.Id);

            Assert.AreEqual(company.Contacts!.FirstOrDefault(x => x.Id == contact2.Id), newContact);
        }
    }
}