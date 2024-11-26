using AgencyManager.Api.Data;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Sale;
using AgencyManager.Core.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Api.Handler
{
    public class SaleHandler(AppDbContext context, IMapper mapper) : ISaleHandler
    {
        public async Task<Response<Sale?>> CreateAsync(CreateSaleRequest request)
        {
            try
            {
                #region 01. Validar venda
                var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();
                string errors = string.Empty;

                if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
                    return new Response<Sale?>(null, 400, string.Join(". ", validationResults.Select(r => r.ErrorMessage)));
                #endregion

                #region 02. Mapear dados para venda
                var sale = mapper.Map<Sale>(request);

                #endregion

                #region 03. Adicionar venda
                await context.Sales.AddAsync(sale);
                await context.SaveChangesAsync();

                #endregion

                #region 04. Retornar resposta
                return new Response<Sale?>(sale, 200, "Venda registrada com sucesso!");

                #endregion
            }
            catch
            {
                return new Response<Sale?>(null, 500, "Não foi possível registrar a venda");
            }
        }
        public async Task<Response<Sale?>> DeleteAsync(DeleteSaleRequest request)
        {
            try
            {
                #region 01. Buscar venda
                var sale = await context.Sales.FirstOrDefaultAsync(x => x.Id == request.Id);

                #endregion

                #region 02. Verificar se é nulo
                if (sale is null) return new Response<Sale?>(null, 404, "Venda não encontrada");

                #endregion

                #region 03. Excluir venda
                context.Sales.Remove(sale);
                await context.SaveChangesAsync();

                #endregion

                #region 04. Retornar resposta
                return new Response<Sale?>(sale, 200, "Venda excluída com sucesso");

                #endregion
            }
            catch
            {
                return new Response<Sale?>(null, 500, "Não foi possível excluir a venda");
            }
        }
        public async Task<PagedResponse<List<Sale>?>> GetAllByCashAsync(GetSalesByCashRequest request)
        {
            try
            {
                #region 01. Buscar vendas por caixa
                var query = context
                .Sales
                .Where(x => x.CashId == request.CashId)
                .AsNoTracking();

                #endregion

                #region 02. Paginar de acordo com o especificado
                var sales = await query
                    .Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize)
                    .ToListAsync();

                #endregion

                #region 03. Obter quantidade de vendas
                var count = await query.CountAsync();

                #endregion

                #region 04. Retornar Resposta
                return sales is null
                        ? new PagedResponse<List<Sale>?>(null, 404, "Não foram encontradas vendas para este caixa.")
                        : new PagedResponse<List<Sale>?>(sales, count, request.PageNumber, request.PageSize);
                #endregion
            }
            catch
            {
                return new PagedResponse<List<Sale>?>(null, 500, "Não possível consultar as vendas.");
            }
        }
        public async Task<Response<Sale?>> GetByIdAsync(GetSaleByIdRequest request)
        {
            try
            {
                #region 01. Buscar Venda
                var sale = await context
                    .Sales
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (sale is null)
                    return new Response<Sale?>(null, 404, "Venda não encontrada");
                #endregion

                #region 02. Retorna resposta
                return new Response<Sale?>(sale, 200);

                #endregion
            }
            catch
            {
                return new Response<Sale?>(null, 500, "Não foi possível buscar a venda");
            }
        }
        public async Task<Response<Sale?>> UpdateAsync(UpdateSaleRequest request)
        {
            try
            {
                #region 01. Buscar Venda
                var sale = await context
                    .Sales
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (sale is null)
                    return new Response<Sale?>(null, 404, "Venda não encontrada");
                #endregion

                #region 02. Validar Venda

                var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();
                string errors = string.Empty;

                if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
                {
                    return new Response<Sale?>(null, 400, string.Join(". ", validationResults.Select(r => r.ErrorMessage)));
                }

                #endregion

                #region 03. Transferir os dados da Requisição para a venda                
                mapper.Map(request, sale);

                #endregion

                #region 04. Salvar alterações
                await context.SaveChangesAsync();

                #endregion

                #region 05. Retornar Resposta
                return new Response<Sale?>(sale, 200, "Venda atualizada com sucesso");

                #endregion
            }
            catch
            {
                return new Response<Sale?>(null, 500, "Não foi possível atualizar a venda");
            }
        }

    }
}
