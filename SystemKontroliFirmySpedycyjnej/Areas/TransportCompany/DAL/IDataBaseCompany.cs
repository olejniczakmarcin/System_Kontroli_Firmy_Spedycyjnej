using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using SystemKontroliFirmySpedycyjnej.Areas.TransportCompany.Data;

namespace SystemKontroliFirmySpedycyjnej.Areas.TransportCompany.DAL
{
    public interface IDataBaseCompany
    { 
        IQueryable<Employee> SelectAllEmpl();
        Employee SelectByIdEmpl(Expression<Func<Employee, bool>> func);
        void AddNewEmpl(Employee newEmp);
        void UpdateEmpl(Employee thisEmp);
        void DeleteEmpl(Expression<Func<Employee, bool>> func);
        IList<Employee> GetEmplByParameter(Expression<Func<Employee, bool>> func);

        IQueryable<EmployeeSection> SelectAllEmpSec();
        EmployeeSection SelectByIdEmpSec(Expression<Func<EmployeeSection, bool>> func);
        void AddNewEmpSec(EmployeeSection newEmpSec);
        void UpdateEmplSec(EmployeeSection thisEmpSec);
        void DeleteEmplSec(Expression<Func<EmployeeSection, bool>> func);

        IQueryable<Cars> SelectAllCars();
        Cars SelectByIdCar(Expression<Func<Cars, bool>> func);
        void AddNewCar(Cars newCar);
        void UpdateCar(Cars thisCar);
        void DeleteCar(Expression<Func<Cars, bool>> func);
        int CountCarsById(Expression<Func<Cars, bool>> func);
        IQueryable<Cars> GetCarById(Expression<Func<Cars, bool>> func);

        IQueryable<Meetings> SelectAllMeetings();
        Meetings SelectByIdMeetings(Expression<Func<Meetings, bool>> func);
        void AddNewMeetings(Meetings meetings);
        void UpdateMeetings(Meetings meetings);
        void DeleteMeetings(Expression<Func<Meetings, bool>> func);

        IQueryable<Contractor> SelectAllContractor();
        Contractor SelectByIdContractor(Expression<Func<Contractor, bool>> func);
        void AddNewContractor(Contractor contractor);
        void UpdateContractor(Contractor contractor);
        void DeleteContractor(Expression<Func<Contractor, bool>> func);

        IQueryable<TransportCount> SelectAllTransportCount(int year);
        TransportCount SelectByIdTransportCount(Expression<Func<TransportCount, bool>> func);
        void AddNewTransportCount(TransportCount contractor);
        void UpdateTransportCount(TransportCount contractor);
        void DeleteTransportCount(Expression<Func<TransportCount, bool>> func);
    }
}