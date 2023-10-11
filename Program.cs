using Microsoft.Extensions.Hosting;
using MouseAuth.Forms;
using Microsoft.Extensions.DependencyInjection;
using MouseAuth.BusinessLogicLayer;
using MouseAuth.BusinessLogicLayer.Models.Abstractions;
using MouseAuth.DataAccessLayer;

namespace MouseAuth;

internal static class Program
{
    public static IServiceProvider ServiceProvider { get; private set; }
    private static readonly string StoragePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        var host = CreateHostBuilder().Build();
        ServiceProvider = host.Services;
        Application.Run(ServiceProvider.GetRequiredService<ControlForm>());
    }

    private static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddTransient<IFormFactory, ServiceProviderFormFactory>();

                services.AddTransient<IOptionsRepository, OptionsFileRepository>(
                    _ => new OptionsFileRepository(StoragePath));
                services.AddTransient<ICalibrationResultsRepository, CalibrationResultsFileRepository>(
                    _ => new CalibrationResultsFileRepository(StoragePath));
                services.AddTransient(
                    _ => new MouseTest(5, 10));
                services.AddTransient(
                    serviceProvider => new CalibrationManager(3, serviceProvider.GetRequiredService<ICalibrationResultsRepository>()));
                services.AddTransient<MouseAuthentication>();

                services.AddTransient<SetupForm>();
                services.AddTransient<AuthForm>();
                services.AddTransient<OptionsForm>();

                services.AddTransient(serviceProvider =>
                {
                    var testForm = new TestForm(serviceProvider.GetRequiredService<MouseTest>());
                    testForm.TopLevel = false;
                    testForm.AutoScroll = false;
                    return testForm;
                });

                services.AddTransient<ControlForm>();
            });
    }
}