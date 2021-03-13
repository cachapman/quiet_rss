using Microsoft.AspNetCore.Mvc;
using QuietRssApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuietRssApi.Controllers
{
    public class QuietFeedController
    {

        private List<RssCompanyModel> _db;

        public QuietFeedController()
        {
            _db = new List<RssCompanyModel>();
        }

        [HttpPost]
        //[Authorize]
        public IActionResult Post([FromBody] string company, string rss_uri)
        {
            if (!Uri.IsWellFormedUriString(rss_uri, UriKind.RelativeOrAbsolute))
            {
                return new BadRequestResult();
            }

            var entry = new RssCompanyModel
            {
                Id = Guid.NewGuid(),
                Data = new Tuple<string, string>(company, rss_uri)
            };

            _db.Add(entry);
            return new CreatedResult("quietfeed/" + entry.Id.ToString(), entry);

        }


        [HttpDelete("{id}")]
        //[Authorize]
        public IActionResult Delete(string id)
        {
            try
            {
                if( Guid.TryParse(id, out Guid gId))
                {
                    _db.Remove(_db.Where(r => r.Id == gId).Single());
                    return new OkResult();
                }
                return new BadRequestResult();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on writing to the db - " + e.Message);
                return new BadRequestResult();
            }
        }


        [HttpGet]
        public List<RssCompanyModel> Get() => _db;


        ///summary: primary method - days is consecutive days in which an RSS feed hasn't beeen updated.<!-- -->
        [HttpGet]
        public ActionResult Get(int days = 5)
        {
            return null;
        }
    }
}