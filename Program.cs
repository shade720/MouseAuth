using MouseAuth.Forms;

namespace MouseAuth;

internal static class Program
{
    private static readonly string StoragePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    public static readonly string AverageResultsFilepath = Path.Combine(StoragePath, "average-results.json");
    public static readonly string ResultsSpreadFilepath = Path.Combine(StoragePath, "results-spread.json");

    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        var form = SelectStartForm();
        if (form is null) 
            return;
        Application.Run(form);
    }

    private static Form? SelectStartForm()
    {
        if (IsSetupNeeded())
            return new SetupForm();
        var dialogResult = MessageBox.Show(@"Удалить сохраненные биометрические данные?", @"Отладка", MessageBoxButtons.YesNoCancel);
        if (dialogResult == DialogResult.Yes)
        {
            File.Delete(AverageResultsFilepath);
            File.Delete(ResultsSpreadFilepath);
            return new SetupForm();
        }
        if (dialogResult == DialogResult.No) 
            return new AuthForm();
        return null;
    }
    private static bool IsSetupNeeded()
    {
        return !File.Exists(AverageResultsFilepath) || !File.Exists(ResultsSpreadFilepath);
    }
}