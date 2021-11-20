using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespaces
using WestWindSystem.BLL;
using WestWindSystem.Entities;
#endregion

namespace WebApp.Pages
{
    public class PartialFilterSearchModel : PageModel
    {
        #region Private service fields, FeedBackMessage & constructor


        private readonly RegionServices _regionservices;

        public PartialFilterSearchModel(RegionServices regionservices)
        {
            _regionservices = regionservices;
        }

        [TempData]
        public string FeedbackMessage { get; set; }
        #endregion

       [BindProperty(SupportsGet = true)]
       public string searcharg { get; set; }

        [BindProperty]
        public List<Region> regionInfo { get; set; }


        public void OnGet()
        {
            //check to see if you have an arguement value
            if (!string.IsNullOrWhiteSpace(searcharg))
            {
                //send teh arguemnt value to the bacckend to obtain your data
                //the data will be placed in a property that will be bound to 
                //the output on the web page
                regionInfo = _regionservices.Region_GetByPartialDescription(searcharg);
            }


        }

        public IActionResult OnPostByName()
        {
            //check that a vale was really place in the input control
            //if not: give feedback requiring a value
            //retuen the entered vale to OnGet using the Post Redirect Get Technique
            if (string.IsNullOrWhiteSpace(searcharg))
            {
                FeedbackMessage = "Enter a region description before searching";
            }

            return RedirectToPage(new { searcharg = searcharg });
        }
    }
}
