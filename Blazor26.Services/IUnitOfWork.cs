

using Blazor26.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor26.Services
{
    public interface IUnitOfWork :IDisposable
    {
        ICategoryRepo CategoryRepo { get; }
        IProductRepo ProductRepo { get; }
        ISalesRepo SalesRepo { get; }

        void Save();
    }
}
