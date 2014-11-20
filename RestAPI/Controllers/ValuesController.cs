using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestAPI.Controllers.DAL;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Data;

using System.Web.Script.Serialization;


namespace RestAPI.Controllers
{
    public class ValuesController : ApiController
    {
        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
        private HttpResponseMessage response;

        [HttpGet]
        public HttpResponseMessage GetIO()
        {
            // HttpResponseMessage response;
            try
            {
                DataSet interestResponse = new DataSet();
                interestResponse = new userDAL().GetIO();


                //var interestResponse = new userDAL().GetIO(); 
                if (interestResponse != null)
                    response = Request.CreateResponse<DataSet>(HttpStatusCode.OK, interestResponse);
                    
                else
                    response = new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                // response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
      public  HttpContent k;
       [HttpPost]

      public HttpResponseMessage add(ArrayList paramList)
        {
            //"{\r\n  \"UserId\""
            try
            {
              if (paramList.Count > 0)
                {
                    string[] data = paramList[0].ToString().Split('"');
           
           var interestResponse = new userDAL().add(data[3],data[7],data[11],data[15],data[19],data[23]);
           if (interestResponse != null)
               response = Request.CreateResponse<string>(HttpStatusCode.OK, interestResponse);
           else
               response = new HttpResponseMessage(HttpStatusCode.NotFound);
                }

             
              
            }
            catch (Exception ex)
            {
                // response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }


       public object logJson { get; set; }
    }
}