using App.Domain.Enum;
using App.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace App.Infra.Data.Persistence
{
    public abstract class DbConnectionRepositoryBase
    {
        public IDbConnection ConnectionBDCorp { get; private set; }
        public IDbConnection ConnectionCAC_PROD { get; private set; }

        public DbConnectionRepositoryBase(IDbConnectionFactory dbConnectionFactory)
        {
            ConnectionBDCorp = dbConnectionFactory.CreateDbConnection(DatabaseConnectionName.BDCORP);
            ConnectionCAC_PROD = dbConnectionFactory.CreateDbConnection(DatabaseConnectionName.CAC_PROD);

        }
    }
}
