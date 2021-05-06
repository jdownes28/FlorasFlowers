namespace BenchBackend.Services
{
    public interface IDataSerializer
    {
        byte[] Serialize<T>(T myObject);
    }
}