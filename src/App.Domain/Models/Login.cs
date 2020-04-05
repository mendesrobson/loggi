using GraphQL;
using GraphQL.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Models
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    [GraphQLMetadata("user")]
    public class User
    {
        public string ApiKey { get; set; }
    }

    [GraphQLMetadata("login")]
    public class Logins
    {
        public Logins()
        {
            User = new User();
        }
        public User User { get; set; }
    }

    public class LoginType: ObjectGraphType<Logins>
    {
        public LoginType()
        {
            Field(x => x.User.ApiKey).Description("ApiKey chave de acesso a loggi");
        }
    }

    public class LoginQuery : ObjectGraphType
    {
        public LoginQuery()
        {
            Field<LoginType>(
                name: "login",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "ApiKey" }),
                resolve: context =>
                {
                    var ApiKey = context.GetArgument<string>("ApiKey");
                    return ApiKey;
                }
            );
        }
    }
}
