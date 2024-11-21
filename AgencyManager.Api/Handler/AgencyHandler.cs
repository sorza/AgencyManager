using AgencyManager.Api.Data;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Models.Entities.ValueObjects;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Api.Handler
{
    public class AgencyHandler(AppDbContext context, IMapper mapper) : IAgencyHandler
    {
        public async Task<Response<Agency?>> CreateAsync(CreateAgencyRequest request)
        {
            #region 01. Validar requisição

            var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();
            string errors = string.Empty;

            if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
            {
                foreach (var error in validationResults)
                    errors += error.ErrorMessage;
                return new Response<Agency?>(null, 400, errors);
            }              
           
            #endregion

            #region 02. Mapear propriedades e criar agencia
            try
            {              
                var agency = mapper.Map<Agency>(request);

                await context.Agencies.AddAsync(agency);
                await context.SaveChangesAsync();

                return new Response<Agency?>(agency, 201, "Agência criada com sucesso.");
            }
            catch
            {
                return new Response<Agency?>(null, 500, "Não foi possível criar agência");
            }
            #endregion
        }

        public async Task<Response<Agency?>> DeleteAsync(DeleteAgencyRequest request)
        {
            try
            {
                #region 01. Buscar agência
                var agency = await context.Agencies
                  .Include(a => a.Address)
                  .Include(a => a.Contacts)
                  .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (agency is null)
                    return new Response<Agency?>(null, 404, "Agência não encontrada");

                #endregion

                #region 02. Remover contatos
                context.Contacts.RemoveRange(agency.Contacts!);

                #endregion               

                #region 03. Remover agencia
                context.Agencies.Remove(agency);

                #endregion

                #region 04. Salvar Alterações
                await context.SaveChangesAsync();
                #endregion

                #region 05. Retornar resposta
                return new Response<Agency?>(agency, 204, "Agência excluída com sucesso");
                #endregion

            }
            catch
            {
                return new Response<Agency?>(null, 500, "Não foi possível excluir a agência");
            }
            
        }

        public async Task<PagedResponse<List<Agency>?>> GetAllAsync(GetAllAgenciesRequest request)
        {
            try
            {
                var query = context
                .Agencies                
                .Include(a => a.Address)
                .Include(a => a.Contacts)
                .AsNoTracking()
                .OrderBy(x => x.Description);

                var agencies = await query
                    .Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                return agencies is null
                        ? new PagedResponse<List<Agency>?>(null, 404, "Não foram encontrada agências cadastradas.")
                        : new PagedResponse<List<Agency>?>(agencies, count, request.PageNumber, request.PageSize);
            }
            catch 
            {
                return new PagedResponse<List<Agency>?>(null, 500, "Não possível consultar agências.");
            }           
        }

        public async Task<Response<Agency?>> GetByIdAsync(GetAgencyByIdRequest request)
        {
            try
            {
                var agency = await context.Agencies
                .AsNoTracking()
                .Include(a => a.Address)
                .Include(a => a.Contacts)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

                return agency is null
                    ? new Response<Agency?>(null, 404, "Agência não encontrada")
                    : new Response<Agency?>(agency);
            }
            catch 
            {
                return new Response<Agency?>(null, 500, "Não foi possível recuperar a agência.");
            }                
        }

        public async Task<Response<Agency?>> UpdateAsync(UpdateAgencyRequest request)
        {
            try
            {
                #region 01. Buscar agência
                var agency = await context.Agencies
                   .Include(a => a.Address)
                   .Include(a => a.Contacts)
                   .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (agency is null)
                    return new Response<Agency?>(null, 404, "Agência não encontrada");

                #endregion

                #region 02. Validar requisição
                request.Validate();

                if (!request.IsValid)
                    return new Response<Agency?>(null, 400, "Requisição inválida.");

                #endregion

                #region 03. Remover Lista Contatos Antigos

                context.Contacts.RemoveRange(agency.Contacts!);
                #endregion

                #region 04. Mapear dados de Request para a Entidade
                mapper.Map(request, agency);

                #endregion

                #region 05. Salvar alterações
                await context.SaveChangesAsync();

                #endregion

                #region 06. Retornar Resposta
                return new Response<Agency?>(agency, 200, "Agência atualizada com sucesso");

                #endregion
            }
            catch
            {
                return new Response<Agency?>(null, 500, "Não foi possível alterar a agência");
            }
        }
    }
}
