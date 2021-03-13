using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuietRssApi.Models
{
    public class RssCompanyModel
    {
        public Guid Id { get; set; }
        public Tuple<string, string> Data { get; set; }
    }
}
