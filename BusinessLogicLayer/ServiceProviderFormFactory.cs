using Microsoft.Extensions.DependencyInjection;
using MouseAuth.BusinessLogicLayer.Models.Abstractions;
using MouseAuth.Forms;

namespace MouseAuth.BusinessLogicLayer;

public class ServiceProviderFormFactory : IFormFactory
{
    private readonly IServiceProvider _serviceProvider;

    public ServiceProviderFormFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public AuthForm CreateAuthForm()
    {
        return _serviceProvider.GetRequiredService<AuthForm>();
    }

    public SetupForm CreateSetupForm()
    {
        return _serviceProvider.GetRequiredService<SetupForm>();
    }

    public OptionsForm CreateOptionsForm()
    {
        return _serviceProvider.GetRequiredService<OptionsForm>();
    }
}