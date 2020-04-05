using Newtonsoft.Json;
using System.Collections.Generic;

namespace App.API.Models
{
    public class ErrorsViewModel
    {
        public ErrorsViewModel()
        {
            Errors = new List<string>();
        }
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("errors")]
        public List<string> Errors { get; set; }
    }
}
