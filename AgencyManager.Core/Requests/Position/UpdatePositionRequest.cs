using Flunt.Validations;

namespace AgencyManager.Core.Requests.Position
{
    public class UpdatePositionRequest : Request
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Responsabilities { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public int AgencyId { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract<UpdatePositionRequest>().Requires()
                .IsGreaterThan(Id,0,"Identificador de Cargo inválido.")
                .IsNotNullOrEmpty(Description,"Description","Descrição do cargo inválida.")
                .IsGreaterThan(Description, 3, "Description","O cargo deve ter no mínimo 3 caracteres")
                .IsLowerThan(Description, 70, "Description","O cargo deve ter no máximo 70 caracteres")

                .IsNotNullOrEmpty(Responsabilities,"Responsabilities","Responsabilidades do cargo inválidas.")
                .IsGreaterThan(Responsabilities, 10, "Responsabilities","As responsabilidades devem conter no mínimo 10 caracteres")
                .IsLowerThan(Responsabilities, 500, "Responsabilities","As responsabilidades devem conter no máximo 500 caracteres")
                
                .IsGreaterThan(Salary, 0, "Salary","O salário deve ser maior que zero")
                .IsLowerThan(Salary, 20000, "Salary","O salário deve ser menor que vinte mil reais")

                .IsNotNull(AgencyId,"Agency","Agencia inválida.")
            );
        }
    }
}