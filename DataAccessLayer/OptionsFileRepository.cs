using MouseAuth.BusinessLogicLayer.Models;
using MouseAuth.BusinessLogicLayer.Models.Abstractions;
using System.Text.Json;

namespace MouseAuth.DataAccessLayer;

public class OptionsFileRepository : IOptionsRepository
{
    private const string OptionsFilename = "options.json";
    private readonly string _optionsFilepath;

    public OptionsFileRepository(string filepath)
    {
        _optionsFilepath = Path.Combine(filepath, OptionsFilename);
    }

    public Options? ReadOptions()
    {
        if (!File.Exists(_optionsFilepath))
            return null;
        return JsonSerializer.Deserialize<Options>(File.ReadAllText(_optionsFilepath));
    }

    public void WriteOptions(Options options)
    {
        File.WriteAllText(_optionsFilepath, JsonSerializer.Serialize(options));
    }

    public void DeleteOptions()
    {
        File.Delete(_optionsFilepath);
    }
}