using System.Web.Mvc;

namespace apiManageTest.Controllers
{

    public class FormData
    {
        public string value1 { get; set; }
        public string value2 { get; set; }
    }
    
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        [HttpPost]   
        public JsonResult postSum(FormData formData)
        {
            var sum = (int.Parse(formData.value1) + int.Parse(formData.value2)) * 20;
            return Json(sum);
        }

        [HttpGet]
        public JsonResult getSum(string value1, string value2)
        {
            var sum = int.Parse(value1) + int.Parse(value2);
            return Json(sum, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult postReduce(FormData formData)
        {
            var sum = int.Parse(formData.value1) - int.Parse(formData.value2);
            return Json(sum);
        }

        [HttpGet]
        public JsonResult getReduce(string value1, string value2)
        {
            var sum = int.Parse(value1) - int.Parse(value2);
            return Json(sum, JsonRequestBehavior.AllowGet);
        }
    }
}
