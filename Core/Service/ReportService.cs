using AutoMapper;
using Core.Interface;
using Core.Models;
using DataAcces.Entity;
using DataAcces.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public class ReportService : IReportService
    {
        private readonly IRepository<Report> _reportRepository;

        private readonly IMapper _mapper;
        private IMapper mapper;

        public ReportService(IRepository<Report> reportRepository, IMapper mapper)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
        }

        public bool Create(ReportModel reportModel)
        {
            var result = false;


            Report report = new Report()
            {

                Id = reportModel.Id,
                FileNumber = reportModel.FileNumber,
                PatientFullName = reportModel.PatientFullName,
                PatientIdNumber = reportModel.PatientIdNumber,
                DiagnosisTitle = reportModel.DiagnosisTitle,
                DiagnosisDetails = reportModel.DiagnosisDetails,
                ReportDate = reportModel.ReportDate,
                PhotoPath = reportModel.PhotoPath,
                LaborantId = reportModel.LaborantId,
            };
    
            _reportRepository.Add(report);

            return result; 

    
        }
        public List<Report> GetAll()
        {
            var result = false;

            var report = _reportRepository.GetAll();

            return report;
        }

        public bool Update(ReportModel reportModel)
        {
            var report = _reportRepository.Find(x => x.Id == reportModel.Id).SingleOrDefault();

            _mapper.Map(reportModel, report);

            _reportRepository.Update(report);

            return true;
        }

        public ReportModel GetReportById(int id)
        {
            var report = _reportRepository.Find(x => x.Id == id).SingleOrDefault();

            var reportModel = _mapper.Map<ReportModel>(report);

            return reportModel;
        }

        public bool Delete(long id)
        {
           var report = _reportRepository.Find(x => x.Id == id).SingleOrDefault();

            _reportRepository.Delete(report);

            return true;
        }
    }
}
