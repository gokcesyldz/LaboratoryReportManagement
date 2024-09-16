using AutoMapper;
using Core.Interface;
using Core.Models;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LaboratoryReportManagementSystem.Pages.Laborants
{
    public class DetailsModel : PageModel
    {
        private readonly ILaborantService _laborantService;

        private readonly IMapper _mapper;
        public List<LaborantModel> LaborantModels { get; set; } = new List<LaborantModel>();

        public DetailsModel(ILaborantService laborantService, IMapper mapper)
        {
            _laborantService = laborantService;
            _mapper = mapper;
        }
        public void OnGet()
        {
            var laborants = _laborantService.GetAll();


            LaborantModels = _mapper.Map<List<LaborantModel>>(laborants);

        }
    }
}
