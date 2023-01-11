using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using WRMC.Core.Shared.Constants;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Infrastructure.Domain.Enums;
using WRMC.Infrastructure.Localization;
using WRMC.RootComponents.Dialogs;

namespace WRMC.RootComponents.Components
{
    public partial class PersonalInfo
    {
        [Parameter] public string UserId { get; set; } = string.Empty;
        private UserProfileRequest UserProfileRequest { get; set; } = new();


        protected async override Task OnParametersSetAsync()
        {
            IsLoading = true;
            _appState.SetAppTitle(_viewLocalizer[ViewResources.Profile]);
            //Load Personal Info
            await LoadPersonalInfo();


            IsLoading = false;
            StateHasChanged();
        }

        private async Task LoadPersonalInfo()
        {
            IsLoading = true;
            var userResponse = await _userDataService.GetUserAsync(UserId);
            if (userResponse?.Succeeded == true)
            {
                UserProfileRequest = _autoMapper.Map<UserProfileRequest>(userResponse.Data);
            }
            else
            {
                foreach (var message in userResponse?.Messages)
                {
                    _snackbar.Add(message, Severity.Error);
                }
            }
            IsLoading = false;
        }

        private async Task SelectIntroMethodDialog()
        {
            var options = new DialogOptions()
            {
                CloseButton = true,
                FullWidth = true,
                MaxWidth = MaxWidth.ExtraSmall
            };

            var dialog = _dialog.Show<SelectIntroMethodDialog>(_displayLocalizer[DisplayResources.IntroMethodId], options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var data = result.Data as IntroMethodResponse;
                if (data != null && data.Type == TreeTypeEnum.Leaf)
                {
                    UserProfileRequest.IntroMethodId = data.Id;//for trigger validation
                    UserProfileRequest.IntroMethod = data;
                }
            }
        }

        private async void SubmitPersonalInfoAsync(EditContext context)
        {
            IsBusy = true;
            var patchDoc = new JsonPatchDocument<UserProfileRequest>();
            patchDoc.Replace(e => e.FirstName, UserProfileRequest.FirstName);
            patchDoc.Replace(e => e.MiddleName, UserProfileRequest.MiddleName);
            patchDoc.Replace(e => e.LastName, UserProfileRequest.LastName);
            patchDoc.Replace(e => e.IdNumber, UserProfileRequest.IdNumber);
            patchDoc.Replace(e => e.Gender, UserProfileRequest.Gender);
            patchDoc.Replace(e => e.Height, UserProfileRequest.Height);
            patchDoc.Replace(e => e.Weight, UserProfileRequest.Weight);
            patchDoc.Replace(e => e.BirthDate, UserProfileRequest.BirthDate);
            patchDoc.Replace(e => e.EmergencyPhone, UserProfileRequest.EmergencyPhone);
            patchDoc.Replace(e => e.EmergencyName, UserProfileRequest.EmergencyName);
            patchDoc.Replace(e => e.Description, UserProfileRequest.Description);
            patchDoc.Replace(e => e.RaceNationality, UserProfileRequest.RaceNationality);
            patchDoc.Replace(e => e.IntroMethodId, UserProfileRequest.IntroMethodId);
            patchDoc.Replace(e => e.IntroMethodDescription, UserProfileRequest.IntroMethodDescription);
            var result = await _userDataService.UpdateUserProfileAsync(UserProfileRequest.UserId, patchDoc);
            if (result.Succeeded)
            {
                context.MarkAsUnmodified();
                _snackbar.Add(_messageLocalizer[MessageResources.UserAccountUpdatedSuccessfully], Severity.Success);
            }
            else
            {
                _snackbar.Add(_messageLocalizer[MessageResources.UserAccountNotUpdated], Severity.Error);
                foreach (var message in result.Messages)
                {
                    _snackbar.Add(message, Severity.Error);
                }
            }

            IsBusy = false;
            StateHasChanged();
        }
    }
}