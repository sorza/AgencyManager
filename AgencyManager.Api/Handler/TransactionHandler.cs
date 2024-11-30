using AgencyManager.Api.Data;
using AgencyManager.Core.Enums;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Transaction;
using AgencyManager.Core.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Api.Handler
{
    public class TransactionHandler(AppDbContext context, IMapper mapper) : ITransactionHandler
    {
        public async Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request)
        {
            try
            {
                #region 01. Validar transação
                var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();
                string errors = string.Empty;

                if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
                    return new Response<Transaction?>(null, 400, string.Join(". ", validationResults.Select(r => r.ErrorMessage)));
                #endregion


                #region 02. Verifica se o tipo de transação é Output
                if (request is { Type: ETransactionType.Output, Amount: >= 0 })
                    request.Amount *= -1;
                #endregion

                #region 03. Mapear dados para transação
                var transaction = mapper.Map<Transaction>(request);

                #endregion

                #region 04. Adicionar transação
                await context.Transactions.AddAsync(transaction);
                await context.SaveChangesAsync();

                #endregion

                #region 05. Retornar resposta
                return new Response<Transaction?>(transaction, 200, "Transação registrada com sucesso!");

                #endregion
            }
            catch
            {
                return new Response<Transaction?>(null, 500, "Não foi possível registrar a transação");
            }
        }
        public async Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request)
        {
            try
            {
                #region 01. Buscar transação
                var transaction = await context.Transactions.FirstOrDefaultAsync(x => x.Id == request.Id);

                #endregion

                #region 02. Verificar se é nulo
                if (transaction is null) return new Response<Transaction?>(null, 404, "Transação não encontrada");

                #endregion

                #region 03. Excluir transação
                context.Transactions.Remove(transaction);
                await context.SaveChangesAsync();

                #endregion

                #region 04. Retornar resposta
                return new Response<Transaction?>(transaction, 200, "Transação excluída com sucesso");

                #endregion
            }
            catch
            {
                return new Response<Transaction?>(null, 500, "Não foi possível excluir a transação");
            }
        }
        public async Task<PagedResponse<List<Transaction>?>> GetAllByCashAsync(GetTransactionsByCashIdRequest request)
        {
            try
            {
                #region 01. Buscar transações por caixa
                var query = context
                .Transactions
                .Where(x => x.CashId == request.CashId)
                .AsNoTracking();

                #endregion

                #region 02. Paginar de acordo com o especificado
                var transactions = await query
                    .Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize)
                    .ToListAsync();

                #endregion

                #region 03. Obter quantidade de transações
                var count = await query.CountAsync();

                #endregion

                #region 04. Retornar Resposta
                return transactions is null
                        ? new PagedResponse<List<Transaction>?>(null, 404, "Não foram encontradas transações para este caixa.")
                        : new PagedResponse<List<Transaction>?>(transactions, count, request.PageNumber, request.PageSize);
                #endregion
            }
            catch
            {
                return new PagedResponse<List<Transaction>?>(null, 500, "Não possível consultar as transações.");
            }
        }
        public async Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request)
        {
            try
            {
                #region 01. Buscar transação
                var transaction = await context
                    .Transactions
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (transaction is null)
                    return new Response<Transaction?>(null, 404, "Transação não encontrada");
                #endregion

                #region 02. Retorna resposta
                return new Response<Transaction?>(transaction, 200);

                #endregion
            }
            catch
            {
                return new Response<Transaction?>(null, 500, "Não foi possível buscar a transação");
            }
        }
        public async Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request)
        {
            try
            {
                #region 01. Buscar Transação
                var transaction = await context
                    .Transactions
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (transaction is null)
                    return new Response<Transaction?>(null, 404, "Transação não encontrada");
                #endregion

                #region 02. Validar Transação

                var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();
                string errors = string.Empty;

                if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
                {
                    return new Response<Transaction?>(null, 400, string.Join(". ", validationResults.Select(r => r.ErrorMessage)));
                }

                #endregion

                #region 03. Verifica se o tipo de transação é Output
                if (request is { Type: ETransactionType.Output, Amount: >= 0 })
                    request.Amount *= -1;
                #endregion

                #region 04. Transferir os dados da Requisição para a transação                
                mapper.Map(request, transaction);

                #endregion

                #region 05. Salvar alterações
                await context.SaveChangesAsync();

                #endregion

                #region 06. Retornar Resposta
                return new Response<Transaction?>(transaction, 200, "Transação atualizada com sucesso");

                #endregion
            }
            catch
            {
                return new Response<Transaction?>(null, 500, "Não foi possível atualizar a transação");
            }
        }
    }
}
