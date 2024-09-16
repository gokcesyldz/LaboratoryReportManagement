using Core.Models;
using DataAcces.Entity;
using DataAcces.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface ILaborantService
    {
       bool Create(LaborantModel laborantModel);

        List<Laborant> GetAll();
        
        bool Update(LaborantModel laborantModel);

        LaborantModel GetLaborantById(int id);

        bool Delete(long id);

    }
}
