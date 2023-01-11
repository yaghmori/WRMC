using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using WRMC.Core.Shared.Constants;
using WRMC.Core.Shared.Responses;
using WRMC.Infrastructure.Localization;
using WRMC.RootComponents.Shared;

namespace WRMC.RootComponents.Pages.Identity
{
    public partial class ActiveSessions
    {
        [Parameter] public string UserId { get; set; } = string.Empty;

    }
}