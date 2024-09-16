using DataAcces.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.GenericRepository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly LaboratoryReportManagementSystemContext _laboratoryReportManagementSystemContext;

        public Repository(LaboratoryReportManagementSystemContext laboratoryReportManagementSystemContext)
        {
            _laboratoryReportManagementSystemContext = laboratoryReportManagementSystemContext;
        }

        public async Task Add(T entity)
        {
            try
            {
                _laboratoryReportManagementSystemContext.Set<T>().Add(entity);
                _laboratoryReportManagementSystemContext.SaveChanges();
            } 
            catch (Exception ex)
            {
                new Exception("Beklenmedik hata");
            }

        }

        public async Task Delete(T entity)
        {
            _laboratoryReportManagementSystemContext.Set<T>().Remove(entity);
            _laboratoryReportManagementSystemContext.SaveChanges();
        }
         
        public async Task Update(T entity)
        {
            _laboratoryReportManagementSystemContext.Set<T>().Update(entity);
            _laboratoryReportManagementSystemContext.SaveChanges();

        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            try
            {
                return _laboratoryReportManagementSystemContext.Set<T>().Where(expression);
            }
            catch (Exception ex)
            {
                throw new Exception($"İfade ile bulma işleminde beklenmeyen hata.");
            }
        }

        public  List<T> GetAll()
        {
            try
            {
                return _laboratoryReportManagementSystemContext.Set<T>().ToList();

            }
            catch
            {
                throw new Exception($"İfade ile bulma işleminde beklenmeyen hata.");

            }
        }

    }
}
