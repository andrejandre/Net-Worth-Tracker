using Facet.Core;
using Facet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facet.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IFacetData facetData;

        public IEnumerable<FinancialRecord> FinancialRecords { get; set; }

        [BindProperty]
        public decimal NetWorth { get; set; }

        [BindProperty]
        public decimal AssetTotal { get; set; }

        [BindProperty]
        public decimal LiabilityTotal { get; set; }

        [BindProperty]
        public string Message { get; set; }

        [BindProperty]
        public string AddedMessage { get; set; }

        [BindProperty]
        public FinancialRecord FinancialRecord { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public IndexModel(IFacetData facetData)
        {
            this.facetData = facetData;
        }

        public void OnGet()
        {
            FinancialRecord = new FinancialRecord();
            FinancialRecords = facetData.GetFinancialRecordsByName(SearchTerm);
            NetWorth = facetData.CalculateNetWorth();
            AssetTotal = facetData.CalculateAssetsTotal();
            LiabilityTotal = facetData.CalculateLiabilitiesTotal();
        }

        public IActionResult OnPost(string submit)
        {
            if (ModelState.IsValid)
            {
                AddedMessage = "Financial Record added! Feel free to add a new one, or review your net worth.";
                facetData.Add(FinancialRecord);
                facetData.Commit();
            }
            else
            {
                AddedMessage = "";
                Message = "Attempted " + FinancialRecord.Type.ToString() + " entry is not valid.";
            }
            OnGet();
            return Page();
        }
    }
}
