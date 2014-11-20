using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Data;

namespace trashminingredux.Models
{
    public class RegisterModels
    {
        [Required (ErrorMessage= "UserId is required.")]
        public string uid { get; set; }
       
        public String xpos { get; set; }
        public string ypos { get; set; }
        public string orientation { get; set; }
        public string type { get; set; }
        public string timestamp { get; set; }
        public DataSet getdata()
        {
            DataSet ds = new DataSet();
            HttpClient httpClient = new HttpClient();
            // httpClient.BaseAddress = new Uri();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response;
            response = httpClient.GetAsync("http://localhost:2076/" + "api/Values/GetIO/").Result;
            ds = response.Content.ReadAsAsync<DataSet>().Result;
            return ds;
        }
        public string adddata(string Uid, string xpos, string ypos, string orientation, string type, string timestamp)//string id, string xpos, string ypos, string orientation, string type, string timestamp )
        {

            ArrayList paramList = new ArrayList();
            Product product = new Product { UserId  = Uid  ,  xpos = xpos, ypos= ypos, orientation = orientation, type = type, timestamp = timestamp }; 
         
            paramList.Add(product);
         

          //  string uids = Convert.ToString(id);
            
            HttpClient httpClient = new HttpClient();
      
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        
            HttpResponseMessage response = httpClient.PostAsJsonAsync("http://localhost:2076/" + "api/Values/add/", paramList).Result;

            string valuetest = response.Content.ReadAsAsync<string>().Result;
            return valuetest;

                     
        }
    
    }

    
}