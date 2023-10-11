using MouseAuth.Forms;

namespace MouseAuth.BusinessLogicLayer.Models.Abstractions;

public interface IFormFactory
{
    public AuthForm CreateAuthForm();
    public SetupForm CreateSetupForm();
    public OptionsForm CreateOptionsForm();
}