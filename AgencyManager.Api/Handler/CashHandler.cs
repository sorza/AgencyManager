using AgencyManager.Api.Data;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Cash;
using AgencyManager.Core.Responses;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Api.Handler
{
    public class CashHandler(AppDbContext context, IMapper mapper) : ICashHandler
    {
        public async Task<Response<Cash?>> CreateAsync(CreateCashRequest request)
        {
            #region 01. Validar requisição

            var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();
            string errors = string.Empty;

            if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
                return new Response<Cash?>(null, 400, string.Join(". ", validationResults.Select(r => r.ErrorMessage)));

            #endregion

            #region 02. Mapear propriedades e criar caixa
            try
            {
                var cash = mapper.Map<Cash>(request);

                await context.Cash.AddAsync(cash);
                await context.SaveChangesAsync();

                return new Response<Cash?>(cash, 201, "Caixa aberto com sucesso.");
            }
            catch
            {
                return new Response<Cash?>(null, 500, "Não foi possível abrir caixa");
            }
            #endregion
        }

        public Task<Response<Cash?>> DeleteAsync(DeleteCashRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Cash>?>> GetByAgencyByPeriodAsync(GetCashsByAgencyByPeriodRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Cash?>> GetByIdAsync(GetCashByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Cash>?>> GetByUserByPeriodAsync(GetCashsByUserRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Cash?>> UpdateAsync(UpdateCashRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
