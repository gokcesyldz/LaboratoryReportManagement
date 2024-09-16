using AutoMapper;
using Core.Interface;
using Core.Models;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Protocols.Configuration;

namespace LaboratoryReportManagementSystem.Pages.Laborants
{
    public class IndexModel : PageModel
    {
        private readonly ILaborantService _laborantService;

        private readonly IMapper _mapper;
        public List<LaborantModel> LaborantModels { get; set; } = new List<LaborantModel>();

        public string LaborantName { get; set; }

        public string SearchString { get; set; }
        public IndexModel(ILaborantService laborantService, IMapper mapper)
        {
            _laborantService = laborantService;
            _mapper = mapper;
        }

        public void OnGet()
        {
             var laborants = _laborantService.GetAll();


            LaborantModels = _mapper.Map<List<LaborantModel>>(laborants);

            if (!string.IsNullOrEmpty(LaborantName))
            {
                laborants = laborants.Where(l => l.FirstName.Contains(LaborantName)).ToList();

            }

            if (!string.IsNullOrEmpty(SearchString))
            {
                laborants = laborants.Where(l => l.FirstName.Contains(SearchString) || l.LastName.Contains(SearchString)).ToList();
            }
            LaborantModels = _mapper.Map<List<LaborantModel>>(laborants);
        }
    } 
}
