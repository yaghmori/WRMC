using Microsoft.AspNetCore.Components;
using WRMC.Core.Shared.Constant;

namespace WRMC.RootComponents.Components
{
    public partial class RedirectToLogin
    {
        [Parameter]
        public string ReturnUrl { get; set; } = string.Empty;
        protected override void OnInitialized()
        {
            if (string.IsNullOrWhiteSpace(ReturnUrl))
            {
                _navigationManager.NavigateTo(ApplicationURL.login, forceLoad: true);
            }
            else
            {
                ReturnUrl = "~/" + ReturnUrl;
                _navigationManager.NavigateTo($"{ApplicationURL.login}?returnUrl= {ReturnUrl}", forceLoad: true);
            }
        }
    }
}