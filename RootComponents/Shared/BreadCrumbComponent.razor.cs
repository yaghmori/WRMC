using Microsoft.AspNetCore.Components;
using WRMC.Core.Shared.Models;

namespace WRMC.RootComponents.Shared
{
    public partial class BreadCrumbComponent
    {
        [Parameter]
        public List<MyBreadcrumbItem> Links { get; set; }

        public BreadCrumbComponent()
        {
        }

    }
}