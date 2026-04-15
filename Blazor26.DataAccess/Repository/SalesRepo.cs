using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor26.DataAccess.DataAccess;
using Blazor26.Models.Models;

namespace Blazor26.DataAccess.Repository
{
    public class SalesRepo : Repository<Sales>, ISalesRepo
    {

        private readonly AppDBContext _dbContext;

        public SalesRepo(AppDBContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
        }







    }
}
