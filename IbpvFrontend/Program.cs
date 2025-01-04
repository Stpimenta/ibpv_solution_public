/*program cs padrao para fazer uma injeçao braba*/

using System.Globalization;
using IbpvFrontend.src.Components;
using IbpvFrontend.src.Provider;
using IbpvFrontend.src.Provider.interfaces;
using IbpvFrontend.src.Services.UserServices;
using Microsoft.AspNetCore.Components.Authorization;
using IbpvFrontend.src.Services;
using Blazorise;
using Blazored.LocalStorage;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using IbpvFrontend.src.Services.PdfRelatorioGenerator;
using IbpvFrontend.src.Services.ServiceUpload;
using IbpvFrontend.src.Services.StateService;
using Microsoft.FluentUI.AspNetCore.Components;


var builder = WebApplication.CreateBuilder(args);

// Configuração do Kestrel para escutar em todas as interfaces na porta 5000
// builder.WebHost.ConfigureKestrel(options =>
// {
//     options.ListenAnyIP(5063); // Ou a porta desejada
// });

//configuration para pegar as variaveis
var configuration = builder.Configuration;

// Configurar a cultura para pt-BR
var culture = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;
//ativa o css
builder.WebHost.UseWebRoot("wwwroot").UseStaticWebAssets();
//blazorise
builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


//localstorage
builder.Services.AddBlazoredLocalStorage();

//amazonservice
builder.Services.AddScoped<AmazonS3Service>();

//googledrive service
builder.Services.AddScoped<IServiceUpload,ServiceUploadGDrive>();

//httpcontexts
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<CostumerHttpCLient>();
builder.Services.AddHttpClient("IbpvApi", client =>
{
    client.BaseAddress = new Uri(configuration["AmbienteVar:databaseApiEndpoint"]!);
});

//fluent ui
builder.Services.AddFluentUIComponents(options =>
{
    options.ValidateClassNames = false;
});
builder.Services.AddHttpClient();

//serviço de login
builder.Services.AddScoped<ILoginService, LoginService>();

//serviços de autorizaçao
builder.Services.AddScoped<AuthenticationStateProvider, UserAuthenticator>();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();


//serviços repositorio
builder.Services.AddScoped<IProviderUserLogin, ProviderUserLogin>();
builder.Services.AddScoped<IProviderContribuicao, ProviderContribuicao>();
builder.Services.AddScoped<IProviderGasto, ProviderGasto>();
builder.Services.AddScoped<IProviderCaixa, providerCaixa>();
builder.Services.AddScoped<IProviderMembro, ProviderUsuario>();

//serviços para permanencia de estado
builder.Services.AddScoped<FormStateService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Cache-Control", "no-store, no-cache, must-revalidate, max-age=0");
    context.Response.Headers.Add("Pragma", "no-cache");
    context.Response.Headers.Add("Expires", "0");
    await next();
});

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
