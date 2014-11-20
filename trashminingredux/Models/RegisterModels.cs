using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace trashminingredux.Models
{
    public class RegisterModels
    {
     [Required (ErrorMessage= "UserId is required.")]
        public int? uid { get; set; }
       
        public int xpos { get; set; }
        public int ypos { get; set; }
        public float orientation { get; set; }
        public string type { get; set; }
        public DateTime timestamp { get; set; }
        public string getdata()
        {
            HttpClient httpClient = new HttpClient();
            // httpClient.BaseAddress = new Uri();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response;
            response = httpClient.GetAsync("http://localhost:2076/" + "api/Values/GetJobType/").Result;
            string valuetest = response.Content.ReadAsAsync<string>().Result;
            return valuetest;
        }
        public string adddata(string id, string xpos, string ypos, string orientation, string type, string timestamp )
        {

            ArrayList paramList = new ArrayList();
            Product product = new Product {UserId = id  ,  xpos = xpos, ypos= ypos, orientation = orientation, type = type, timestamp = timestamp }; 
          
            paramList.Add(product);
         

            string uids = Convert.ToString(id);
            
            HttpClient httpClient = new HttpClient();
      
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        
            HttpResponseMessage response = httpClient.PostAsJsonAsync("http://localhost:2076/" + "api/Values/add/", paramList).Result;

            string valuetest = response.Content.ReadAsAsync<string>().Result;
            return valuetest;


          
        }
    }
}