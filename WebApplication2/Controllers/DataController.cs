using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Dal;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DataController : Controller
    {
        // GET: Data
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var list = TestDal.GetTestList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            TestModel model = null;
            if (string.IsNullOrEmpty(id))
            {
                model = new TestModel();
            }
            else
            {
                model = TestDal.GetTestModelById(id);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(TestModel test)
        {
            var message = test.Verification();
            if (!string.IsNullOrEmpty(message))
            {
                this.ViewData["errorMessage"] = message;
                return View(test);
            }

            if (string.IsNullOrEmpty(test.Id))
            {
                //新建
                test.Id = Guid.NewGuid().ToString("N");
                TestDal.InsertData(test);
            }
            else
            {
                //更新
                TestDal.UpdateData(test);
            }
            return Redirect("/data/list");
        }

        public ActionResult Detail(string id)
        {
            var model = TestDal.GetTestModelById(id);
            return View(model);
        }
    }
}