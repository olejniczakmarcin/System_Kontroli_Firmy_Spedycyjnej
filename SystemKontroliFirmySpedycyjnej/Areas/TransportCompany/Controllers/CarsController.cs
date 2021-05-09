using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemKontroliFirmySpedycyjnej.Areas.TransportCompany.DAL;
using SystemKontroliFirmySpedycyjnej.Areas.TransportCompany.Model;

namespace SystemKontroliFirmySpedycyjnej.Areas.TransportCompany.Controllers
{
    public class CarsController : Controller
    {
        // GET: TransportCompany/Cars

        private IDataBaseCompany _dataBaseCompany;
        public CarsController()
        {
            _dataBaseCompany = new DataBaseCompany();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CompanyCars()
        {
            ViewData["data"] = string.Format("Today is {0}", DateTime.Now.Date.ToString("yyyy-MM-dd"));
            return View();
        }

        public JsonResult GetDataToTable(string sord, int page, int rows, string searchString)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var results = _dataBaseCompany.SelectAllCars().Select(
                 a => new {
                    a.CarId,
                    a.CarName,
                    a.CurrentResearch,
                    a.EmpId,
                    a.Millage,
                    a.VehicleCondition,
                });
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
                results = results.Where(m => m.CarName == searchString);
            }

            return Json(new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = results
            }, JsonRequestBehavior.AllowGet);
        }
    }
}