using AgencyManager.Api.Data;
using AgencyManager.Core.DTOs;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Api.Handler
{
    public class AgencyHandler(AppDbContext context, IMapper mapper) : IAgencyHandler
    {
        public async Task<Response<AgencyDto?>> CreateAsync(CreateAgencyRequest request)
        {
            #region 01. Validar requisição

            var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();
            string errors = string.Empty;

            if (!Validator.TryValidateObject(request, validationContext, validationResults, true))            
                return new Response<AgencyDto?>(null, 400, string.Join(". ", validationResults.Select(r => r.ErrorMessage)));                        
           
            #endregion

            #region 02. Mapear propriedades e criar agencia
            try
            {               
                var agency = mapper.Map<Agency>(request);

                await context.Agencies.AddAsync(agency);

                await context.SaveChangesAsync();

                var agencyDto = mapper.Map<AgencyDto>(agency);

                return new Response<AgencyDto?>(agencyDto, 201, "Agência criada com sucesso.");
            }
            catch
            {
                return new Response<AgencyDto?>(null, 500, "Não foi possível criar agência");
            }
            #endregion
        }

        public async Task<Response<AgencyDto?>> DeleteAsync(DeleteAgencyRequest request)
        {
            try
            {
                #region 01. Buscar agência
                var agency = await context.Agencies
                  .Include(a => a.Address)
                  .Include(a => a.Contacts)
                  .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (agency is null)
                    return new Response<AgencyDto?>(null, 404, "Agência não encontrada");

                #endregion

                #region 02. Remover contatos
                if(agency.Contacts is not null)
                    context.Contacts.RemoveRange(agency.Contacts!);

                #endregion               

                #region 03. Remover agencia
                context.Agencies.Remove(agency);

                #endregion

                #region 04. Salvar Alterações
                await context.SaveChangesAsync();
                #endregion

                #region 05. Retornar resposta

                var agencyDto = mapper.Map<AgencyDto>(agency);
                return new Response<AgencyDto?>(agencyDto, 204, "Agência excluída com sucesso");
                #endregion

            }
            catch
            {
                return new Response<AgencyDto?>(null, 500, "Não foi possível excluir a agência");
            }
            
        }

        public async Task<PagedResponse<List<AgencyDto>?>> GetAllAsync(GetAllAgenciesRequest request)
        {
            try
            {
                var query = context
                .Agencies                
                .Include(a => a.Address)
                .AsNoTracking()
                .OrderBy(x => x.Description);

                var agencies = await query
                    .Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                var agenciesDto = mapper.Map<List<AgencyDto>>(agencies);

                return agenciesDto is null
                        ? new PagedResponse<List<AgencyDto>?>(null, 404, "Não foram encontrada agências cadastradas.")
                        : new PagedResponse<List<AgencyDto>?>(agenciesDto, count, request.PageNumber, request.PageSize);
            }
            catch 
            {
                return new PagedResponse<List<AgencyDto>?>(null, 500, "Não possível consultar agências.");
            }           
        }

        public async Task<Response<AgencyDto?>> GetByIdAsync(GetAgencyByIdRequest request)
        {
            try
            {
                var agency = await context.Agencies
                .AsNoTracking()
                .Include(a => a.Address)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

                var agencyDto = mapper.Map<AgencyDto>(agency);

                return agencyDto is null
                    ? new Response<AgencyDto?>(null, 404, "Agência não encontrada")
                    : new Response<AgencyDto?>(agencyDto);
            }
            catch 
            {
                return new Response<AgencyDto?>(null, 500, "Não foi possível recuperar a agência.");
            }                
        }

        public async Task<Response<AgencyDto?>> UpdateAsync(UpdateAgencyRequest request)
        {
            try
            {
                #region 01. Buscar agência
                var agency = await context.Agencies
                   .Include(a => a.Address)
                   .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (agency is null)
                    return new Response<AgencyDto?>(null, 404, "Agência não encontrada");

                #endregion

                #region 02. Validar requisição
                var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();
                string errors = string.Empty;

                if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
                    return new Response<AgencyDto?>(null, 400, string.Join(". ", validationResults.Select(r => r.ErrorMessage)));

                #endregion

                #region 03. Mapear dados de Request para a Entidade
                mapper.Map(request, agency);

                #endregion

                #region 04. Salvar alterações
                await context.SaveChangesAsync();

                #endregion

                #region 05. Retornar Resposta
                var agencyDto = mapper.Map<AgencyDto>(agency);
                return new Response<AgencyDto?>(agencyDto, 200, "Agência atualizada com sucesso");

                #endregion
            }
            catch
            {
                return new Response<AgencyDto?>(null, 500, "Não foi possível alterar a agência");
            }
        }
    }
}
