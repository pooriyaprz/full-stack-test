using Customer_DataAccess.DataBase;
using Customer_DataAccess.Repositories;
using Customer_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_DataAccess.UnitOfWorks
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            
        }

        public int Complete()
        {
            return  _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
