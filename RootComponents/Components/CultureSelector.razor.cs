using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using WRMC.Core.Application.Extensions;
using WRMC.Core.Shared.Constant;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;

namespace WRMC.RootComponents.Components
{
    public partial class CultureSelector
    {
        [CascadingParameter] private UserResponse User { get; set; }

        [Parameter] public string Class { get; set; } = string.Empty;

        public List<CultureResponse> Cultures { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            var result = await _cultureDataService.GetCulturesAsync();
            if (result.Succeeded)
            {
                Cultures = result.Data;
            }

        }
        private async void OnClick(CultureResponse culture)
        {
            var patchDoc = new JsonPatchDocument<UserSettingRequest>();
            patchDoc.Replace(e => e.Culture, culture.CultureInfo.Name);
            patchDoc.Replace(e => e.RightToLeft, culture.RightToLeft);
            var result = await _userSettingDataService.UpdateSettingsAsync(User.UserSetting.Id, patchDoc);
            if (result.Succeeded)
            {
                //TODO : Implement LocalStorage Service
                var isPersistent = await _localStorage.GetItemAsync<bool>(ApplicationConstants.IsPersistent);
                if (isPersistent)
                    await _localStorage.SetItemAsync(ApplicationConstants.Culture, culture.CultureInfo.Name);
                else
                    await _sessionStorage.SetItemAsync(ApplicationConstants.Culture, culture.CultureInfo.Name);
            }
            else
            {
                foreach (var message in result.Messages)
                {
                    _snackbar.Add(message, Severity.Error);
                }
            }

        }
    }
}