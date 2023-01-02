using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using WRMC.Core.Shared.Responses;
using WRMC.Infrastructure.Domain.Entities;

namespace WRMC.RootComponents.Components
{
    public partial class VisitTasks
    {
        [Parameter] public string? VisitId { get; set; }
        public VisitResponse Visit { get; set; }
        public List<SectionResponse> Steps { get; set; }
        public List<TaskResponse> Tasks { get; set; }
        protected override async Task OnInitializedAsync()
        {
            IsLoading= true;
            if(VisitId!= null)
            {
                var visitResponse =await _visitDataService.GetVisitByIdAsync(VisitId);
                if(visitResponse?.Succeeded==true)
                {
                    Visit = visitResponse.Data;
                }
                var tasksResponse = await _visitDataService.GetTasksAsync(VisitId);
                if(tasksResponse?.Succeeded==true)
                {
                    Tasks= tasksResponse.Data;
                    Steps = Tasks.DistinctBy(x=>x.Section.ParentId).Select(x=>x.Section.Parent).ToList();
                }
            }
            IsLoading= false;
        }
    }
}