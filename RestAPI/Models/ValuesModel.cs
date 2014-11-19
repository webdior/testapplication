using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class ValuesModel
    {
        public string uids { get; set; }
    }

    public class IO
    {
        [JsonProperty(PropertyName = "#")]
        public int Id { get; set; }
        public string Desc { get; set; }
        public int SC { get; set; }
        public string DT { get; set; }
        public object InAlarm { get; set; }
        public string VS { get; set; }
    }

    public class RootObject
    {
        public string Type { get; set; }
        public List<IO> IO { get; set; }
    }
}