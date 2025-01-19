using AgencyManager.Core.DTOs;
using AgencyManager.Core.Handlers;
using AgencyManager.Core.Requests.Agency;
using AgencyManager.Core.Requests.Position;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AgencyManager.Web.Pages.Positions
{
    public partial class PositionsListPage : ComponentBase
    {
        #region Parameters
        [Parameter] public string Id { get; set; } = string.Empty;
        #endregion

        #region Properties
        public bool IsBusy { get; set; }
        public List<PositionDto> Positions { get; set; } = [];
        public string SearchTerm { get; set; } = string.Empty;
        #endregion

        #region Services
        [Inject] public ISnackbar Snackbar { get; set; } = null!;
        [Inject] public IPositionHandler Handler { get; set; } = null!;
        [Inject] public IDialogService DialogService { get; set; } = null!;
        #endregion

        #region Overrides

        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;

            try
            {
                var request = new GetPositionsByAgencyIdRequest { AgencyId = Convert.ToInt32(Id)};
                var result = await Handler.GetAllByAgencyIdAsync(request);

                if (result.IsSuccess)
                    Positions = result.Data ?? [];
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
        public async void OnDeleteButtonClickedAsync(int id, string position)
        {

        }

        public Func<PositionDto, bool> Filter => position =>
        {
            if (string.IsNullOrEmpty(SearchTerm))
                return true;

            if (position.Id.ToString().Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                return true;

            if (position.Description.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                return true;

            if (position.Responsabilities.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        };
        #endregion
    }
}