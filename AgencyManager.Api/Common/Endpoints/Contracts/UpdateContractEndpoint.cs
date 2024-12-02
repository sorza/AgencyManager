﻿using AgencyManager.Api.Common.Api;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.ContractService;
using AgencyManager.Core.Responses;

namespace AgencyManager.Api.Common.Endpoints.Contracts
{
    public class UpdateContractEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
         => app.MapPut("/{id}", HandleAsync)
            .WithName("Contracts: Update")
            .WithSummary("Atualiza um contrato")
            .WithDescription("Atualiza um contrato")
            .Produces<Response<ContractService?>>();

        private static async Task<IResult> HandleAsync(
            IContractHandler handler,
            UpdateContractServiceRequest request,
            int id)
        {
            request.UserId = "teste@teste.com";
            request.Id = id;

            var result = await handler.UpdateAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
