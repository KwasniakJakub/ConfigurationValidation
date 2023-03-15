using Microsoft.Extensions.Options;

namespace ConfigurationValidation.Configuration;

public class ServiceConfigurationValidator : IValidateOptions<ServiceConfiguration>
{
    public ValidateOptionsResult Validate(string name, ServiceConfiguration options)
    {
        var validationResult = "";
        if (string.IsNullOrEmpty(options.ApiKey))
        {
            validationResult += "Api Key is missing";
        }

        if (options.LowestPriority > options.LowestPriority)
        {
            validationResult += "Lowest priority must be lower than highest priority";
        }

        if (!string.IsNullOrEmpty(validationResult))
        {
            return ValidateOptionsResult.Fail(validationResult);
        }

        return ValidateOptionsResult.Success;
    }
}