using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemKontroliFirmySpedycyjnej.Areas.TransportCompany.DAL;
using SystemKontroliFirmySpedycyjnej.Areas.TransportCompany.Model;

namespace SystemKontroliFirmySpedycyjnej.Areas.TransportCompany.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: TransportCompany/Employee
        private IDataBaseCompany _dataBaseCompany;
        public EmployeeController()
        {
            _dataBaseCompany = new DataBaseCompany();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EmployeeInfo()
        {
            ViewData["data"] = string.Format("Today is {0}", DateTime.Now.Date.ToString("yyyy-MM-dd"));
            return View();
        }
        public PartialViewResult SubGridEmployeeInfo(int id)
        {
            return PartialView("SubGridEmployeeInfo", id);
        }
        public JsonResult GetDataToTable(string sord, int page, int rows, string searchString)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            List<EmployeeGridModel> dataGrid = new List<EmployeeGridModel>();
            var results = _dataBaseCompany.SelectAllEmpl();
            int totalRecords = results.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            if (sord.ToUpper() == "DESC")
            {
                results = results.OrderByDescending(s => s.EmpId);
                results = results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                results = results.OrderBy(s => s.EmpId);
                results = results.Skip(pageIndex * pageSize).Take(pageSize);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                results = results.Where(m => m.Name == searchString);
            }

            foreach (var item in results)
            {
                EmployeeGridModel data = new EmployeeGridModel
                {
                    EmpId = item.EmpId,
                    Name = item.Name,
                    Surname = item.Surname,
                    PlaceOfResidence = item.PlaceOfResidence,
                    Gender = item.Gender,
                    Age = item.Age,
                };
                dataGrid.Add(data);
            }

            return Json(new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = dataGrid
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SubGridGetDataToTable(string sord, int page, int rows, string searchString, int id)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            List<CarGridModel> dataGrid = new List<CarGridModel>();
            var results = _dataBaseCompany.GetCarById(x=>x.EmpId == id);
            int totalRecords = _dataBaseCompany.CountCarsById(x=>x.EmpId == id);
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            foreach (var item in results)
            {
                CarGridModel data = new CarGridModel
                {
                    CarId = item.CarId,
                    EmpId = item.EmpId,
                    Name = item.CarName,
                    Millage = item.Millage,
                    VehicleCondition = item.VehicleCondition,
                    CurrentResearch = item.CurrentResearch,
                };
                dataGrid.Add(data);
            }

            return Json(new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = dataGrid
            }, JsonRequestBehavior.AllowGet);
        }

    }
}