
using Blazor26.DataAccess.DataAccess;
using Blazor26.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor26.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _dbContext;
        public ICategoryRepo CategoryRepo { get; private set; }
        public IProductRepo ProductRepo { get; private set; }
        public ISalesRepo SalesRepo { get; private set; }

        public UnitOfWork(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
            CategoryRepo = new CategoryRepo(_dbContext);
            ProductRepo = new ProductRepo(_dbContext);
            SalesRepo = new SalesRepo(_dbContext);

        }
        

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
