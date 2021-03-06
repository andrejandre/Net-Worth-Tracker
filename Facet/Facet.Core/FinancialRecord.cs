using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facet.Core
{
    public class FinancialRecord
    {
        public int Id { get; set; }
        
        [Required]
        public string Type { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Balance { get; set; }
    }
}
