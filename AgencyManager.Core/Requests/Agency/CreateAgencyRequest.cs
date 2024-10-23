using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Address;
using Flunt.Validations;

namespace AgencyManager.Core.Requests.Agency
{
    public class CreateAgencyRequest : Request
    {        
        public string Description { get;  set; } = string.Empty;
        public string Cnpj { get;  set; } = string.Empty;
        public CreateAddressRequest Address { get; set; } = new();
        public IList<Contact>? Contacts { get; set; } 
        public string? Photo { get; private set; }

        public void Validate()
        {
            AddNotifications(new Contract<CreateAgencyRequest>().Requires()
                .IsNotNullOrEmpty(Description,"Description","Descrição inválida.")
                .IsLowerThan(Description, 60,"Description", "A descrição deve conter no máximo 60 caracteres.")
                .IsGreaterThan(Description, 2,"Description", "A descrição deve conter no mínimo 2 caracteres.")

                .Matches(Cnpj, @"^\d{14}$", "Cnpj", "O CNPJ deve conter 14 dígitos númericos.")
                .IsNotNull(Address, "Address", "Endereço inválido.")
            );

            if(Address is not null)
            {
                Address.Validate();
                AddNotifications(Address.Notifications);
            }
        }
    }
}