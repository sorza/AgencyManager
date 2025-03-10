﻿using AgencyManager.Core.Handlers;
using AgencyManager.Core.Requests.Employee;
using AgencyManager.Core.Responses;
using AgencyManager.Core.Responses.DTOs;
using System.Net.Http.Json;

namespace AgencyManager.Web.Handlers
{
    public class EmployeeHandler(IHttpClientFactory httpClientFactory) : IEmployeeHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
        public async Task<Response<EmployeeDto?>> CreateAsync(CreateEmployeeRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/employees", request);
            return await result.Content.ReadFromJsonAsync<Response<EmployeeDto?>>()
                ?? new Response<EmployeeDto?>(null, 400, "Falha ao criar funcionário.");
        }

        public async Task<Response<EmployeeDto?>> DeleteAsync(DeleteEmployeeRequest request)
        {
            var result = await _client.DeleteAsync($"v1/employees/id?id={request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<EmployeeDto?>>()
                ?? new Response<EmployeeDto?>(null, 400, "Falha ao deletar funcionário.");
        }

        public async Task<PagedResponse<List<EmployeeDto>?>> GetAllByAgencyIdAsync(GetAllEmployeesByAgencyIdRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<EmployeeDto>?>>($"v1/employees/agency/{request.AgencyId}?pageNumber={request.PageNumber}&pageSize={request.PageSize}")
            ?? new PagedResponse<List<EmployeeDto>?>(null, 400, "Falha ao buscar funcionários da agência.");

        public async Task<Response<EmployeeDto?>> GetByIdAsync(GetEmployeeByIdRequest request)
        => await _client.GetFromJsonAsync<Response<EmployeeDto?>>($"v1/employees/{request.Id}")
            ?? new Response<EmployeeDto?>(null, 400, "Falha ao buscar funcionário.");

        public async Task<Response<EmployeeDto?>> GetByUsernameAsync(GetEmployeeByUsernameRequest request)
        => await _client.GetFromJsonAsync<Response<EmployeeDto?>>($"v1/employees")
            ?? new Response<EmployeeDto?>(null, 400, "Falha ao buscar funcionário.");

        public async Task<Response<EmployeeDto?>> UpdateAsync(UpdateEmployeeRequest request)
        {
            var result = await _client.PutAsJsonAsync($"v1/employees/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<EmployeeDto?>>()
                ?? new Response<EmployeeDto?>(null, 400, "Falha ao atualizar funcionário.");
        }
    }
}
