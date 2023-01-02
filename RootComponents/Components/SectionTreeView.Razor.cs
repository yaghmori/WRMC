using MudBlazor;
using WRMC.Core.Shared.Responses;

namespace WRMC.RootComponents.Components;

public partial class SectionTreeView
{

    public List<SectionResponse> SectionCollection { get; set; } = new();

    public async Task<HashSet<SectionResponse>> LoadServerData(SectionResponse parentNode)
    {
        var sectionList = new HashSet<SectionResponse>();
        var result = await _sectionDataService.GetSectionsAsync();
        if (result.Succeeded)
        {
            sectionList =result.Data.ToHashSet();
        }

        return sectionList;
    }

    public async Task ReloadData()
    {
        IsLoading = true;
        var response = await _sectionDataService.GetSectionsAsync();
        if (response.Succeeded)
        {
            SectionCollection = response.Data;
        }
        else
        {
            foreach (var message in response.Messages)
            {
                _snackbar.Add(message, Severity.Error);
            }
        }
        IsLoading = false;

    }

    protected override async Task OnInitializedAsync()
    {
        await ReloadData();
    }


}