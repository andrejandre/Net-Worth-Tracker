using Facet.Core;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Facet.Tests
{
    public class FacetTests
    {
        public List<FinancialRecord> FinRecords;

        [SetUp]
        public void Setup()
        {
            FinRecords = new List<FinancialRecord>()
            {
                new FinancialRecord { Id = 1, Type = "Asset", Name = "First Asset", Balance = 100 },
                new FinancialRecord { Id = 2, Type = "Asset", Name = "Second Asset", Balance = 100 },
                new FinancialRecord { Id = 3, Type = "Liability", Name = "First Liability", Balance = 50 },
                new FinancialRecord { Id = 4, Type = "Liability", Name = "Second Liability", Balance = 50 }
            };
        }

        [Test]
        public void ValidateAssetTotal()
        {
            decimal total = 0;
            foreach (var rec in FinRecords)
            {
                if (rec.Type.ToString() == "Asset")
                {
                    total += rec.Balance;
                }
            }
            Assert.AreEqual(total, 200m);
        }

        [Test]
        public void ValidateLiabilitiesTotal()
        {
            decimal total = 0;
            foreach (var rec in FinRecords)
            {
                if (rec.Type.ToString() == "Liability")
                {
                    total += rec.Balance;
                }
            }
            Assert.AreEqual(total, 100m);
        }

        [Test]
        public void ValidateNetworth()
        {
            decimal networth = 0;
            foreach (var rec in FinRecords)
            {
                switch (rec.Type)
                {
                    case "Asset":
                        networth += rec.Balance;
                        break;
                    case "Liability":
                        networth -= rec.Balance;
                        break;
                    default:
                        System.Diagnostics.Debug.WriteLine("Record type was not an Asset or Liability.");
                        break;
                }
            }
            Assert.AreEqual(networth, 100m);
        }

        [Test]
        public void GetRecordByNameTest()
        {
            string name = "First Asset";
            var query = from f in FinRecords
                        where f.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby f.Name
                        select f.Name;
            var toList = query.ToList();
            Assert.AreEqual(toList[0], FinRecords[0].Name);
        }
    }
}