using App.Application.Interfaces;
using App.Domain.Models;
using GraphQL;
using GraphQL.Common.Request;
using GraphQL.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Application.Services
{
    public class LogginLoggiAppService : ILogginLoggiAppService
    {
        public LogginLoggiAppService()
        {
        }
        public string EfetuarLogin(Login login)
        {
            var request = new GraphQLRequest();

            request.Query = @"mutation ($email:String!,$password:String!){
                              login(input: {
                                    email: $email,
                                    password: $password
                                }) {
                                user {
                                  apiKey
                                }
                              }
                            }";
 

            request.Variables = new
            {
                email = login.Email,
                password = login.Password
            };

            var graphQLClient = new  GraphQL.Client.GraphQLClient("https://staging.loggi.com/graphql");

           // graphQLClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
            graphQLClient.DefaultRequestHeaders.Add("Authorization", "ApiKey email:api_key");

            var response = graphQLClient.PostAsync(request).GetAwaiter().GetResult();
            IList<string> mensagemError = new List<string>();
            if(response.Errors?.Count() > 0)
            {
                foreach(var error in response.Errors)
                {
                    mensagemError.Add(error.Message);
                }

                return mensagemError.Select(_ => _).FirstOrDefault();
            }

            var apiKey = response.Data["login"]["user"]["apiKey"];

            if (apiKey == null)
                return "Syntax Error GraphQL";

            return apiKey;
        }
    }
}
