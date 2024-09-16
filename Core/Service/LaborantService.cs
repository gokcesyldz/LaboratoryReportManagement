using AutoMapper;
using Core.Interface;
using Core.Models;
using DataAcces.Entity;
using DataAcces.GenericRepository;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public class LaborantService : ILaborantService
    {
        private readonly IRepository<Laborant> _laborantRepository;

        private readonly IMapper _mapper;

        public LaborantService(IRepository<Laborant> laborantRepository, IMapper mapper)
        {
            _laborantRepository = laborantRepository;
            _mapper = mapper;
        }

        public LaborantModel GetLaborantById(int id)
        {
            var laborant = _laborantRepository.Find(x => x.Id == id).SingleOrDefault();

            var laborantModel = _mapper.Map<LaborantModel>(laborant);

            return laborantModel;
        }


        public bool Create(LaborantModel laborantModel)
        {
            var result = false;

            Laborant laborant = new Laborant()
            {
                FirstName = laborantModel.FirstName,
                HospitalNumber = laborantModel.HospitalNumber,
                LastName = laborantModel.LastName,
            };

            _laborantRepository.Add(laborant);

            return result;
        }

        public List<Laborant> GetAll()
        {
           var result = false;

           var laborant = _laborantRepository.GetAll();

            return laborant;
        }

        public bool Update(LaborantModel laborantModel)
        {
            var laborant = _laborantRepository.Find(x => x.Id == laborantModel.Id).SingleOrDefault();

            _mapper.Map(laborantModel, laborant);
            
            _laborantRepository.Update(laborant);

            return true;
        }

        public bool Delete(long id)
        {
            var laborant = _laborantRepository.Find(x => x.Id == id).SingleOrDefault();

            _laborantRepository.Delete(laborant);

            return true;
        }
    }
}
