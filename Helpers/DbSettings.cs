namespace Helpers
{
    public class DbSettings : IDbSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string Collection { get; set; } = null!;
    }
}
