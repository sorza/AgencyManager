using System.Diagnostics.Contracts;
using AgencyManager.Core.Enums;
using Flunt.Validations;

namespace AgencyManager.Core.Requests.VirtualSale
{
    public class CreateVirtualSaleRequest : Request
    {
        public Guid CashId { get; set; }       
        public Guid CompanyId { get;  set; }      
        public Guid OrignId { get; set; }       
        public Guid DestinationId { get; set; }        
        public decimal Amount { get;  set; }
        public EPaymentType PaymentType { get;  set; } = EPaymentType.PIX;
        public bool Paid { get;  set; } = true;
        public string? Observation { get;  set; }

        public void Validate()
        {
            var contract = new Contract<CreateVirtualSaleRequest>();

            AddNotifications(contract.Requires()
                .AreNotEquals(CashId, Guid.Empty, "Identidicador de caixa inválido.")
                .IsEmail(UserId, "Usuário inválido")
                .AreNotEquals(CompanyId, Guid.Empty, "Identidicador de empresa inválido.")
                .AreNotEquals(OrignId, Guid.Empty, "Identidicador de origem inválido.")
                .AreNotEquals(DestinationId, Guid.Empty, "Identidicador de destino inválido.")
                .IsGreaterThan(Amount,0,"O valor deve ser maior que zero")                
            );

            if(Observation is not null)
            {
                AddNotifications(contract.Requires()
                    .IsLowerThan(Observation.Length,100,"A observação deve ter no máximo 100 caracteres."));
            }
        }
    }
}