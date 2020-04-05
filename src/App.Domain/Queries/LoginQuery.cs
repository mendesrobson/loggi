using App.Domain.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Queries
{
    public class LoginQuery: ObjectGraphType
    {
        public LoginQuery()
        {
            Field<ListGraphType<LoginType>>(
                "login");
        }
    }
}
