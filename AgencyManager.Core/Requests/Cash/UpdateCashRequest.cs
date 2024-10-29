using Flunt.Validations;

namespace AgencyManager.Core.Requests.Cash
{
    public class UpdateCashRequest : Request
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal StartValue { get; set; }
        public decimal EndValue { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<UpdateCashRequest>().Requires()  
                .IsGreaterThan(Id, 0, "Identificador de caixa inválido")   
                .IsEmail(UserId, "UserId", "Não é um email válido.")          
                .IsLowerOrEqualsThan(Date, DateTime.Now, "A data não pode ser futura")
                .IsGreaterOrEqualsThan(StartValue, 0, "StartValue", "O troco inicial deve ser positivo")
                .IsGreaterOrEqualsThan(EndValue, 0, "EndValue", "O troco final deve ser positivo")
            );
        }
    }
}