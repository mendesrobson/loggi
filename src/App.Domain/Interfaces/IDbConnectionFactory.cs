namespace App.Domain.Interfaces
{
    using App.Domain.Enum;
    using System.Data;

    public interface IDbConnectionFactory
    {
        IDbConnection CreateDbConnection(DatabaseConnectionName connectionName);
    }
}
