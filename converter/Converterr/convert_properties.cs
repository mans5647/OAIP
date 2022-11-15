using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    public class Company_model
    {
        public string CompanyName = string.Empty;
        public string CompanyHeadquarter = string.Empty;
        public int CompanyNumOFEmployees;
        public long CompanyRevenue;

        public Company_model(string name, string hq, int nofe, long revenue)
        {
            CompanyName = name;
            CompanyHeadquarter = hq;
            CompanyNumOFEmployees = nofe;
            CompanyRevenue = revenue;
        }
    }
}
