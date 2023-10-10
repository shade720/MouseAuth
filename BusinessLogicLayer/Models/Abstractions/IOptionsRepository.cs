namespace MouseAuth.BusinessLogicLayer.Models.Abstractions;

internal interface IOptionsRepository
{
    public Options ReadOptions();
    public void WriteOptions(Options options);
    public void DeleteOptions(Options options);
}