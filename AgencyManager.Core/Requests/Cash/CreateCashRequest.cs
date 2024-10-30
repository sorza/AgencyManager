using Flunt.Validations;
using System.Numerics;

namespace AgencyManager.Core.Requests.Cash
{
    public class CreateCashRequest : Request
    {
        public int AgencyId { get; set; }
        public DateTime Date { get; set; }
        public decimal StartValue { get; set; }
        public decimal EndValue { get; set; }


        public void Validate()
        {
            AddNotifications(new Contract<CreateCashRequest>().Requires()     
                .IsEmail(UserId, "UserId", "Não é um email válido.")          
                .IsLowerOrEqualsThan(Date, DateTime.Now, "A data não pode ser futura")
                .IsGreaterOrEqualsThan(StartValue, 0, "StartValue", "O troco inicial deve ser positivo")
                .IsGreaterOrEqualsThan(EndValue, 0, "EndValue", "O troco final deve ser positivo")
            );
        }
    }
}