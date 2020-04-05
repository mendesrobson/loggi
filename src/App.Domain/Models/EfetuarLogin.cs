using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Models
{
    public class EfetuarLogin: ObjectGraphType<Login>
    {
        public EfetuarLogin()
        {
            Name = "Mutation";
            Field(_ => _.Email).Description("Email para efetuar o login na Loggi");
            Field(_ => _.Password).Description("Senha para efetuar o login na Loggi");
        }
    }
}
