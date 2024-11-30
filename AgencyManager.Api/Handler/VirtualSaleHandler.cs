using AgencyManager.Api.Data;
using AgencyManager.Core.Enums;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.VirtualSale;
using AgencyManager.Core.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Api.Handler
{
    public class VirtualSaleHandler(AppDbContext context, IMapper mapper) : IVirtualSaleHandler
    {
        public async Task<Response<VirtualSale?>> CreateAsync(CreateVirtualSaleRequest request)
        {
            try
            {
                #region 01. Validar venda virtual
                var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();
                string errors = string.Empty;

                if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
                    return new Response<VirtualSale?>(null, 400, string.Join(". ", validationResults.Select(r => r.ErrorMessage)));
                #endregion

                #region 02. Mapear dados para venda virtual
                var virtualSale = mapper.Map<VirtualSale>(request);

                #endregion

                #region 03. Adicionar venda virtual
                await context.VirtualSales.AddAsync(virtualSale);
                await context.SaveChangesAsync();

                #endregion

                #region 04. Retornar resposta
                return new Response<VirtualSale?>(virtualSale, 200, "Venda virtual registrada com sucesso!");

                #endregion
            }
            catch
            {
                return new Response<VirtualSale?>(null, 500, "Não foi possível registrar a venda virtual");
            }
        }

        public async Task<Response<VirtualSale?>> DeleteAsync(DeleteVirtualSaleRequest request)
        {
            try
            {
                #region 01. Buscar venda virtual
                var virtualSale = await context.VirtualSales.FirstOrDefaultAsync(x => x.Id == request.Id);

                #endregion

                #region 02. Verificar se é nulo
                if (virtualSale is null) return new Response<VirtualSale?>(null, 404, "Venda virtual não encontrada");

                #endregion

                #region 03. Excluir transação
                context.VirtualSales.Remove(virtualSale);
                await context.SaveChangesAsync();

                #endregion

                #region 04. Retornar resposta
                return new Response<VirtualSale?>(virtualSale, 200, "Venda virtual excluída com sucesso");

                #endregion
            }
            catch
            {
                return new Response<VirtualSale?>(null, 500, "Não foi possível excluir a venda virtual");
            }
        }

        public async Task<PagedResponse<List<VirtualSale>?>> GetAllByCashIdAsync(GetVirtualSalesByCashIdRequest request)
        {
            try
            {
                #region 01. Buscar vendas virtuais por caixa
                var query = context
                .VirtualSales
                .Where(x => x.CashId == request.CashId)
                .AsNoTracking();

                #endregion

                #region 02. Paginar de acordo com o especificado
                var virtualSales = await query
                    .Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize)
                    .ToListAsync();

                #endregion

                #region 03. Obter quantidade de vendas virtuais
                var count = await query.CountAsync();

                #endregion

                #region 04. Retornar Resposta
                return virtualSales is null
                        ? new PagedResponse<List<VirtualSale>?>(null, 404, "Não foram encontradas vendas virtuais para este caixa.")
                        : new PagedResponse<List<VirtualSale>?>(virtualSales, count, request.PageNumber, request.PageSize);
                #endregion
            }
            catch
            {
                return new PagedResponse<List<VirtualSale>?>(null, 500, "Não possível consultar as vendas virtuais.");
            }
        }

        public async Task<Response<VirtualSale?>> GetByIdAsync(GetVirtualSalesByIdRequest request)
        {
            try
            {
                #region 01. Buscar venda virtual
                var virtualSale = await context
                    .VirtualSales
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (virtualSale is null)
                    return new Response<VirtualSale?>(null, 404, "Venda virtual não encontrada");
                #endregion

                #region 02. Retorna resposta
                return new Response<VirtualSale?>(virtualSale, 200);

                #endregion
            }
            catch
            {
                return new Response<VirtualSale?>(null, 500, "Não foi possível buscar a venda virtual");
            }
        }

        public async Task<Response<VirtualSale?>> UpdateAsync(UpdateVirtualSaleRequest request)
        {
            try
            {
                #region 01. Buscar venda virtual
                var virtualSale = await context
                    .VirtualSales
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (virtualSale is null)
                    return new Response<VirtualSale?>(null, 404, "Venda virtual não encontrada");
                #endregion

                #region 02. Validar Transação

                var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();
                string errors = string.Empty;

                if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
                {
                    return new Response<VirtualSale?>(null, 400, string.Join(". ", validationResults.Select(r => r.ErrorMessage)));
                }

                #endregion


                #region 03. Transferir os dados da Requisição para a venda virtual                
                mapper.Map(request, virtualSale);

                #endregion

                #region 04. Salvar alterações
                await context.SaveChangesAsync();

                #endregion

                #region 05. Retornar Resposta
                return new Response<VirtualSale?>(virtualSale, 200, "Venda virtual atualizada com sucesso!");

                #endregion
            }
            catch
            {
                return new Response<VirtualSale?>(null, 500, "Não foi possível atualizar a venda virtual");
            }
        }
    }
}
