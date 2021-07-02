using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facet.Core;
using Microsoft.EntityFrameworkCore;

namespace Facet.Data
{
    public class FacetDbContext : DbContext
    {
        public FacetDbContext(DbContextOptions<FacetDbContext> options)
            : base(options)
        {

        }
        public DbSet<FinancialRecord> FinancialRecords { get; set; }
    }
}
