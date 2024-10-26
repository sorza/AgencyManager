using AgencyManager.Core.Requests.Address;
using AgencyManager.Core.Requests.Contact;
using Flunt.Validations;

namespace AgencyManager.Core.Requests.Employee
{
    public class UpdateEmployeeRequest : Request
    {
        public Guid Id { get; set; }
        public string Name { get;  set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Rg { get; set; } = string.Empty;
        public DateTime BirthDay { get; set; }
        public UpdateAddressRequest Address { get; set; } = null!;
        public Guid AgencyId { get; set; }
        public Guid PositionId { get; set; }
        public DateTime DateHire { get; set; }
        public DateTime DateDismiss { get; set; }        
        public ICollection<CreateContactRequest>? Contacts { get; set; }

         public void Validate()
        {
            AddNotifications(new Contract<UpdateEmployeeRequest>().Requires()
                .AreNotEquals(Id, Guid.Empty, "Identificador de colaborador inválido.")
                .IsNotNullOrEmpty(Name, "Name", "Nome inválido.")
                .IsLowerOrEqualsThan(Name, 100, "Name", "O nome deve conter no máximo 100 letras.")
                .IsGreaterOrEqualsThan(Name, 5, "Name", "O nome deve conter no mínimo 5 letras.")

                .Matches(Cpf, @"^\d{11}$", "Cpf", "O CPF deve conter 11 dígitos númericos.")

                .Matches(Rg, @"^\d+$", "Rg", "O RG deve conter apenas dígitos númericos.")
                .IsGreaterOrEqualsThan(Rg, 4,"Rg", "O RG deve conter no mínimo 4 dígitos.")
                .IsLowerOrEqualsThan(Rg, 14, "Rg", "O RG pode conter no máximo 14 dígitos.")

                .IsLowerOrEqualsThan(BirthDay,DateTime.Now.AddYears(-16),"Birthday","A idade mínima é de 16 anos")
                .IsGreaterOrEqualsThan(BirthDay,DateTime.Now.AddYears(-60),"Birthday","A idade máxima é de 60 anos")

                .IsNotNull(Address,"Address", "Endereço inválido")
            );

            if(Address is not null)
            {
                AddNotifications(Address.Notifications);
            }
        }
    }
}