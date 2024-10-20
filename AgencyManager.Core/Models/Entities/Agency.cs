using AgencyManager.Core.Models.ValueObjects;
using Flunt.Validations;

namespace AgencyManager.Core.Models.Entities
{
    public class Agency : Entity
    {
        private readonly IList<Contact> _contacts;
        private readonly IList<Position> _positions = [];
        private readonly IList<Employee> _emplooyes = [];
        private readonly IList<ServiceContract> _contracts = [];

        public Agency(string description, string cnpj, Address address, IList<Contact>? contacts = null, string? photo = null)
        {
            AddNotifications(new Contract<Agency>().Requires()
                .IsNotNullOrEmpty(description,"Description","O nome/descrição inválido.")
                .IsLowerThan(description, 60,"Description", "O nome/descrição deve conter no máximo 60 caracteres.")
                .IsGreaterThan(description, 2,"Description", "O nome/descrição deve conter no mínimo 2 caracteres.")

                .Matches(cnpj, @"^\d{14}$", "Cnpj", "O CNPJ deve conter 14 dígitos númericos.")

                .IsNotNull(address,"Address","Endereço Inválido")
            );

            Description = description;
            Cnpj = cnpj;
            Address = address;    

            Active = true;

            Photo = photo ?? "";
            _contacts = contacts ?? [];
        }

        public string Description { get; private set; }
        public string Cnpj { get; private set; }
        public bool Active { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Contact>? Contacts { get { return _contacts.ToArray(); }}
        public IReadOnlyCollection<Position>? Positions { get { return _positions.ToArray(); }}
        public IReadOnlyCollection<Employee>? Employees { get { return _emplooyes.ToArray(); }}
        public IReadOnlyCollection<ServiceContract>? Contracts { get { return _contracts.ToArray(); }}
        public string? Photo { get; private set; }
    }
}