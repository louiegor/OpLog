using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Oplog.Models;
using Oplog.ViewModels;

// Things that is interesting and can be included
// jQM - Dynamically Populate Listview from JSON
// Overlay a picture on top of another pciture - http://stackoverflow.com/questions/5130374/positioning-and-overlaying-image-on-another-image, http://jsfiddle.net/WPWzq/
// Overlay text over picture - http://jsfiddle.net/i_like_robots/7GvV2/
// Canvas movinng pic over picture - http://jsfiddle.net/v92gn/
// Edit View http://jsfiddle.net/timriley/5DMjt/
// Containment of canvas http://jsfiddle.net/DGbT3/1529/


// phase 1: set up the database structure character, organization, file 
//          also design a structure so that the character can transform gear 1 to gear 2
//          Create seed method - for at least two organization strawhat pirate and doflamingo pirate
//          the stats can now be using seiya's model 100 as max, can change the model later
//          also support having a structure so that each character can have more than 1 picture, can select default
//          also organization should also contain a picture, can have emblem of organization
////// phase 2: 
//          set up the list view structure so that u can modify
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
        private OpLogContext context;

        public OpLogContext Db
        {
            get
            {
                if (context == null)
                {
                    context = new OpLogContext();
                    return context;
                }
                return context;
            }
        }

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

        public ActionResult GetAllOrg()
        {
            //var Db = new OpLogContext();
            var o = Db.Organizations.Select(x=>x.Name).ToList();
            return Db.Organizations.ToJsonCamelResult();
        }

        public ActionResult GetAllChar()
        {
            var result = new List<CharacterTableVm>();

            foreach (var item in Db.Characters)
            {
                result.Add(new CharacterTableVm(item));
            }
            //var c = Db.Characters.Select(x => new CharacterTableVm(x)).ToList();
            return result.ToJsonCamelResult();
        }
    }


    public static class Helper
    {

        public static JsonResult ToJsonResult<T>(this T obj)
        {
            return new JsonResult() { Data = obj, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public static ContentResult ToJsonCamelResult<T>(this T obj)
        {
            var jsonResult = new JsonResult() { Data = obj, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var jsonObj = JsonConvert.SerializeObject(jsonResult, Formatting.Indented, settings);
            //return new JsonResult { Data = jsonObj, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return new ContentResult
            {
                ContentType = "text/plain",
                Content = jsonObj,
                ContentEncoding = Encoding.UTF8
            };


        }



    }
}
