using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Entity
{
    public class Report
    {
        public Report()
        {
        }

        public long Id { get; set; }

        public string FileNumber { get; set; }
        public string PatientFullName { get; set; }
        public string PatientIdNumber { get; set; } 
        public string DiagnosisTitle { get; set; }
        public string DiagnosisDetails { get; set; }
        public DateTime ReportDate { get; set; }
        public string PhotoPath { get; set; }

        public long LaborantId { get; set; }

        [ForeignKey("LaborantId")]
        public Laborant Laborant { get; set; }
    }
}
