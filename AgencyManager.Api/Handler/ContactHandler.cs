using AgencyManager.Api.Data;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Requests.Contact;
using AgencyManager.Core.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AgencyManager.Api.Handler
{
    public class ContactHandler(AppDbContext context, IMapper mapper) : IContactHandler
    {
        public async Task<Response<Contact>> CreateAsync(CreateContactRequest request)
        {
            try
            {
                #region 01. Validar contato
                request.Validate();

                if(!request.IsValid)
                    return new Response<Contact>(null, 400, string.Join(", ", request.Notifications.Select(n => n.Message)));

                #endregion

                #region 02. Mapear requisição para um contato
                var contact = mapper.Map<Contact>(request);

                #endregion

                #region 03. Adicionar contato
                await context.AddAsync(contact);  
                context.SaveChanges();

                #endregion

                #region 04. Retornar resposta
                return new Response<Contact>(contact, 201, "Contato criado com sucesso!");

                #endregion
            }
            catch 
            {
                return new Response<Contact>(null, 500, "Não foi possível criar o contato.");
            }
        }
        public async Task<Response<Contact>> UpdateAsync(UpdateContactRequest request)
        {
            try
            {
                #region 01. Buscar contato
                var contact = await context.Contacts
                   .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (contact is null)
                    return new Response<Contact>(null, 404, "Contato não encontrado");
                #endregion

                #region 02. Validar Contato
                request.Validate();

                if (!request.IsValid)
                    return new Response<Contact>(null, 400, "Contato inválido.");

                #endregion

                #region 03. Transferir os dados da Requisição para o Contato
                mapper.Map(request, contact);

                #endregion

                #region 04. Salvar alterações
                await context.SaveChangesAsync();

                #endregion

                #region 05. Retornar Resposta
                return new Response<Contact>(contact, 200, "Contato atualizado com sucesso");

                #endregion
            }
            catch
            {
                return new Response<Contact>(null, 500, "Não foi possível atualizar o contato");
            }
        }
        public async Task<Response<Contact>> DeleteAsync(DeleteContactRequest request)
        {
            try
            {
                #region 01. Buscar contato
                var contact = await context.Contacts
                   .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (contact is null)
                    return new Response<Contact>(null, 404, "Contato não encontrado");
                #endregion

                #region 02. Remover Contato
                context.Contacts.Remove(contact);
                await context.SaveChangesAsync();

                #endregion

                #region 03. Retornar Resposta
                return new Response<Contact>(contact, 200, "Contato removido com sucesso");

                #endregion
            }
            catch
            {
                return new Response<Contact>(null, 500, "Não foi possível remover o contato");
            }
        }
        public async Task<PagedResponse<List<Contact>?>> GetAllByAgencyAsync(GetContactsByAgencyId request)
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
                return contacts is null
                        ? new PagedResponse<List<Contact>?>(null, 404, "Não foram encontrados contatos para esta agencia.")
                        : new PagedResponse<List<Contact>?>(contacts, count, request.PageNumber, request.PageSize);
                #endregion
            }
            catch
            {
                return new PagedResponse<List<Contact>?>(null, 500, "Não possível consultar os contatos.");
            }
        }
        public async Task<PagedResponse<List<Contact>?>> GetAllByCompanyAsync(GetContactsByCompanyId request)
        {
            try
            {
                #region 01. Buscar contatos por compania
                var query = context
                .Contacts
                .Where(x => x.AgencyId == request.ComapanyId)
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
                return contacts is null
                        ? new PagedResponse<List<Contact>?>(null, 404, "Não foram encontrados contatos para esta agencia.")
                        : new PagedResponse<List<Contact>?>(contacts, count, request.PageNumber, request.PageSize);
                #endregion
            }
            catch
            {
                return new PagedResponse<List<Contact>?>(null, 500, "Não possível consultar os contatos.");
            }
        }
        public async Task<PagedResponse<List<Contact>?>> GetAllByEmployeeAsync(GetContactsByEmployeeId request)
        {
            try
            {
                #region 01. Buscar contatos por colaborador
                var query = context
                .Contacts
                .Where(x => x.AgencyId == request.EmplooyeeId)
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
                return contacts is null
                        ? new PagedResponse<List<Contact>?>(null, 404, "Não foram encontrados contatos para esta agencia.")
                        : new PagedResponse<List<Contact>?>(contacts, count, request.PageNumber, request.PageSize);
                #endregion
            }
            catch
            {
                return new PagedResponse<List<Contact>?>(null, 500, "Não possível consultar os contatos.");
            }
        }
    }
}
