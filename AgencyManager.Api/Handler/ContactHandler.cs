using AgencyManager.Api.Data;
using AgencyManager.Core.DTOs;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Contact;
using AgencyManager.Core.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Api.Handler
{
    public class ContactHandler(AppDbContext context, IMapper mapper) : IContactHandler
    {
        public async Task<Response<ContactDto?>> CreateAsync(CreateContactRequest request)
        {
            try
            {                
                #region 01. Validar contato
                var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();               

                if (!Validator.TryValidateObject(request, validationContext, validationResults, true))                                    
                    return new Response<ContactDto?>(null, 400, string.Join(". ", validationResults.Select(r => r.ErrorMessage)));                

                #endregion

                #region 02. Mapear requisição para um contato
                var contact = mapper.Map<Contact>(request);

                #endregion

                #region 03. Adicionar contato
                await context.AddAsync(contact);  
                context.SaveChanges();

                #endregion

                #region 04. Retornar resposta
                return new Response<ContactDto?>(mapper.Map<ContactDto?>(contact), 201, "Contato criado com sucesso!");

                #endregion
            }
            catch 
            {
                return new Response<ContactDto?>(null, 500, "Não foi possível criar o contato.");
            }
        }
        public async Task<Response<ContactDto?>> UpdateAsync(UpdateContactRequest request)
        {
            try
            {
                #region 01. Buscar contato
                var contact = await context.Contacts
                   .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (contact is null)
                    return new Response<ContactDto?>(null, 404, "Contato não encontrado");
                #endregion

                #region 02. Validar Contato
               
                var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();
                string errors = string.Empty;

                if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
                {
                    return new Response<ContactDto?>(null, 400, string.Join(". ", validationResults.Select(r => r.ErrorMessage)));
                }

                #endregion

                #region 03. Transferir os dados da Requisição para o Contato
                mapper.Map(request, contact);

                #endregion

                #region 04. Salvar alterações
                await context.SaveChangesAsync();

                #endregion

                #region 05. Retornar Resposta
                return new Response<ContactDto?>(mapper.Map<ContactDto?>(contact), 200, "Contato atualizado com sucesso");

                #endregion
            }
            catch
            {
                return new Response<ContactDto?>(null, 500, "Não foi possível atualizar o contato");
            }
        }
        public async Task<Response<ContactDto?>> DeleteAsync(DeleteContactRequest request)
        {
            try
            {
                #region 01. Buscar contato
                var contact = await context.Contacts
                   .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (contact is null)
                    return new Response<ContactDto?>(null, 404, "Contato não encontrado");
                #endregion

                #region 02. Remover Contato
                context.Contacts.Remove(contact);
                await context.SaveChangesAsync();

                #endregion

                #region 03. Retornar Resposta
                return new Response<ContactDto?>(mapper.Map<ContactDto?>(contact), 200, "Contato removido com sucesso");

                #endregion
            }
            catch
            {
                return new Response<ContactDto?>(null, 500, "Não foi possível remover o contato");
            }
        }
        public async Task<PagedResponse<List<ContactDto>?>> GetAllByAgencyAsync(GetContactsByAgencyId request)
        {
            try
            {
                #region 01. Buscar contatos por agencia
                var query = context
                .Contacts
                .Where(x=>x.AgencyId == request.AgencyId)
                .AsNoTracking();

                #endregion

                #region 02. Paginar de acordo com o especificado
                var contacts = await query
                    .Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize)
                    .ToListAsync();

                #endregion

                #region 03. Obter quantidade de contatos
                var count = await query.CountAsync();

                #endregion

                #region 04. Retornar Resposta
                return contacts.Count == 0
                        ? new PagedResponse<List<ContactDto>?>(null, 404, "Não foram encontrados contatos para esta agencia.")
                        : new PagedResponse<List<ContactDto>?>(mapper.Map<List<ContactDto>?>(contacts), count, request.PageNumber, request.PageSize);
                #endregion
            }
            catch
            {
                return new PagedResponse<List<ContactDto>?>(null, 500, "Não possível consultar os contatos desta agência.");
            }
        }
        public async Task<PagedResponse<List<ContactDto>?>> GetAllByCompanyAsync(GetContactsByCompanyId request)
        {
            try
            {
                #region 01. Buscar contatos por empresa
                var query = context
                .Contacts
                .Where(x => x.CompanyId == request.CompanyId)
                .AsNoTracking();

                #endregion

                #region 02. Paginar de acordo com o especificado
                var contacts = await query
                    .Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize)
                    .ToListAsync();

                #endregion

                #region 03. Obter quantidade de contatos
                var count = await query.CountAsync();

                #endregion

                #region 04. Retornar Resposta
                return contacts.Count == 0
                        ? new PagedResponse<List<ContactDto>?>(null, 404, "Não foram encontrados contatos para esta agencia.")
                        : new PagedResponse<List<ContactDto>?>(mapper.Map<List<ContactDto>?>(contacts), count, request.PageNumber, request.PageSize);
                #endregion
            }
            catch
            {
                return new PagedResponse<List<ContactDto>?>(null, 500, "Não possível consultar os contatos desta empresa.");
            }
        }
        public async Task<PagedResponse<List<ContactDto>?>> GetAllByEmployeeAsync(GetContactsByEmployeeId request)
        {
            try
            {
                #region 01. Buscar contatos por colaborador
                var query = context
                .Contacts
                .Where(x => x.EmployeeId == request.EmployeeId)
                .AsNoTracking();

                #endregion

                #region 02. Paginar de acordo com o especificado
                var contacts = await query
                    .Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize)
                    .ToListAsync();

                #endregion

                #region 03. Obter quantidade de contatos
                var count = await query.CountAsync();

                #endregion

                #region 04. Retornar Resposta
                return contacts.Count == 0
                        ? new PagedResponse<List<ContactDto>?>(null, 404, "Não foram encontrados contatos para este colaborador.")
                        : new PagedResponse<List<ContactDto>?>(mapper.Map<List<ContactDto>?>(contacts), count, request.PageNumber, request.PageSize);
                #endregion
            }
            catch
            {
                return new PagedResponse<List<ContactDto>?>(null, 500, "Não possível consultar os contatos deste colaborador.");
            }
        }
        public async Task<Response<ContactDto?>> GetByIdAsync(GetContactByIdRequest request)
        {
            try
            {
                #region 01. Buscar contato
                var contact = await context.Contacts
                   .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (contact is null)
                    return new Response<ContactDto?>(null, 404, "Contato não encontrado");
                #endregion

                #region 02. Retornar Resposta
                return new Response<ContactDto?>(mapper.Map<ContactDto?>(contact), 200);

                #endregion
            }
            catch
            {
                return new Response<ContactDto?>(null, 500, "Não possível recuperar o contato.");
            }
        }        
        
    }
}
