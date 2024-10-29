using Flunt.Validations;

namespace AgencyManager.Core.Requests.Sale
{
    public class CreateSaleRequest : Request
    {
        public int CashId { get;  set; }        
        public int CompanyId { get;  set; }       
        public decimal Money { get;  set; }
        public decimal Digital { get;  set; }

        public void Validate()
        {
             AddNotifications(new Contract<CreateSaleRequest>().Requires()
                .IsEmail(UserId, "UserId", "Usuário inválido")
                .IsGreaterThan(CashId, 0, "Identificador de caixa inválido.") 
                .IsGreaterThan(CompanyId, 0, "Identificador de caixa inválido.")                
            );
        }
    }
}