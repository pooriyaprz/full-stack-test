using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        int Complete();
    }
}
