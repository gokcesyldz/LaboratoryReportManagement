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
    public interface  IReportService
    {
        bool Create(ReportModel reportModel);
        List<Report> GetAll();

        bool Update(ReportModel report);
        ReportModel GetReportById(int id);

        bool Delete(long id);
    }
}
