﻿using System;
using System.Web.Mvc;

namespace apiManageTest.Controllers
{

    public class FormData
    {
        public string value1 { get; set; }
        public string value2 { get; set; }
    }

    public class ResultData
    {
        public int value { get; set; }
        public int index { get; set; }
        public string guid { get; set; }
    }
    
    public class HomeController : Controller
    {

        private static int _index = 0;
        private static string _uuid = Guid.NewGuid().ToString();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        [HttpPost]   
        public JsonResult postSum(FormData formData)
        {
            var sum = int.Parse(formData.value1) + int.Parse(formData.value2);

            _index++;

            var result = new ResultData() { index = _index, value = sum, guid = _uuid };

            return Json(result);
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
