using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Transaction;
using AutoMapper;

namespace AgencyManager.Core.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<CreateTransactionRequest, Transaction>();
            CreateMap<UpdateTransactionRequest, Transaction>();
        }
    }
}
