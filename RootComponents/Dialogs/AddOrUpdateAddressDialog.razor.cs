using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Infrastructure.Domain.Enums;
using WRMC.Infrastructure.Localization;

namespace WRMC.RootComponents.Dialogs
{
    public partial class AddOrUpdateAddressDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; }
        [Parameter] public string UserAddressId { get; set; } = string.Empty;
        [Parameter] public string UserId { get; set; } = string.Empty;
        public UserAddressRequest AddressRequest { get; set; } = new();
        public List<RegionResponse> States { get; set; } = new();
        public List<RegionResponse> Cities { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;

            var response = await _regionDataService.GetRegionsAsync(parentId: "188");//states of united states
            if (response?.Succeeded == true)
            {
                States = response.Data;
            }
            else
            {
                foreach (var message in response?.Messages)
                {
                    _snackbar.Add(message, Severity.Error);
                }
            }


            if (!string.IsNullOrWhiteSpace(UserAddressId))
            {
                var result = await _userDataService.GetUserAddressAsync(UserId, UserAddressId);
                if (result.Succeeded)
                {
                    AddressRequest = _autoMapper.Map<UserAddressRequest>(result.Data);
                    await GetCities(AddressRequest.RegionId);

                }
                else
                {
                    foreach (var message in result.Messages)
                    {
                        _snackbar.Add(message, Severity.Error);
                    }
                }
            }
            IsLoading = false;
            StateHasChanged();
        }

        private async Task GetCities(string stateId)
        {
            var citiesResponse = await _regionDataService.GetRegionsAsync(stateId);
            if (citiesResponse?.Succeeded == true)
            {
                Cities = citiesResponse.Data;
            }
            else
            {
                foreach (var message in citiesResponse?.Messages)
                {
                    _snackbar.Add(message, Severity.Error);
                }
            }
        }

        private async Task OnStateValueChanged(RegionResponse region)
        {
            AddressRequest.SelectedCity = null;
            AddressRequest.SelectedState = region;
            if (region != null)
            {
                await GetCities(region.Id);
            }
        }
        private async Task<IEnumerable<RegionResponse>> SearchStates(string value)
        {
            if (string.IsNullOrEmpty(value))
                return States;
            return States.Where(x => x.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase));
        }
        private async Task<IEnumerable<RegionResponse>> SearchCities(string value)
        {
            if (string.IsNullOrEmpty(value))
                return Cities;
            return Cities.Where(x => x.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase));
        }




        private async void OnSubmitAsync(EditContext context)
        {
            IsBusy = true;
            bool dgResult = false;
            if (string.IsNullOrWhiteSpace(UserAddressId)) //New
            {
                var result = await _userDataService.AddUserAddressAsync(UserId, AddressRequest);
                if (result?.Succeeded == true)
                {
                    var addressId = result.Data;
                    if (!string.IsNullOrWhiteSpace(addressId))
                    {
                        dgResult = true;
                        _snackbar.Add(_messageResources[MessageResources.AddressSuccessfullyAdded]?.Value, Severity.Success);

                        //TODO : Using SignalR
                    }
                }
                else
                {
                    foreach (var message in result?.Messages)
                    {
                        _snackbar.Add(message, Severity.Error);
                    }
                }
            }
            else //Edit
            {
                //AddressRequest.RegionId = SelectedCity.Id;
                var patchDoc = new JsonPatchDocument<UserAddressRequest>();
                patchDoc.Replace(e => e.Address, AddressRequest.Address);
                patchDoc.Replace(e => e.RegionId, AddressRequest.RegionId);
                patchDoc.Replace(e => e.AddressType, AddressRequest.AddressType);
                patchDoc.Replace(e => e.Description, AddressRequest.Description);
                patchDoc.Replace(e => e.IsDefault, AddressRequest.IsDefault);
                patchDoc.Replace(e => e.ZipCode, AddressRequest.ZipCode);


                var result = await _userDataService.UpdateUserAddressAsync(UserId, UserAddressId, patchDoc);
                if (result?.Succeeded == true)
                {
                    dgResult = true;
                    _snackbar.Add(_messageResources[MessageResources.AddressSuccessfullyUpdated], Severity.Success);

                    //TODO : Using SignalR
                }
                else
                {
                    foreach (var message in result?.Messages)
                    {
                        _snackbar.Add(message, Severity.Error);
                    }

                }
            }
            IsBusy = false;
            MudDialog.Close(DialogResult.Ok(dgResult));
        }

        private async Task SelectRegionDialog()
        {
            var options = new DialogOptions()
            {
                CloseButton = true,
                FullWidth = true,
                MaxWidth = MaxWidth.ExtraSmall
            };
            var dialog = _dialog.Show<RegionTreeSelectionDialog>(_displayResources[DisplayResources.UserAddress_Region], options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var data = result.Data as RegionResponse;
                if (data != null && data.RegionType == RegionTypeEnum.City)
                {
                    AddressRequest.SelectedCity = data;
                }
            }
        }

        private void Cancel()
        {
            MudDialog.Cancel();
        }

    }
}