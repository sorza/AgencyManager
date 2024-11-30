using AgencyManager.Api.Data;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Locality;
using AgencyManager.Core.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Api.Handler
{
    public class LocalityHandler(AppDbContext context, IMapper mapper) : ILocalityHandler
    {
        public async Task<Response<Locality?>> CreateAsync(CreateLocalityRequest request)
        {
            try
            {
                #region 01. Validar localidade
                var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();

                if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
                    return new Response<Locality?>(null, 400, string.Join(". ", validationResults.Select(r => r.ErrorMessage)));

                #endregion

                #region 02. Verifica se já existe este localidade cadastrada
                if(context.Localities.Any(x => x.City.Equals(request.City) && x.State.Equals(request.State)))
                    return new Response<Locality?>(null, 400, "Localidade já cadastrada.");

                #endregion

                #region 03. Mapear requisição para uma localidade
                var locality = mapper.Map<Locality>(request);

                #endregion

                #region 04. Adicionar localidade
                await context.Localities.AddAsync(locality);
                context.SaveChanges();

                #endregion

                #region 05. Retornar resposta
                return new Response<Locality?>(locality, 201, "Localidade criada com sucesso!");

                #endregion
            }
            catch
            {
                return new Response<Locality?>(null, 500, "Não foi possível criar a localidade.");
            }
        }

        public async Task<Response<Locality?>> DeleteAsync(DeleteLocalityRequest request)
        {
            try
            {
                #region 01. Buscar localidade
                var locality = await context.Localities
                   .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (locality is null)
                    return new Response<Locality?>(null, 404, "Localidade não encontrada");
                #endregion

                #region 02. Remover Localidade
                context.Localities.Remove(locality);
                await context.SaveChangesAsync();

                #endregion

                #region 03. Retornar Resposta
                return new Response<Locality?>(locality, 200, "Localidade removida com sucesso");

                #endregion
            }
            catch
            {
                return new Response<Locality?>(null, 500, "Não foi possível remover a localidade");
            }
        }

        public async Task<PagedResponse<List<Locality>?>> GetAllAsync(GetAllLocalitiesRequest request)
        {
            try
            {
                var query = context
                .Localities                
                .AsNoTracking()
                .OrderBy(x => x.City);

                var localities = await query
                    .Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                return localities is null
                        ? new PagedResponse<List<Locality>?>(null, 404, "Não foram encontradas localidades cadastradas.")
                        : new PagedResponse<List<Locality>?>(localities, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Locality>?>(null, 500, "Não possível buscar localidades.");
            }
        }

        public async Task<Response<Locality?>> GetByIdAsync(GetLocalityByIdRequest request)
        {
            try
            {
                var locality = await context
                   .Localities
                   .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (locality is null)
                    return new Response<Locality?>(null, 404, "Localidade não encontrada");

                return new Response<Locality?>(locality, 200);
            }
            catch
            {
                return new Response<Locality?>(null, 500, "Não foi possível consultar a localidade");
            }
        }

        public async Task<Response<Locality?>> UpdateAsync(UpdateLocalityRequest request)
        {
            try
            {
                #region 01. Buscar localidade
                var locality = await context.Localities
                   .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (locality is null)
                    return new Response<Locality?>(null, 404, "Localidade não encontrada.");
                #endregion               

                #region 02. Validar localidade

                var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();
                string errors = string.Empty;

                if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
                {
                    return new Response<Locality?>(null, 400, string.Join(". ", validationResults.Select(r => r.ErrorMessage)));
                }

                #endregion

                #region 03. Verifica se já existe este localidade cadastrada
                if (context.Localities.Any(x => x.City.Equals(request.City) && x.State.Equals(request.State)))
                    return new Response<Locality?>(null, 400, "Localidade já cadastrada.");

                #endregion

                #region 03. Transferir os dados da Requisição para Localidade
                mapper.Map(request, locality);

                #endregion

                #region 04. Salvar alterações
                await context.SaveChangesAsync();

                #endregion

                #region 05. Retornar Resposta
                return new Response<Locality?>(locality, 200, "Localidade atualizada com sucesso");

                #endregion
            }
            catch
            {
                return new Response<Locality?>(null, 500, "Não foi possível atualizar a localidade");
            }
        }
    }
}
