namespace NorthWind.Membership.Frontend.RazorViews.ViewModels.UserRegistration;

public class UserRegistrationViewModel(
    MembershipGateway gateway,
    IModelValidatorHub<UserRegistrationViewModel> validator)
{
    public IModelValidatorHub<UserRegistrationViewModel> Validator =>
        validator;

    public ModelValidator<UserRegistrationViewModel>
        ModelValidatorComponentReference
    { get; set; } = default!;

    public string InformationMessage { get; private set; } = string.Empty;

    #region Datos de entrada
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string PasswordConfirmation { get; set; } = string.Empty;
    #endregion

    public async Task Register()
    {
        try
        {
            InformationMessage = "";
            await gateway.RegisterAsync((UserRegistrationDto)this);
            InformationMessage =
                UserRegistrationMessages.RegisteredUserMessage;
        }
        catch (HttpRequestException ex)
        {
            if (ex.Data.Contains("Errors"))
            {
                IEnumerable<ValidationError> Errors =
                    (ex.Data["Errors"] as IEnumerable<ValidationError>)!;
                ModelValidatorComponentReference.AddErrors(Errors);
            }
            else
            {
                throw;
            }
        }
    }

    public static explicit operator UserRegistrationDto(
        UserRegistrationViewModel model) =>
        new UserRegistrationDto(
            model.Email, model.Password,
            model.FirstName, model.LastName);
}
