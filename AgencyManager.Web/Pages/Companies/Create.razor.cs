using AgencyManager.Core.Handlers;
using AgencyManager.Core.Requests.Company;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace AgencyManager.Web.Pages.Companies
{
    public partial class CreateCompanyPage : ComponentBase
    {
        #region Properties
        public bool IsBusy { get; set; } = false;
        public CreateCompanyRequest InputModel { get; set; } = new();
        public string FileImage { get; set; } = string.Empty;

        #endregion

        #region Services
        [Inject] public ICompanyHandler Handler { get; set; } = null!;
        [Inject] public NavigationManager Navigation { get; set; } = null!;
        [Inject] public ISnackbar Snackbar { get; set; } = null!;

        #endregion

        #region Overrides

        protected override void OnInitialized()
        {
            FileImage = "imgs/cardAgencia.jpg";
        }
        #endregion

        #region Methods

        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;

            try
            {
                var result = await Handler.CreateAsync(InputModel);
                if (result.IsSuccess)
                {
                    Snackbar.Add(result.Message!, Severity.Success);
                    Navigation.NavigateTo("/empresas");
                }
                else
                {
                    Snackbar.Add(result.Message!, Severity.Error);
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
            InputModel.Logo = imageUpload;

            FileImage = $"data:{format};base64,{Convert.ToBase64String(memoryStream.ToArray())}";

        }
        #endregion
    }
}
