﻿using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Position;
using AgencyManager.Core.Responses;
using AgencyManager.Core.Responses.DTOs;
using System.Net.Http.Json;

namespace AgencyManager.Web.Handlers
{
    public class PositionHandler(IHttpClientFactory httpClientFactory) : IPositionHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
        public async Task<Response<PositionDto?>> CreateAsync(CreatePositionRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/positions", request);
            return await result.Content.ReadFromJsonAsync<Response<PositionDto?>>()
                ?? new Response<PositionDto?>(null, 400, "Falha ao criar cargo");
        }

        public async Task<Response<PositionDto?>> DeleteAsync(DeletePositionRequest request)
        {
            var result = await _client.DeleteAsync($"v1/positions/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<PositionDto?>>()
                ?? new Response<PositionDto?>(null, 400, "Falha ao deletar cargo");
        }

        public async Task<PagedResponse<List<PositionDto>?>> GetAllByAgencyIdAsync(GetPositionsByAgencyIdRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<PositionDto>?>>($"v1/positions/agency/{request.AgencyId}")
            ?? new PagedResponse<List<PositionDto>?>(null, 400, "Falha ao buscar cargos da agência");

        public async Task<Response<PositionDto?>> GetByIdAsync(GetPositionByIdRequest request)
        => await _client.GetFromJsonAsync<Response<PositionDto?>>($"v1/positions/{request.Id}")
            ?? new Response<PositionDto?>(null, 400, "Falha ao buscar cargo");

        public async Task<Response<PositionDto?>> UpdateAsync(UpdatePositionRequest request)
        {
            var result = await _client.PutAsJsonAsync($"v1/positions/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<PositionDto?>>()
                ?? new Response<PositionDto?>(null, 400, "Falha ao atualizar cargo");
        }
    }
}
