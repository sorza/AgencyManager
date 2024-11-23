using AgencyManager.Api.Data;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Cash;
using AgencyManager.Core.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Response<Cash?>> DeleteAsync(DeleteCashRequest request)
        {
            try
            {
                #region 01. Buscar caixa
                var cash = await context.Cash
                  .Include(x => x.Sales)
                  .Include(x => x.Transactions)
                  .Include(x => x.VirtualSales)
                  .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (cash is null)
                    return new Response<Cash?>(null, 404, "Caixa não encontrada");

                #endregion
                /*
                #region 02. Excluir transações
                if(cash.Transactions is not null)
                    context.Transactions.RemoveRange(cash.Transactions);

                #endregion

                #region 03. Excluir vendas virtuais
                if (cash.VirtualSales is not null)
                    context.VirtualSales.RemoveRange(cash.VirtualSales);

                #endregion

                #region 04. Excluir vendas
                if (cash.Sales is not null)
                    context.Sales.RemoveRange(cash.Sales);

                #endregion
                */
                #region 05. Excluir caixa
                context.Cash.Remove(cash);

                #endregion

                #region 06. Salvar alterações
                await context.SaveChangesAsync();

                #endregion

                #region 07. Retornar resposta
                return new Response<Cash?>(cash, 204, "Caixa excluído com sucesso");
                #endregion

            }
            catch
            {
                return new Response<Cash?>(null, 500, "Não foi possível excluir o caixa");
            }
        }

        public async Task<PagedResponse<List<Cash>?>> GetByAgencyByPeriodAsync(GetCashsByAgencyByPeriodRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<Cash?>> GetByIdAsync(GetCashByIdRequest request)
        {
            try
            {
                var cash = await context.Cash
                .AsNoTracking()
                .Include(x => x.Sales)
                .Include(x => x.Transactions)
                .Include(x => x.VirtualSales)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

                return cash is null
                    ? new Response<Cash?>(null, 404, "Caixa não encontrado")
                    : new Response<Cash?>(cash);
            }
            catch
            {
                return new Response<Cash?>(null, 500, "Não foi possível recuperar o caixa.");
            }
        }

        public async Task<PagedResponse<List<Cash>?>> GetByUserByPeriodAsync(GetCashsByUserRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<Cash?>> UpdateAsync(UpdateCashRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
