using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// Things that is interesting and can be included
// jQM - Dynamically Populate Listview from JSON
// Overlay a picture on top of another pciture - http://stackoverflow.com/questions/5130374/positioning-and-overlaying-image-on-another-image, http://jsfiddle.net/WPWzq/
// Overlay text over picture - http://jsfiddle.net/i_like_robots/7GvV2/
// Canvas movinng pic over picture - http://jsfiddle.net/v92gn/

// phase 1: set up the database structure character, organization, file
//          - also design a structure so that the character can transform gear 1 to gear 2
//          - the stats can now be using seiya's model 100 as max, can change the model later
//          - also support having a structure so that each character can have more than 1 picture, can select default
//          - also organization should also contain a picture, can have emblem of organization
// phase 2: set up the list view structure so that u can modify
//          organization, character, stats and files
// 
// *** phase 3 and 4 can be think of at later stage ***
// phase 3: Create card, use charts for stats and use overlay for picture 
// phase 4: Set up the world map so that it can be like a log or games

//http://docs.asp.net/en/latest/client-side/yeoman.html

namespace Oplog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
