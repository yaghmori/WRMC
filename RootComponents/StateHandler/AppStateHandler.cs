using Microsoft.Extensions.Localization;
using WRMC.Infrastructure.Localization;

namespace WRMC.RootComponents
{

    public class AppStateHandler
    {
        private readonly IStringLocalizer<ViewResources> _viewLocalizer;

        public string AppTitle { get; set; } = string.Empty;
        public bool DrawerOpen { get; set; } = true;

        public event Action? OnDrawerToggle;
        public event Action? OnAppTitleChanged;

        public AppStateHandler()
        {
            //AppTitle = _viewLocalizer[ViewResources.ApplicationTitle];
        }



        public void OpenDrawer()
        {
            DrawerOpen = !DrawerOpen;
            OnDrawerToggle?.Invoke();
        }
        public void SetAppTitle(string title)
        {
            AppTitle = title;
            OnAppTitleChanged?.Invoke();
        }
        public void SetAppTitleDefault(string title)
        {
            AppTitle = _viewLocalizer[ViewResources.AppTitle];
            OnAppTitleChanged?.Invoke();
        }
    }
}
