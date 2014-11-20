using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace trashminingredux.Controllers
{
    public class HomeController : Controller
    {
      
        //public ActionResult Index()
        //{
        //    ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

        //    return View();
        //}

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
       
        //public ActionResult Index(Models.RegisterModels m)
        //{
        //   ViewBag.data =  m.getdata();
        //    return View();
        //}
        //[HttpGet]
        //public ActionResult Index()
        //{
        //    return View();
        //}
        #region Post data through variables
        [HttpPost]
        public ActionResult Index2View(Models.RegisterModels rmodels) //string Uid, string xpos, string ypos, string orientation, string type)
        {
            var invoiceNumberQueryResult = rmodels;
            //  return Json(invoiceNumberQueryResult, JsonRequestBehavior.DenyGet);



            rmodels.timestamp = Convert.ToString(DateTime.Now);
            //if (Request.Form.Count > 0)
            // {

            string a = rmodels.adddata(rmodels.uid, rmodels.xpos, rmodels.ypos, rmodels.orientation, rmodels.type, rmodels.timestamp);
            ViewBag.result = a;

            //}
            return View();


        }
#endregion
       [HttpGet]
        public ActionResult Index2View()
        {
        // rmodels.adddata();
            return View();
        }
        public ActionResult Index(Models.RegisterModels m)
        {
            //if (m.uid > 0)
            //{
            //   // m.adddata();
            //}
           
            return View("Index", m);
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult listall(Models.RegisterModels  rmodel)
        {
            DataSet ds = new DataSet();
          
            List<data> detail = new List<data>();
            ds = rmodel.getdata();
             string[,] datax = new string[ds.Tables[0].Rows.Count,6];
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++ )
                {

                    detail.Add(new data { uid = (ds.Tables[0].Rows[i][0]).ToString(), xpos = (ds.Tables[0].Rows[i][1]).ToString(), ypos = ds.Tables[0].Rows[i][2].ToString(), orientation = ds.Tables[0].Rows[i][3].ToString(), type = ds.Tables[0].Rows[i][4].ToString(), timestamp = ds.Tables[0].Rows[i][5].ToString()});
                     
                }

            }
            return Json(detail, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DisplayData()
        {
            return View();
        }

        public class data
        {
            public string uid, xpos, ypos, orientation, type,timestamp;
        }
    }
}
