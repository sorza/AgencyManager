using Flunt.Validations;

namespace AgencyManager.Core.Models.Entities
{
    public class Position : Entity
    {        
        public Position(string description, string responsabilities, decimal salary, Agency agency)
        {

            AddNotifications(new Contract<Position>().Requires()
                .IsNotNullOrEmpty(description,"Description","Descrição do cargo inválida.")
                .IsGreaterThan(description, 3, "Description","O cargo deve ter no mínimo 3 caracteres")
                .IsLowerThan(description, 70, "Description","O cargo deve ter no máximo 70 caracteres")

                .IsNotNullOrEmpty(responsabilities,"Responsabilities","Responsabilidades do cargo inválidas.")
                .IsGreaterThan(responsabilities, 10, "Responsabilities","As responsabilidades devem conter no mínimo 10 caracteres")
                .IsLowerThan(responsabilities, 500, "Responsabilities","As responsabilidades devem conter no mínimo 500 caracteres")

                .IsNotNull(salary,"Salary","Responsabilidades do cargo inválidas.")
                .IsGreaterThan(salary, 0, "Salary","O salário deve ser maior que zero")
                .IsLowerThan(salary, 20000, "Salary","O salário deve ser menor que vinte mil reais")

                .IsNotNull(agency,"Agency","Agencia inválida.")

            );

            Description = description;
            Responsabilities = responsabilities;
            Salary = salary;            
            Agency = agency;
            AgencyId = agency.Id;
        }

        public string Description { get; private set; }
        public string Responsabilities { get; private set; }
        public decimal Salary { get; private set; }
        public Guid AgencyId { get; private set; }
        public virtual Agency Agency { get; set; }

        public void Update(Position position)
        {
            if(position.IsValid)
            {
                Description = position.Description;
                Responsabilities = position.Responsabilities;
                Salary = position.Salary;            
                Agency = position.Agency;
                AgencyId = position.Agency.Id;
            }
        }

        #region Overrides
        public override bool Equals(object? obj)
        {
            if(obj is null) return false;

            var position = (Position)obj;

            return Description == position.Description &&
                   Responsabilities == position.Responsabilities &&
                   Salary == position.Salary &&
                   Agency == position.Agency;

        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Description, Responsabilities, Salary, Agency);
        }
        #endregion
    }
}