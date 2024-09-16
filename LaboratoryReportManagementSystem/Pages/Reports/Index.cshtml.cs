using AutoMapper;
using Core.Interface;
using Core.Models;
using Core.Service;
using DataAcces.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LaboratoryReportManagementSystem.Pages.Reports
{
    public class IndexModel : PageModel
    {
        private readonly IReportService _reportService;

        private readonly IMapper _mapper;
        public List<ReportModel> ReportModels { get; set; } = new List<ReportModel>();

        public string ReportName { get; set; }

        public string SearchString { get; set; }


        public IndexModel(IReportService reportService, IMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;
        }


        public void OnGet()
        {
            var reports = _reportService.GetAll();

            ReportModels = _mapper.Map<List<ReportModel>>(reports);

            if (!string.IsNullOrEmpty(ReportName))
            {
                reports = reports.Where(l => l.PatientFullName.Contains(ReportName)).ToList();
            }

            if (!string.IsNullOrEmpty(SearchString))
            {
                reports = reports.Where(l => l.PatientFullName.Contains(SearchString) || l.PatientFullName.Contains(SearchString)).ToList();
            }


            ReportModels = _mapper.Map<List<ReportModel>>(reports);
        }
    }
}
