using AgencyManager.Api.Data;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Position;
using AgencyManager.Core.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Api.Handler
{
    public class PositionHandler(AppDbContext context, IMapper mapper) : IPositionHandler
    {
        public async Task<Response<Position?>> CreateAsync(CreatePositionRequest request)
        {
            try
            {
                #region 01. Validar cargo
                var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();
                string errors = string.Empty;

                if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
                    return new Response<Position>(null, 400, string.Join(". ", validationResults.Select(r => r.ErrorMessage)));
                #endregion

                #region 02. Mapear dados da requisição para classe concreta
                var position = mapper.Map<Position>(request);

                #endregion

                #region 03. Adicionar cargo
                await context.Positions.AddAsync(position);
                await context.SaveChangesAsync();

                #endregion

                #region 04. Retornar resposta
                return new Response<Position>(position, 200, "Cargo cadastrado com sucesso!");

                #endregion
            }
            catch
            {
                return new Response<Position?>(null, 500, "Não foi possível cadastrar o cargo");
            }
           
        }
        public async Task<Response<Position?>> DeleteAsync(DeletePositionRequest request)
        {
            try
            {
                #region 01. Buscar contato
                var position = await context.Positions.FirstOrDefaultAsync(x => x.Id == request.Id);

                #endregion

                #region 02. Verificar se é nulo
                if (position is null) return new Response<Position>(null, 404, "Cargo não encontrado");

                #endregion

                #region 03. Excluir contato
                context.Positions.Remove(position);
                await context.SaveChangesAsync();

                #endregion

                #region 04. Retornar resposta
                return new Response<Position>(position, 200, "Cargo excluído com sucesso");

                #endregion
            }
            catch
            {
                return new Response<Position?>(null, 500, "Não foi possível excluir o cargo");
            }
           
        }
        public async Task<PagedResponse<List<Position>?>> GetAllByAgencyIdAsync(GetPositionsByAgencyIdRequest request)
        {
            try
            {
                #region 01. Buscar cargos por agencia
                var query = context
                .Positions
                .Where(x => x.AgencyId == request.AgencyId)
                .AsNoTracking();

                #endregion

                #region 02. Paginar de acordo com o especificado
                var positions = await query
                    .Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize)
                    .ToListAsync();

                #endregion

                #region 03. Obter quantidade de cargos
                var count = await query.CountAsync();

                #endregion

                #region 04. Retornar Resposta
                return positions is null
                        ? new PagedResponse<List<Position>?>(null, 404, "Não foram encontrados cargos para esta agencia.")
                        : new PagedResponse<List<Position>?>(positions, count, request.PageNumber, request.PageSize);
                #endregion
            }
            catch
            {
                return new PagedResponse<List<Position>?>(null, 500, "Não possível consultar os cargos.");
            }
        }
        public async Task<Response<Position?>> GetByIdAsync(GetPositionByIdRequest request)
        {
            try
            {
                var position = await context
                   .Positions
                   .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (position is null)
                    return new Response<Position?>(null, 404, "Cargo não encontrado");

                return new Response<Position?>(position, 200);
            }
            catch 
            {
                return new Response<Position?>(null, 500, "Não foi possível consultar o cargo");
            }
        }
        public async Task<Response<Position?>> UpdateAsync(UpdatePositionRequest request)
        {
            try
            {
                #region 01. Buscar Cargo
                var position = await context
                    .Positions
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (position is null)
                    return new Response<Position?>(null, 404, "Cargo não encontrado");
                #endregion

                #region 02. Validar Cargo

                var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();
                string errors = string.Empty;

                if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
                {
                    return new Response<Position>(null, 400, string.Join(". ", validationResults.Select(r => r.ErrorMessage)));
                }

                #endregion

                #region 03. Transferir os dados da Requisição para o Contato                
                mapper.Map(request, position);

                #endregion

                #region 04. Salvar alterações
                await context.SaveChangesAsync();

                #endregion

                #region 05. Retornar Resposta
                return new Response<Position?>(position, 200, "Cargo atualizado com sucesso");

                #endregion
            }
            catch
            {
                return new Response<Position?>(null, 500, "Não foi possível atualizar o cargo");
            }
        }
    }
}
