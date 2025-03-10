﻿using AgencyManager.Api.Data;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Employee;
using AgencyManager.Core.Responses;
using AgencyManager.Core.Responses.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Api.Handler
{
    public class EmployeeHandler(AppDbContext context, IMapper mapper) : IEmployeeHandler
    {
        public async Task<Response<EmployeeDto?>> CreateAsync(CreateEmployeeRequest request)
        {
            try
            {
                #region 01. Validar Colaborador
                var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();
                string errors = string.Empty;

                if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
                    return new Response<EmployeeDto?>(null, 400, string.Join(". ", validationResults.Select(r => r.ErrorMessage)));

                #endregion

                #region 02. Mapear dados da requisição para classe concreta
                var employee = mapper.Map<Employee>(request);

                #endregion

                #region 03. Cadastrar colaborador
                await context.Employees.AddAsync(employee);
                await context.SaveChangesAsync();

                #endregion

                #region 04. Retornar resposta
                return new Response<EmployeeDto?>(mapper.Map<EmployeeDto>(employee), 201, "Colaborador cadastrado com sucesso.");

                #endregion

            }
            catch 
            {
                return new Response<EmployeeDto?>(null, 500, "Não foi possível cadastrar o colaborador");
            }
        }
        public async Task<Response<EmployeeDto?>> DeleteAsync(DeleteEmployeeRequest request)
        {
            try
            {
                #region 01. Buscar colaborador
                var employee = await context
                .Employees
                .Include(a => a.Address)
                .Include(a => a.Contacts)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (employee is null) return new Response<EmployeeDto?>(null, 404, "Colaborador não encontrado");

                #endregion

                #region 02. Remover contatos
                if (employee.Contacts is not null)
                    context.Contacts.RemoveRange(employee.Contacts);
                   
                #endregion

                #region 03. Remover colaborador
                context.Employees.Remove(employee);
                await context.SaveChangesAsync();

                #endregion

                #region 04. Retornar resposta             
                return new Response<EmployeeDto?>(mapper.Map<EmployeeDto>(employee), 200, "Colaborador excluído com sucesso");

                #endregion
            }
            catch
            {
                return new Response<EmployeeDto?>(null, 500, "Não foi possível excluir o colaborador");
            }
        }
        public async Task<PagedResponse<List<EmployeeDto>?>> GetAllByAgencyIdAsync(GetAllEmployeesByAgencyIdRequest request)
        {
            try
            {
                #region 01. Buscar colaboradores por agencia
                var query = context
                .Employees
                .AsNoTracking()
                .Include(a => a.Address)
                .Include(a => a.Contacts)
                .Include(a => a.Position)
                .Where(x => x.AgencyId == request.AgencyId);

                #endregion

                #region 02. Paginar de acordo com o especificado
                var employees = await query
                    .Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize)
                    .ToListAsync();

                #endregion

                #region 03. Obter quantidade de colaboradores
                var count = await query.CountAsync();

                #endregion

                #region 04. Retornar Resposta

                var employeeDtos = mapper.Map<List<EmployeeDto>>(employees);
                return new PagedResponse<List<EmployeeDto>?>(employeeDtos, count, request.PageNumber, request.PageSize);

                #endregion
            }
            catch
            {
                return new PagedResponse<List<EmployeeDto>?>(null, 500, "Não possível consultar os colaboradores.");
            }
        }
        public async Task<Response<EmployeeDto?>> GetByIdAsync(GetEmployeeByIdRequest request)
        {
            try
            {
                var employee = await context
                .Employees
                .AsNoTracking()
                .Include(a => a.Address)
                .Include(a => a.Contacts)
                .Include(a => a.Position)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (employee is null) return new Response<EmployeeDto?>(null, 404, "Colaborador não encontrado");

                return new Response<EmployeeDto?>(mapper.Map<EmployeeDto?>(employee), 200);
            }
            catch
            {
                return new Response<EmployeeDto?>(null, 500, "Não foi possível buscar colaborador");
            }            
        }

        public async Task<Response<EmployeeDto?>> GetByUsernameAsync(GetEmployeeByUsernameRequest request)
        {
            try
            {
                var employee = await context
                .Employees
                .AsNoTracking()
                .Include(a => a.Address)
                .Include(a => a.Contacts)
                .Include(a => a.Position)
                .FirstOrDefaultAsync(x => x.UserLogin == request.Username);

                if (employee is null) return new Response<EmployeeDto?>(null, 404, "Colaborador não encontrado");

                return new Response<EmployeeDto?>(mapper.Map<EmployeeDto?>(employee), 200);
            }
            catch
            {
                return new Response<EmployeeDto?>(null, 500, "Não foi possível buscar colaborador");
            }
        }
        public async Task<Response<EmployeeDto?>> UpdateAsync(UpdateEmployeeRequest request)
        {
            try
            {
                #region 01. Buscar colaborador
                var employee = await context
                .Employees
                .Include(a => a.Address)
                .Include(a => a.Contacts)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (employee is null) return new Response<EmployeeDto?>(null, 404, "Colaborador não encontrado");

                #endregion

                #region 02. Validar Colaborador
                var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();
                string errors = string.Empty;

                if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
                    return new Response<EmployeeDto?>(null, 400, string.Join(". ", validationResults.Select(r => r.ErrorMessage)));

                #endregion

                #region 03. Atualizar lita de contatos
                if (employee.Contacts is not null && request.Contacts is not null)
                {
                    var novaListaContatos = mapper.Map<List<Contact>>(request.Contacts);
                    var contatosAExcluir = new List<Contact>();

                    foreach (var contact in employee.Contacts)
                        if (!novaListaContatos.Contains(contact))
                            contatosAExcluir.Add(contact);

                    foreach (var contact in contatosAExcluir)
                        context.Contacts.Remove(contact);
                }

                #endregion

                #region 04. Atualizar dados
                mapper.Map(request, employee);
                await context.SaveChangesAsync();

                #endregion

                #region 05. Retornar resposta
                return new Response<EmployeeDto?>(mapper.Map<EmployeeDto>(employee), 200, "Colaborador atualizado com sucesso!");
                
                #endregion

            }
            catch
            {
                return new Response<EmployeeDto?>(null, 500, "Não foi possível atualizar o colaborador");
            }
            
        }
    }
}
