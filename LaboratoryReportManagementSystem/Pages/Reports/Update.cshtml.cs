using AutoMapper;
using Core.Interface;
using Core.Models;
using DataAcces.Entity;
using DataAcces.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Core.Service;


namespace LaboratoryReportManagementSystem.Pages.Reports
{
    public class UpdateModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly IReportService _reportService;
        private readonly ILaborantService _laborantService;

        [BindProperty]
        public ReportModel ReportModel { get; set; }
        public List<SelectListItem> LaborantList { get; set; } = new List<SelectListItem>();

        public UpdateModel(IMapper mapper, IReportService reportService, ILaborantService laborantService)
        {
            _mapper = mapper;
            _reportService = reportService;
            _laborantService = laborantService;
        }
        public IActionResult OnGet(int id)
        {
            ReportModel = _reportService.GetReportById(id);

           var laborants = _laborantService.GetAll();


            foreach(var laborant in laborants)
            {
                var selectListItem = new SelectListItem();
                selectListItem.Text = laborant.FirstName;
                selectListItem.Value = laborant.Id.ToString();
                LaborantList.Add(selectListItem);
            }

            if (ReportModel == null)
            {
                return NotFound();
            }
            
            return Page();
        }

        public IActionResult OnPost()
        {
            _reportService.Update(ReportModel);

            return RedirectToPage("./Index");
        }

        public IActionResult OnGetDelete(int id)
        {
            _reportService.Delete(id);

            return RedirectToPage("./Index");
        }


    }
}
