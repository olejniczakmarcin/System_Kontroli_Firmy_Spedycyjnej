using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemKontroliFirmySpedycyjnej.Areas.TransportCompany.DAL;
using SystemKontroliFirmySpedycyjnej.Areas.TransportCompany.Model;

namespace SystemKontroliFirmySpedycyjnej.Areas.TransportCompany.Controllers
{
    public class EmployeeSectionController : Controller
    {
        // GET: TransportCompany/EmployeeSection
        private IDataBaseCompany _dataBaseCompany;
        public EmployeeSectionController()
        {
            _dataBaseCompany = new DataBaseCompany();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EmployeeSection()
        {
            var data = _dataBaseCompany.SelectAllEmpSec();
            List<EmployeeSection> tmpList = new List<EmployeeSection>();
            List<EmployeeModel2> emp2 = new List<EmployeeModel2>();
            foreach(var item in data)
            {
                var tmp = _dataBaseCompany.GetEmplByParameter(x => x.SectionId == item.SectionId);
                foreach(var item2 in tmp)
                {
                    emp2.Add(new EmployeeModel2
                    {
                        Name = item2.Name,
                        Surname = item2.Surname
                    });
                }
                tmpList.Add(new EmployeeSection
                {
                    SectionName = item.SectionName,
                    listEmp = tmp.Any() ? emp2 : null
                });
            }
            return View("EmployeeSection",tmpList);
        }
    }
}