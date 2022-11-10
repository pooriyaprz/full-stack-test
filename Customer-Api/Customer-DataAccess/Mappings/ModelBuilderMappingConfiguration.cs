using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_DataAccess.Mappings
{
    public static class ModelBuilderMappingConfiguration
    {
        public static void AddMappings(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMappings());
        }
    }
}
