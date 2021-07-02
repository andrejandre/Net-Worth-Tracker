using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Facet.Core;
using Facet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Facet.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IFacetData facetData;

        public FinancialRecord FinancialRecord { get; set; }

        public DeleteModel(IFacetData facetData)
        {
            this.facetData = facetData;
        }

        public IActionResult OnGet(int finRecordId)
        {
            FinancialRecord = facetData.GetById(finRecordId);
            if (FinancialRecord == null)
            {
                return RedirectToPage("./Error");
            }
            return Page();
        }

        // Record gets deleted
        public IActionResult OnPost(int finRecordId)
        {
            var finRecord = facetData.Delete(finRecordId);
            facetData.Commit();

            if (finRecord == null)
            {
                return RedirectToPage("./Error");
            }
            return RedirectToPage("./Index");
        }
    }
}
