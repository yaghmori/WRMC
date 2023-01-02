using Microsoft.AspNetCore.Components;

namespace WRMC.RootComponents.Interfaces
{
    internal interface IHasAdminId
    {
       [Parameter] public string AdminId { get; set; }
    }
}
