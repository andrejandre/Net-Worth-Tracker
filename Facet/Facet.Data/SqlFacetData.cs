using Facet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facet.Data
{
    public class SqlFacetData : IFacetData
    {
        private readonly FacetDbContext db;

        public decimal NetWorth { get; set; }

        public SqlFacetData(FacetDbContext db)
        {
            this.db = db;
        }

        public FinancialRecord Add(FinancialRecord newRecord)
        {
            db.Add(newRecord);
            return newRecord;
        }

        // Inserts the changes to the db
        public int Commit()
        {
            return db.SaveChanges();
        }

        public FinancialRecord Delete(int id)
        {
            var financialRecord = GetById(id);
            if (financialRecord != null)
            {
                db.FinancialRecords.Remove(financialRecord);
            }
            return financialRecord;
        }

        public FinancialRecord GetById(int id)
        {
            return db.FinancialRecords.Find(id);
        }

        public IEnumerable<FinancialRecord> GetFinancialRecordsByName(string name)
        {
            var query = from f in db.FinancialRecords
                        where f.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby f.Name
                        select f;
            return query;
        }

        public decimal CalculateNetWorth()
        {
            decimal networth = 0;
            foreach (var entry in db.FinancialRecords)
            {
                if (entry.Type.ToString() == "Asset")
                {
                    networth += entry.Balance;
                }
                else
                {
                    networth -= entry.Balance;
                }
            }
            return networth;
        }

        public decimal CalculateAssetsTotal()
        {
            decimal assets = 0;
            foreach (var entry in db.FinancialRecords)
            {
                if (entry.Type.ToString() == "Asset")
                {
                    assets += entry.Balance;
                }
            }
            return assets;
        }

        public decimal CalculateLiabilitiesTotal()
        {
            decimal liabilities = 0;
            foreach (var entry in db.FinancialRecords)
            {
                if (entry.Type.ToString() == "Liability")
                {
                    liabilities += entry.Balance;
                }
            }
            return liabilities;
        }
    }
}
