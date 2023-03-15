using ConfigurationValidation.Configuration;
using Microsoft.Extensions.Options;

namespace ConfigurationValidation;

public class SampleService
{
    private readonly ServiceConfiguration _serviceConfiguration;

    public SampleService(IOptions<ServiceConfiguration> serviceConfigurationOptions)
    {
        if (serviceConfigurationOptions.Value is null)
        {
            throw new ArgumentNullException("serviceConfigurationOptions.Value is missing");
        }

        if (string.IsNullOrEmpty(serviceConfigurationOptions.Value.ApiKey))
        {
            throw new ArgumentNullException("serviceConfigurationOptions.ApiKey is missing");
        }
        _serviceConfiguration = serviceConfigurationOptions.Value;
    }

    public ServiceConfiguration GetOptions()
    {
        return _serviceConfiguration;
    }
}