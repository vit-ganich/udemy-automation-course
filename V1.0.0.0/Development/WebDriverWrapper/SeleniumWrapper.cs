using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WebDriverWrapper
{
    public class SeleniumWrapper
    {
        public void ParseJson(string json)
        {
            var ourJsonObject = JObject.Parse(json);
            if ((bool)ourJsonObject["LikeThisCourse"])
            {
                var firstName = (string)ourJsonObject["FirstName"];
                var secondName = (string)ourJsonObject["SecondName"];
                var age = (int)ourJsonObject["Age"];
            }
        }
    }
}
