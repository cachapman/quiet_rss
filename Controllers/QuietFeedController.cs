using Microsoft.AspNetCore.Mvc;
using QuietRssApi.Models;
using QuietRssNuget;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuietRssApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuietFeedController : ControllerBase
    {

        public QuietFeedController()
        {
            if(DbContext._db == null)
                DbContext._db = new List<CompanyRssModel>();
        }

        //[Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CompanyRssModel companyRssModel)
        {

            if (!Uri.IsWellFormedUriString(companyRssModel.RssUri, UriKind.RelativeOrAbsolute))
            {
                return new BadRequestResult();
            }
            companyRssModel.Id = Guid.NewGuid();

            DbContext._db.Add(companyRssModel);
            return new CreatedResult("/" + companyRssModel.Id.ToString(), companyRssModel);

        }


        //[Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                if (Guid.TryParse(id, out Guid gId))
                {
                    DbContext._db.Remove(DbContext._db.Where(r => r.Id == gId).Single());
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

        ///summary: primary method - days is consecutive days in which an RSS feed hasn't beeen updated.<!-- -->
        [HttpGet]
        public HashSet<RssSummary> Get(double days = 5)
        {
            return RssRetriever.GetQuietFeeds(DbContext._db.Select(x => x.ToTuple).ToList(), days);
        }
    }
}