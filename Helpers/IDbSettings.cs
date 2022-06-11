namespace Helpers
{
    public interface IDbSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string Collection { get; set; }
    }
}
