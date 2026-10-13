namespace NorthWind.Membership.Frontend.RazorViews.Pages;

public partial class UserRegistrationPage
{
    [Inject]
    UserRegistrationViewModel ViewModel { get; set; } = default!;

    ErrorBoundary? ErrorBoundaryRef;

    void Recover()
    {
        ErrorBoundaryRef?.Recover();
    }
}
