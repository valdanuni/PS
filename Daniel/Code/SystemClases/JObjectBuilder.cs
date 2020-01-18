using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_Hospital_System_Project_2019
{
    class JObjectBuilder
    {
        private dynamic jObject = new JObject();
        
        public JObjectBuilder With(Action<dynamic> action)
        {
            action(jObject);
            return this;
        }

        public JObject Build()
        {
            return jObject;
        }
    }
}
