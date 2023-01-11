using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Globalization;
using WRMC.Core.Shared.Constants;
using WRMC.RootComponents;
using WRMC.RootComponents.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
AppConstants.ServerBaseAddress = builder.HostEnvironment.IsDevelopment() ? $"http://localhost:5001" : $"TODO";


builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddRootComponentService();
builder.Services.AddOptions();
builder.Services.AddLocalization();

//===============


var app = builder.Build();

#region Culture
CultureInfo culture;
var _localStorage = app.Services.GetRequiredService<ILocalStorageService>();
var _sessionStorage = app.Services.GetRequiredService<ISessionStorageService>();
var isPersistent = await _localStorage.GetItemAsync<bool>(AppConstants.IsPersistent);
if (isPersistent)
{
    var result = await _localStorage.GetItemAsync<string>(AppConstants.Culture);
    if (string.IsNullOrWhiteSpace(result))
    {
        culture = new CultureInfo("en-US");
        await _localStorage.SetItemAsync<string>(AppConstants.Culture, "en-US");
    }
    else
    {
        culture = new CultureInfo(result);
    }

}
else
{
    var result = await _sessionStorage.GetItemAsync<string>(AppConstants.Culture);
    if (string.IsNullOrWhiteSpace(result))
    {
        culture = new CultureInfo("en-US");
        await _sessionStorage.SetItemAsync<string>(AppConstants.Culture, "en-US");
    }
    else
    {
        culture = new CultureInfo(result);
    }
}

CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

#endregion


await app.RunAsync();
