namespace NorthWind.Membership.Frontend.RazorViews.Pages;

public partial class LogoutPage
{
    [Inject]
    JWTAuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;

    [Inject]
    NavigationManager NavigationManager { get; set; } = default!;

    async ValueTask CloseSession()
    {
        await AuthenticationStateProvider.LogoutAsync();

        // Navegar a la raíz de la aplicación
        NavigationManager.NavigateTo("/");
    }
}
