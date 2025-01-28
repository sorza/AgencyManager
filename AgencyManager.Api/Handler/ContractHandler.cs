using AgencyManager.Api.Data;
using AgencyManager.Core.DTOs;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.ContractService;
using AgencyManager.Core.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Api.Handler
{
    public class ContractHandler(AppDbContext context, IMapper mapper) : IContractHandler
    {
        public async Task<Response<ContractDto?>> CreateAsync(CreateContractServiceRequest request)
        {
            try
            {
                #region 01. Validar contrato
                var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();
                string errors = string.Empty;

                if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
                    return new Response<ContractDto?>(null, 400, string.Join(". ", validationResults.Select(r => r.ErrorMessage)));
                #endregion

                #region 02. Mapear dados para contrato
                var contract = mapper.Map<ContractService>(request);

                #endregion

                #region 03. Adicionar contrato
                await context.Contracts.AddAsync(contract);
                await context.SaveChangesAsync();

                #endregion

                #region 04. Retornar resposta
                return new Response<ContractDto?>(mapper.Map<ContractDto>(contract), 200, "Contrato registrado com sucesso!");

                #endregion
            }
            catch
            {
                return new Response<ContractDto?>(null, 500, "Não foi possível registrar o contrato");
            }
        }

        public async Task<Response<ContractDto?>> DeleteAsync(DeleteContractServiceRequest request)
        {
            try
            {
                #region 01. Buscar contrato
                var contract = await context.Contracts.FirstOrDefaultAsync(x => x.Id == request.Id);

                #endregion

                #region 02. Verificar se é nulo
                if (contract is null) return new Response<ContractDto?>(null, 404, "Contrato não encontrado");

                #endregion

                #region 03. Excluir contrato
                context.Contracts.Remove(contract);
                await context.SaveChangesAsync();

                #endregion

                #region 04. Retornar resposta
                return new Response<ContractDto?>(mapper.Map<ContractDto>(contract), 200, "Contrato excluído com sucesso");

                #endregion
            }
            catch
            {
                return new Response<ContractDto?>(null, 500, "Não foi possível excluir o contrato");
            }
        }

        public async Task<PagedResponse<List<ContractDto>?>> GetByAgencyIdAsync(GetAllContractsByAgencyRequest request)
        {
            try
            {
                #region 01. Buscar contratos por agencia
                var query = context
                .Contracts
                .Where(x => x.AgencyId == request.AgencyId)
                .Include(x => x.Agency)
                .Include(x => x.Company)
                .Include(x => x.NfeData)
                .AsNoTracking();

                #endregion

                #region 02. Paginar de acordo com o especificado
                var contracts = await query
                    .Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize)
                    .ToListAsync();

                #endregion

                #region 03. Obter quantidade de contratos
                var count = await query.CountAsync();

                #endregion

                #region 04. Retornar Resposta
                return contracts is null
                        ? new PagedResponse<List<ContractDto>?>(null, 404, "Não foram encontrados contratos para esta agência.")
                        : new PagedResponse<List<ContractDto>?>(mapper.Map<List<ContractDto>>(contracts), count, request.PageNumber, request.PageSize);
                #endregion
            }
            catch
            {
                return new PagedResponse<List<ContractDto>?>(null, 500, "Não possível consultar os contratos.");
            }
        }

        public async Task<Response<ContractDto?>> GetByIdAsync(GetContractByIdRequest request)
        {
            try
            {
                #region 01. Buscar contrato
                var contract = await context
                    .Contracts
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (contract is null)
                    return new Response<ContractDto?>(null, 404, "Contrato não encontrado");
                #endregion

                #region 02. Retorna resposta
                return new Response<ContractDto?>(mapper.Map<ContractDto>(contract), 200);

                #endregion
            }
            catch
            {
                return new Response<ContractDto?>(null, 500, "Não foi possível buscar o contrato");
            }
        }

        public async Task<Response<ContractDto?>> UpdateAsync(UpdateContractServiceRequest request)
        {
            try
            {
                #region 01. Buscar contrato
                var contract = await context
                    .Contracts
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (contract is null)
                    return new Response<ContractDto?>(null, 404, "Contrato não encontrado.");
                #endregion

                #region 02. Validar Contrato

                var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();
                string errors = string.Empty;

                if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
                {
                    return new Response<ContractDto?>(null, 400, string.Join(". ", validationResults.Select(r => r.ErrorMessage)));
                }

                #endregion

                #region 03. Transferir os dados da requisição para o contrato               
                mapper.Map(request, contract);

                #endregion

                #region 04. Salvar alterações
                await context.SaveChangesAsync();

                #endregion

                #region 05. Retornar Resposta
                return new Response<ContractDto?>(mapper.Map<ContractDto>(contract), 200, "Contrato atualizado com sucesso!");

                #endregion
            }
            catch
            {
                return new Response<ContractDto?>(null, 500, "Não foi possível atualizar o contrato");
            }
        }
    }
}
