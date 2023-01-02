using Microsoft.AspNetCore.Components;
using WRMC.Core.Shared.Responses;

namespace WRMC.RootComponents.Pages.Identity
{
    public partial class UserProfile
    {

        [CascadingParameter] public UserResponse User { get; set; } = new();

    }
}