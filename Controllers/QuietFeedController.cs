using Microsoft.AspNetCore.Mvc;

namespace RssQuiet.Controllers
{
    public class QuietFeedController
    {
        ///summary: primary method - days is consecutive days in which an RSS feed hasn't beeen updated.<!-- -->
          public ActionResult Get(int? days = 5, int? limit = 10, int? per_page = 5, int page = 1 ) {
            return null;
        }
    }
}