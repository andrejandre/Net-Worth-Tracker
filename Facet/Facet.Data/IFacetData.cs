using Facet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facet.Data
{
    public interface IFacetData
    {
        IEnumerable<FinancialRecord> GetFinancialRecordsByName(string name);
        FinancialRecord GetById(int id);
        int Commit();
        FinancialRecord Delete(int id);
        FinancialRecord Add(FinancialRecord newRecord);

        decimal CalculateNetWorth();

        decimal CalculateAssetsTotal();

        decimal CalculateLiabilitiesTotal();
    }    
}
