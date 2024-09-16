using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ReportModel
    {
        public long Id { get; set; }

        public string FileNumber { get; set; }
        public string PatientFullName { get; set; }
        public string PatientIdNumber { get; set; }
        public string DiagnosisTitle { get; set; }
        public string DiagnosisDetails { get; set; }
        public DateTime ReportDate { get; set; }
        public string PhotoPath { get; set; }

        public long LaborantId { get; set; }
    }
}
