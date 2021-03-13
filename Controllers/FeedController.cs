using Microsoft.AspNetCore.Mvc;

namespace RssQuiet.Controllers
{
    public class FeedController
    {
        ///summary: basic feed return for multi purpose investigation
        public ActionResult Get(string company = null, int? limit = 10, int? per_page = 5, int page = 1 ) {
            return null;
        }

        ///summary: can post new feeds to the app
        public ActionResult Post([FromBodyAttribute] string company, string rss_uri){
            return null;
        }
       
    }
}