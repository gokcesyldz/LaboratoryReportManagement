using AutoMapper;
using Core.Interface;
using Core.Models;
using Core.Service;
using DataAcces.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LaboratoryReportManagementSystem.Pages.Reports
{
    public class DetailsModel : PageModel
    {
        private readonly IReportService _reportService;

        private readonly IMapper _mapper;

        public ReportModel Report { get; set; }
        public List<ReportModel> ReportModels { get; set; } = new List<ReportModel>();

        public DetailsModel(IReportService reportService, IMapper mapper)
        {
            
            _reportService = reportService;
            _mapper = mapper;
        }
        public IActionResult OnGet(int id)
        {
            Report = _reportService.GetReportById(id);

            if (Report == null)
            {
                return NotFound();
            }

            return Page();
        }

        public void OnGetAllReports()
        {
            var reports = _reportService.GetAll();

            ReportModels = _mapper.Map<List<ReportModel>>(reports);
        }
    }
}
