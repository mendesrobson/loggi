using App.Domain.Queries;
using GraphQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infra.Data.Schema
{
    public class SchemaManager: GraphQL.Types.Schema
    {
        public SchemaManager(IDependencyResolver resolver)
            :base(resolver)
        {
            Query = resolver.Resolve<LoginQuery>();
        }
    }
}
