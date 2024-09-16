using AutoMapper;
using Core.Interface;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaboratoryReportManagementSystem.Pages.Reports
{ 
public class CreateModel : PageModel
{

    private readonly IReportService _reportService;
    private readonly ILaborantService _laborantService;

    [BindProperty] 
        public ReportModel ReportModel { get; set; }
        public List<SelectListItem> LaborantList { get; set; } = new List<SelectListItem>();

        public CreateModel(IReportService reportService, ILaborantService laborantService)
        {
            _reportService = reportService;
            _laborantService = laborantService;
        }


    public void OnGet()
    {
            var laborants = _laborantService.GetAll();


            foreach (var laborant in laborants)
            {
                var selectListItem = new SelectListItem();
                selectListItem.Text = laborant.FirstName;
                selectListItem.Value = laborant.Id.ToString();
                LaborantList.Add(selectListItem);
            }

        }

        public IActionResult OnPost()
    {
        _reportService.Create(ReportModel);

            return Redirect("/Reports/Index");

        }

    }
}