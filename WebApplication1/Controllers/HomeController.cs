
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult cc()
        {
            //EF.T1 t1 = new EF.T1();
            //t1.Name = "ni shi ge da sha bi";
            //t1.ParentId = 1;

            //T2 t2 = new T2();

            //t2.TId = 1;


            //using (var db=new Model1())
            //{
            //    db.T2.Add(t2);
            //   db.T1.Add(t1);
            //    db.SaveChanges();
            //}

            //T3 t3 = new T3();
            //t3.Name = "你是sb";
            //t3.ParentId = 1;

            //T4 t4 = new T4();
            //t4.T3Id = 1;

            //T3 tt33 = new T3();





            //using (MyModel2 my = new MyModel2())
            //{
            //    tt33 = my.T3shiti.Where(c => c.Id == 2).ToList().FirstOrDefault();
            //}




            //JsonSerializerSettings setting = new JsonSerializerSettings()
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            //    Formatting = Formatting.None
            //};
            //var ret = JsonConvert.SerializeObject(tt33, setting);
            //return Json(ret, JsonRequestBehavior.AllowGet);
            //   return Json(tt33, JsonRequestBehavior.AllowGet);


            //using (TransactionScope scope = new TransactionScope())
            //{
            //    //Do something with context1  
            //    //Do something with context2  

            //    //Save Changes but don't discard yet  
            //    context1.SaveChanges(false);

            //    //Save Changes but don't discard yet  
            //    context2.SaveChanges(false);

            //    //if we get here things are looking good.  
            //    scope.Complete();
            //    context1.AcceptAllChanges();
            //    context2.AcceptAllChanges();

            //}

            return View();
            
        }
    }
}