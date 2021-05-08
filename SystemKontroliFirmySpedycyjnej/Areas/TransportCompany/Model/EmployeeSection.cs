using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemKontroliFirmySpedycyjnej.Areas.TransportCompany.Model
{
    public class EmployeeModel2
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    public class EmployeeSection
    {
        public string SectionName { get; set; }
        public List<EmployeeModel2> listEmp;
        public EmployeeSection()
        {
            this.listEmp = new List<EmployeeModel2>();
        }
    }
}