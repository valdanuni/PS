using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_Hospital_System_Project_2019.SystemClases
{
    public class DiagnoseList
    {
        public string Guid { get; set; }
        public DateTime DiagnoseTime { get; set; }
        public Doctor Doctor { get; set; }
        public String DiagnosisDescription { get; set; }
        public String Date
        {
            get
            {
                return this.DiagnoseTime.ToString().Split(' ')[0];
            }
        }
        public String Time
        {
            get
            {
                return DiagnoseTime.ToString().Split(' ')[1];
            }
        }
    }
}
