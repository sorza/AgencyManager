using AgencyManager.Core.Handlers;
using AgencyManager.Core.Requests.Agency;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace AgencyManager.Web.Pages.Agencies
{
    public partial class EditAgencyPage : ComponentBase
    {
        #region Parameters
        [Parameter] public string Id { get; set; } = string.Empty;

        #endregion

        #region Properties
        public bool IsBusy { get; set; } = false;
        public UpdateAgencyRequest InputModel { get; set; } = new();
        public string FileImage { get; set; } = string.Empty;

        #endregion

        #region Services
        [Inject] ISnackbar Snackbar { get; set; } = null!;
        [Inject] NavigationManager NavigationManager { get; set; } = null!;
        [Inject] IAgencyHandler Handler { get; set; } = null!;
        #endregion

        #region Overrides
        protected override async Task OnInitializedAsync()
        {
            GetAgencyByIdRequest? request = null;

            try
            {
                request = new GetAgencyByIdRequest { Id = Convert.ToInt32(Id) };
            }
            catch
            {
                Snackbar.Add("Parâmetro inválido", Severity.Error);
            }

            if (request is null) return;

            IsBusy = true;

            try
            {
                var response = await Handler.GetByIdAsync(request);

                if (response is { IsSuccess: true, Data: not null })
                {
                    InputModel = new UpdateAgencyRequest
                    {
                        Id = response.Data.Id,
                        Description = response.Data.Description,
                        Cnpj = response.Data.Cnpj,
                        Photo = response.Data.Photo,

                        Address = {
                            City = response.Data.Address.City,
                            Complement = response.Data.Address.Complement,
                            Street = response.Data.Address.Street,
                            Number = response.Data.Address.Number,
                            State = response.Data.Address.State,
                            ZipCode = response.Data.Address.ZipCode,
                            Neighborhood = response.Data.Address.Neighborhood
                        }
                    };

                    if (string.IsNullOrEmpty(InputModel.Photo)) FileImage = "imgs/cardAgencia.jpg";
                    else FileImage = $"data:image/jpeg;base64,{InputModel.Photo}";                   
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message!, Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }

        }
        #endregion

        #region Methods
        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;
            try
            {
                var response = await Handler.UpdateAsync(InputModel);
                if (response.IsSuccess)
                {
                    Snackbar.Add("Agência atualizada com sucesso", Severity.Success);
                    NavigationManager.NavigateTo("/agencias");
                }
                else
                {
                    Snackbar.Add(response.Message!, Severity.Error);
                }
            }
            catch (Exception ex)
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
        #endregion
    }
}
