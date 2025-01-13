using AgencyManager.Core.Handlers;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Requests.Contact;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System.ComponentModel.DataAnnotations;

namespace AgencyManager.Web.Pages.Agencies
{
    public partial class CreateAgencyPage : ComponentBase
    {
        #region Properties
        public bool IsBusy { get; set; } = false;
        public CreateAgencyRequest InputModel { get; set; } = new();
        public CreateContactRequest ContactModel { get; set; } = new();
        public string FileImage { get; set; } = string.Empty;

        #endregion

        #region Services
        [Inject] public IAgencyHandler Handler { get; set; } = null!;
        [Inject] public NavigationManager Navigation { get; set; } = null!;
        [Inject] public ISnackbar Snackbar { get; set; } = null!;
        [Inject] public IMapper Mapper { get; set; } = null!;

        #endregion

        #region Overrides

        protected override void OnInitialized()
        {
            FileImage = "imgs/cardAgencia.jpg";  
            ContactModel.ContactType = Core.Enums.EContactType.Phone;
        }
        #endregion

        #region Methods

        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;

            try
            {
                var result = await Handler.CreateAsync(InputModel);
                if(result.IsSuccess)
                {
                    Snackbar.Add(result.Message!, Severity.Success);
                    Navigation.NavigateTo("/agencias");
                }
                else
                {
                    Snackbar.Add(result.Message!, Severity.Error);
                }
            }
            catch(Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }
        public async Task UploadFile(IBrowserFile file)
        {
            var format = "image/jpeg";
            var resizedImage = await file.RequestImageFileAsync(format, 200, 200);

            using var fileStream = resizedImage.OpenReadStream();
            using var memoryStream = new MemoryStream();
            await fileStream.CopyToAsync(memoryStream);

            var imageUpload = Convert.ToBase64String(memoryStream.ToArray());
            FileImage = $"data:{format};base64,{imageUpload}";
            InputModel.Photo = imageUpload;

            FileImage = $"data:{format};base64,{Convert.ToBase64String(memoryStream.ToArray())}";

        }
        public void RemoveContact(CreateContactRequest contact)
        {
            InputModel.Contacts.Remove(contact);     
            StateHasChanged();
        }
        public void AddContact()
        {           
            if (IsValid(ContactModel))
            {    
                InputModel.Contacts.Add(ContactModel);             
            }
            else
            {
                Snackbar.Add("Contato inválido.", Severity.Error);
            }
            StateHasChanged();
        }
        private bool IsValid(CreateContactRequest contact)
        {
            var validationContext = new ValidationContext(contact, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(contact, validationContext, validationResults, true))
                return false;
            return true;
        }
        #endregion
    }
}
