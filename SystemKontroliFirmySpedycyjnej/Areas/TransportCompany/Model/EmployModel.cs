using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemKontroliFirmySpedycyjnej.Areas.TransportCompany.Model
{
    public class EmployModel
    {
        public int? EmpId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PlaceOfResident { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
    }
}