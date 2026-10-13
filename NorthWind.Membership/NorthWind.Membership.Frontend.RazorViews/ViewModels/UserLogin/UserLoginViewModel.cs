namespace NorthWind.Membership.Frontend.RazorViews.ViewModels.UserLogin;

public class UserLoginViewModel(
    MembershipGateway gateway,
    IModelValidatorHub<UserLoginViewModel> validator,
    JWTAuthenticationStateProvider authenticationStateProvider)
{
    public IModelValidatorHub<UserLoginViewModel> Validator => validator;

    public ModelValidator<UserLoginViewModel> ModelValidatorComponentReference
    { get; set; } = default!;

    public event Action? OnLogin;

    #region Datos de entrada
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    #endregion

    public async Task Login()
    {
        try
        {
            TokensDto Tokens =
                await gateway.LoginAsync((UserCredentialsDto)this);
            await authenticationStateProvider.LoginAsync(Tokens);
            OnLogin?.Invoke();
        }
        catch (HttpRequestException ex)
        {
            if (ex.Data.Contains("Errors"))
            {
                var Errors = (ex.Data["Errors"] as
                    IEnumerable<ValidationError>)!;
                ModelValidatorComponentReference.AddErrors(Errors);
            }
            else
            {
                throw;
            }
        }
    }

    public static explicit operator UserCredentialsDto(
        UserLoginViewModel model) =>
        new UserCredentialsDto(model.Email, model.Password);
}
