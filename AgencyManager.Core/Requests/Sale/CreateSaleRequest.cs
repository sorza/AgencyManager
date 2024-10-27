using Flunt.Validations;

namespace AgencyManager.Core.Requests.Sale
{
    public class CreateSaleRequest : Request
    {
        public Guid CashId { get;  set; }        
        public Guid CompanyId { get;  set; }       
        public decimal Money { get;  set; }
        public decimal Digital { get;  set; }

        public void Validate()
        {
             AddNotifications(new Contract<CreateSaleRequest>().Requires()
                .IsEmail(UserId, "UserId", "Usuário inválido")
                .AreNotEquals(CashId, Guid.NewGuid(), "Identificador de caixa inválido.") 
                .AreNotEquals(CompanyId, Guid.NewGuid(), "Identificador de caixa inválido.")                
            );
        }
    }
}