using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Entity
{
    public class Laborant
    {
        public Laborant()
        {
            Reports = new List<Report>();
        }

        public long Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HospitalNumber { get; set; } 

        public List<Report> Reports { get; set; }


    }
}
