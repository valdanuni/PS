using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_Hospital_System_Project_2019.SystemClases
{
    public class Visit
    {
        public string Guid { get; set; }
        public DateTime VisitTime { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public Hospital Hospital { get; set; }
        public String Date
        {
            get
            {
                return this.VisitTime.ToString().Split(' ')[0];
            }
        }
        public String Time
        {
            get
            {
                return VisitTime.ToString().Split(' ')[1];
            }
        }
        public Visit()
        {

        }
    }
}
