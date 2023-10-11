namespace MouseAuth.BusinessLogicLayer.Models.Abstractions;

public interface IOptionsRepository
{
    public Options? ReadOptions();
    public void WriteOptions(Options options);
    public void DeleteOptions();
}