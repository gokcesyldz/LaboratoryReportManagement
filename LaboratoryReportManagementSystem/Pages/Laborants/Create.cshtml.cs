using AutoMapper;
using Core.Interface;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaboratoryReportManagementSystem.Pages.Laborants
{
    public class CreateModel : PageModel
    {

        private readonly ILaborantService _laborantService;
        private readonly IReportService _reportService;
        

        public CreateModel(ILaborantService laborantService, IReportService reportService)
        {
            _laborantService = laborantService;
            _reportService = reportService;
        }

        [BindProperty]
        public LaborantModel LaborantModel { get; set; }

        public List<SelectListItem> ReportList { get; set; } = new List<SelectListItem>();

        public void OnGet()
        {
            var reports = _reportService.GetAll();

            foreach (var report in reports)
            {
                var selectListItem = new SelectListItem();
                selectListItem.Text = report.FileNumber;
                selectListItem.Value = report.PatientIdNumber.ToString();
                ReportList.Add(selectListItem);
            }
        }

        public IActionResult OnPost()
        {
            _laborantService.Create(LaborantModel);

            return Redirect("/Laborants/Index");

        }

    }
}
