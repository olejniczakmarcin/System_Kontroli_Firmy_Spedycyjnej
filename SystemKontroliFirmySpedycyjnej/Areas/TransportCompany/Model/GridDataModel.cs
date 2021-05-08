using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemKontroliFirmySpedycyjnej.Areas.TransportCompany.Model
{
    public class GridDataModel
    {
        public string ComapnyName { get; set; }
        public string CompanyHeadQuaters { get; set; }
        public int? MeetId { get; set; }
        public int? ContractorId { get; set; }
        public string DateOfMeeting { get; set; }
        public string PlaceOfMeeting { get; set; }
        public string IsOnline { get; set; }
    }
}