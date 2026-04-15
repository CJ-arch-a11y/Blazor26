
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor26.Models.Models
{
    public class Sales
    {
        public int Id { get; set; }
        public DateTime MonthName { get; set; }
        public decimal SalesAmount { get; set; }
        public int ProductID { get; set; }

        public Product? Product { get; set; }

    }
}
