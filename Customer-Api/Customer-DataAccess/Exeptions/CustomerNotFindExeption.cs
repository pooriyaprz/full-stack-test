using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_DataAccess.Exeptions
{
    public class CustomerNotFindExeption : Exception
    {
        public CustomerNotFindExeption(string message):base(message)
        {
            
        }

    }
}
