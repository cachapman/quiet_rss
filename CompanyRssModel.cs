using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QuietRssApi.Models
{
    public class CompanyRssModel
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string  RssUri { get; set; }

        [JsonIgnore]
        public Tuple<string, string> ToTuple => new(CompanyName, RssUri);
    }
}

