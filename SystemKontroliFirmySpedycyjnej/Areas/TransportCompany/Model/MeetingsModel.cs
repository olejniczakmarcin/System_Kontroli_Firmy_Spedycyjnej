using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemKontroliFirmySpedycyjnej.Areas.TransportCompany.Model
{
    public class MeetingsModel
    {
        public int? MeetId { get; set; }
        public int? ContractorId { get; set; }
        public string DateOfMeetings { get; set; }
        public string PlaceOfMeetings { get; set; }
        public bool IsOnline { get; set; }
    }
}