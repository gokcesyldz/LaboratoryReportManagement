using AutoMapper;
using Core.Models;
using DataAcces.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AutoMapper
{
    public class LaborantProfile : Profile
    {

        public LaborantProfile() 
        {
            CreateMap<Laborant, LaborantModel>().ReverseMap();
        }

    }
}
