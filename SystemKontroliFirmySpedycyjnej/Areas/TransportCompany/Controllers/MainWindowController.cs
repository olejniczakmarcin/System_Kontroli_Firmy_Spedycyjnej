using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemKontroliFirmySpedycyjnej.Areas.TransportCompany.DAL;
using SystemKontroliFirmySpedycyjnej.Areas.TransportCompany.Model;

namespace SystemKontroliFirmySpedycyjnej.Areas.TransportCompany.Controllers
{
    public class MainWindowController : Controller
    {
        // GET: TransportCompany/MainWindow
        private IDataBaseCompany _dataBaseCompany;
        public MainWindowController()
        {
            this._dataBaseCompany = new DataBaseCompany();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MainWindow()
        {
            ViewData["data"] = string.Format("Today is {0}", DateTime.Now.Date.ToString("yyyy-MM-dd"));
            return View();
        }
        [HttpPost]
        public JsonResult GetChartData(int id)
        {
            var charData = _dataBaseCompany.SelectAllTransportCount(id);
            if(charData.Any())
            {
                int[] dataX = charData.Select(x => x.Month.Value).ToArray();
                int[] dataY = charData.Select(x => x.TransportCount1.Value).ToArray();
                var data = new { dataM = dataX, dataM2 = dataY, status=true };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = new { status = false };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetDataToTable(string sord, int page, int rows, string searchString)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            List<GridDataModel> dataGrid = new List<GridDataModel>();
            var results = _dataBaseCompany.SelectAllMeetings();
            int totalRecords = results.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            if (sord.ToUpper() == "DESC")
            {
                results = results.OrderByDescending(s => s.MeetId);
                results = results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                results = results.OrderBy(s => s.MeetId);
                results = results.Skip(pageIndex * pageSize).Take(pageSize);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                results = results.Where(m => m.DateOfMeeting == searchString);
            }

            foreach (var item in results)
            {
                var contractor = _dataBaseCompany.SelectByIdContractor(x => x.ContractorId == item.ContractorId);
                GridDataModel data = new GridDataModel
                {
                    MeetId = item.MeetId,
                    ContractorId = item.ContractorId,
                    DateOfMeeting = item.DateOfMeeting,
                    PlaceOfMeeting = item.PlaceOfMeeting,
                    IsOnline = item.IsOnline,
                    ComapnyName = string.IsNullOrEmpty(contractor.ContractorName) ? "No data about contractor" : contractor.ContractorName,
                    CompanyHeadQuaters = string.IsNullOrEmpty(contractor.ContractorName) ? "No data about contractor" : contractor.ContractorHeadQuarters,
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