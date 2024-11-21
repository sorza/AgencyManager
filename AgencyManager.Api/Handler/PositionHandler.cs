using AgencyManager.Api.Data;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Position;
using AgencyManager.Core.Responses;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Api.Handler
{
    public class PositionHandler(AppDbContext context, IMapper mapper) : IPositionHandler
    {
        public async Task<Response<Position>> CreateAsync(CreatePositionRequest request)
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
                return new Response<Position>(null, 500, "Não foi possível cadastrar o cargo");
            }
           
        }

        public Task<Response<Position>> DeleteAsync(DeletePositionRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<List<Position>?>> GetAllByAgencyIdAsync(GetPositionsByAgencyIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Position>> UpdateAsync(UpdatePositionRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
