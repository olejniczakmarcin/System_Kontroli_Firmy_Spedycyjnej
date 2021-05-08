using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemKontroliFirmySpedycyjnej.Areas.TransportCompany.Model
{
    public class CarGridModel
    {
        public int? CarId { get; set; }
        public int? EmpId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Millage { get; set; }
        public string VehicleCondition { get; set; }
        public bool? CurrentResearch { get; set; }
    }
}