using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq.Expressions;
using SystemKontroliFirmySpedycyjnej.Areas.TransportCompany.Data;

namespace SystemKontroliFirmySpedycyjnej.Areas.TransportCompany.DAL
{
    public class DataBaseCompany : DbContext, IDataBaseCompany
    {
        public DataBaseCompany() : base("FirmaSpedycyjnaEntities")
        {

        }
        public DbSet<Cars> companyCars { get; set; }
        public DbSet<Employee> companyEmpl { get; set; }
        public DbSet<EmployeeSection> companySections { get; set; }
        public DbSet<Contractor> companyContractor { get; set; }
        public DbSet<Meetings> companyMeetings { get; set; }

        public DbSet<TransportCount> companyTransportCount { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public IQueryable<Employee> SelectAllEmpl()
        {
            return companyEmpl.Where(x => x.EmpId > 0);
        }
        public Employee SelectByIdEmpl(Expression<Func<Employee, bool>> func)
        {
            return companyEmpl.Where(func).FirstOrDefault();
        }
        public void AddNewEmpl(Employee newEmp)
        {
            companyEmpl.Add(newEmp);
        }

        public void UpdateEmpl(Employee thisEmp)
        {
            companyEmpl.Attach(thisEmp);
            SaveChanges();
        }

        public void DeleteEmpl(Expression<Func<Employee, bool>> func)
        {
            Employee tmp = SelectByIdEmpl(func);
            companyEmpl.Remove(tmp);
        }

        public IQueryable<EmployeeSection> SelectAllEmpSec()
        {
            return companySections.Where(x => x.SectionId > 0);
        }
        public EmployeeSection SelectByIdEmpSec(Expression<Func<EmployeeSection, bool>> func)
        {
            return companySections.Where(func).FirstOrDefault();
        }
        public void AddNewEmpSec(EmployeeSection newEmpSec)
        {
            companySections.Add(newEmpSec);
        }

        public void UpdateEmplSec(EmployeeSection newEmpSec)
        {
            companySections.Attach(newEmpSec);
            SaveChanges();
        }

        public void DeleteEmplSec(Expression<Func<EmployeeSection, bool>> func)
        {
            EmployeeSection tmp = SelectByIdEmpSec(func);
            companySections.Remove(tmp);
        }

        public IQueryable<Cars> SelectAllCars()
        {
            return companyCars.Where(x => x.CarId > 0);
        }
        public Cars SelectByIdCar(Expression<Func<Cars, bool>> func)
        {
            return companyCars.Where(func).FirstOrDefault();
        }
        public void AddNewCar(Cars newEmp)
        {
            companyCars.Add(newEmp);
        }

        public void UpdateCar(Cars thisEmp)
        {
            companyCars.Attach(thisEmp);
            SaveChanges();
        }

        public void DeleteCar(Expression<Func<Cars, bool>> func)
        {
            Cars tmp = SelectByIdCar(func);
            companyCars.Remove(tmp);
        }
        public IQueryable<Meetings> SelectAllMeetings()
        {
            return companyMeetings.Where(x => x.MeetId > 0);
        }
        public Meetings SelectByIdMeetings(Expression<Func<Meetings, bool>> func)
        {
            return companyMeetings.Where(func).FirstOrDefault();
        }
        public void AddNewMeetings(Meetings newEmp)
        {
            companyMeetings.Add(newEmp);
        }

        public void UpdateMeetings(Meetings thisEmp)
        {
            companyMeetings.Attach(thisEmp);
            SaveChanges();
        }

        public void DeleteMeetings(Expression<Func<Meetings, bool>> func)
        {
            Meetings tmp = SelectByIdMeetings(func);
            companyMeetings.Remove(tmp);
        }

        public IQueryable<Contractor> SelectAllContractor()
        {
            return companyContractor.Where(x => x.ContractorId > 0);
        }
        public Contractor SelectByIdContractor(Expression<Func<Contractor, bool>> func)
        {
            return companyContractor.Where(func).FirstOrDefault();
        }
        public void AddNewContractor(Contractor newEmp)
        {
            companyContractor.Add(newEmp);
        }

        public void UpdateContractor(Contractor thisEmp)
        {
            companyContractor.Attach(thisEmp);
            SaveChanges();
        }

        public void DeleteContractor(Expression<Func<Contractor, bool>> func)
        {
            Contractor tmp = SelectByIdContractor(func);
            companyContractor.Remove(tmp);
        }

        public IQueryable<TransportCount> SelectAllTransportCount(int year)
        {
            return companyTransportCount.Where(x => x.Year.Value == year);
        }
        public TransportCount SelectByIdTransportCount(Expression<Func<TransportCount, bool>> func)
        {
            return companyTransportCount.Where(func).FirstOrDefault();
        }
        public void AddNewTransportCount(TransportCount newEmp)
        {
            companyTransportCount.Add(newEmp);
        }

        public void UpdateTransportCount(TransportCount thisEmp)
        {
            companyTransportCount.Attach(thisEmp);
            SaveChanges();
        }

        public void DeleteTransportCount(Expression<Func<TransportCount, bool>> func)
        {
            TransportCount tmp = SelectByIdTransportCount(func);
            companyTransportCount.Remove(tmp);
        }

        public int CountCarsById(Expression<Func<Cars, bool>> func)
        {
            return companyCars.Where(func).Count();
        }
        public IQueryable<Cars> GetCarById(Expression<Func<Cars, bool>> func)
        {
            return companyCars.Where(func);
        }
    }
}