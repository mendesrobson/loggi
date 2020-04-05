using App.Application.Interfaces;
using App.Domain.Models;
using GraphQL.Client;
using GraphQL.Common.Request;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace App.Application.Services
{
    public class CriarPedidoLoggiAppService: ICriarPedidoLoggiAppService
    {
        public CriarPedidoLoggiAppService()
        {
        }

        public JObject CriarPedidos(string apiKey, Pedidos pedidos)
        {
            GraphQLRequest request = new GraphQLRequest 
            
            {
                Query = @"mutation ($shopId:Int!,$paymentMethod:Int!,$trackingkey:String!,$lat:Float!,$lng:Float!,$address:String!,
		                                  $complement:String!,$client:String!,$phone:String!,$lat1:Float!,
		                                  $lng1:Float!,$address1:String!,$complement1:String!,$value:DecimalType!,
		                                  $method:Int!,$change:DecimalType!,$width:Int!,$height:Int!,$length:Int!) {
                                  createOrder(input: {
                                    shopId: $shopId
                                    paymentMethod: $paymentMethod
                                    trackingKey: $trackingkey
                                    pickups: [{
                                      address: {
                                        lat: $lat
                                        lng: $lng
                                        address: $address
                                        complement: $complement
                                      }
                                    }]
                                    packages: [{
                                      pickupIndex: 0
                                      recipient: {
                                        name: $client
                                        phone: $phone
                                      }
                                      address: {
                                        lat: $lat1
                                        lng: $lng1
                                        address: $address1
                                        complement: $complement1
                                      }
                                      charge: {
                                        value: $value
                                        method: $method
                                        change: $change
                                      }
                                      dimensions: {
                                        width: $width
                                        height: $height
                                        length: $length
                                      }
                                    }]
                                  }) {
                                    success
                                    shop {
                                      pk
                                      name
                                    }
                                    orders {
                                      pk
                                      trackingKey
                                      packages {
                                        pk
                                        status
                                        pickupWaypoint {
                                          index
                                          indexDisplay
                                          eta
                                          legDistance
                                        }
                                        waypoint {
                                          index
                                          indexDisplay
                                          eta
                                          legDistance
                                        }
                                      }
                                    }
                                    errors {
                                      field
                                      message
                                    }
                                  }
                                }",
                 Variables = new
                {
                    shopId = 1,
                    paymentMethod = 0,
                    trackingkey = "tracking_key",
                    lat = -23.5703022,
                    lng = -46.6473154,
                    address = "Av. Paulista, 100 - Bela Vista, São Paulo - SP, Brasil",
                    complement = "8o andar",
                    client = "Client XYZ",
                    phone = "1199678890",
                    lat1 = -23.635334,
                    lng1 = -46.529835,
                    address1 = "Av. Estados Unidos, 500 - Parque das Nações, Santo André - SP, Brasil",
                    complement1 = "Apto 133",
                    value = "10.00",
                    method = 2,
                    change = "5.00",
                    width = 10,
                    height = 10,
                    length = 10
                }
        };

            var querys = JsonConvert.SerializeObject(request);
            // query:
            //JObject json =new  JObject();


            var client = new RestClient("https://staging.loggi.com/graphql");
            client.Timeout = -1;
            var requestRest = new RestRequest(Method.POST);
            requestRest.AddHeader("Authorization", "teste-api@sonasystem.com.br:f82bacd1b266cc21f4c8c5da020fe29b5e588af3");
            requestRest.AddHeader("Content-Type", "application/json");
            requestRest.AddParameter("application/json", querys, ParameterType.RequestBody);
            IRestResponse response = client.Execute(requestRest);

            var teste = response.Content;

            var graphQLClient = new GraphQLClient("https://staging.loggi.com/graphql");

            AuthenticationHeaderValue HeaderValue = new AuthenticationHeaderValue("Authorization","teste-api@sonasystem.com.br:f82bacd1b266cc21f4c8c5da020fe29b5e588af3");
            
            graphQLClient.DefaultRequestHeaders.Add("Authorization", "teste-api@sonasystem.com.br:f82bacd1b266cc21f4c8c5da020fe29b5e588af3");

            graphQLClient.DefaultRequestHeaders.Add("Content-Type", "application/json");

          //  graphQLClient.DefaultRequestHeaders.Add("email","teste-api@sonasystem.com.br:f82bacd1b266cc21f4c8c5da020fe29b5e588af3");

            //var response = graphQLClient.PostAsync(request).GetAwaiter().GetResult();

            //if(response.Errors?.Count() > 0)
            //{
            //    var err = response.Errors.Select(_ => _.Message);
            //    //return err;
            //}

            return null;
        }
    }
}
