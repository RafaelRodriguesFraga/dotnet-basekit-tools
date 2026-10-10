using DotnetBaseKit.Application.Validations;
using BASEKIT_COMPONENTS_PACKAGE.Shared.Notifications;

namespace DotnetBaseKit.Application.DTOs;

public class ExampleRequestDto : Notifiable<Notification>
{
    public Guid Id { get; set; }
    public string ExampleProperty { get; set; } = string.Empty;

    public void Validate()
    {
        var validator = new ExampleRequestDtoContract();
        var validationResult = validator.Validate(this);

        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                AddNotification(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}