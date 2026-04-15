using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor26.DataAccess.DataAccess;
using Blazor26.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor26.DataAccess.Repository
{
    public class SalesRepo : Repository<Sales>, ISalesRepo
    {

        private readonly AppDBContext _dbContext;

        public SalesRepo(AppDBContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
        }

        public Task<List<Sales>> ListofSalesDataAsync()
        {
            var listofSales = _dbContext.Sales.OrderBy(s => s.MonthName).Include(p => p.Product).ToListAsync();
            var count = listofSales.Result.Count;
            Console.WriteLine($"Loaded {count} sales rows");
            return listofSales;
        }

    }
}
