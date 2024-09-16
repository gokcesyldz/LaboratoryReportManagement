using AutoMapper;
using Core.Interface;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;
using Core.Service;


namespace LaboratoryReportManagementSystem.Pages.Laborants
{
    public class UpdateModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly ILaborantService _laborantService;
        private readonly IReportService _reportService;

        [BindProperty]
        public LaborantModel LaborantModel { get; set; }

        public List<SelectListItem> ReportList { get; set; } = new List<SelectListItem>();

        public UpdateModel(IMapper mapper, ILaborantService laborantService, IReportService reportService)
        {
            _mapper = mapper;
            _laborantService = laborantService;
            _reportService = reportService;
        }

        public IActionResult OnGet(int id)
        {
            LaborantModel = _laborantService.GetLaborantById(id);

            var reports = _reportService.GetAll();


            foreach (var report in reports)
            {
                var selectListItem = new SelectListItem();
                selectListItem.Text = report.FileNumber;
                selectListItem.Value = report.Id.ToString();
                ReportList.Add(selectListItem);
            }


            if (LaborantModel == null)
            {
                return NotFound();
            }

            return Page();
        }


        public IActionResult OnPost()
        {
            _laborantService.Update(LaborantModel);

            return RedirectToPage("./Index");
        }

        public IActionResult OnGetDelete( int id)
        {
            _laborantService.Delete(id);

            return RedirectToPage("./Index");
        }


    }
}
