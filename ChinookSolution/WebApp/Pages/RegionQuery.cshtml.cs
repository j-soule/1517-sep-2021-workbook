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
    public class RegionQueryModel : PageModel
    {
        #region Private service fields, FeedBackMessage & constructor


        // private readonly RegionServices _regionServices;

        // public RegionQueryOneModel
        #endregion

        public Region regionInfo { get; set; }

        [BindProperty(SupportsGet = true)]
        public int regionid { get; set; }



        public void OnGet()
        {
            //executes when the page first comes up
            //executes on a Post Redirect Get
            //what you want to get as a pattern
            //th epost will recive incoming data, validate and forward to teh GET
            //the get will make the query call and obtain the database information
            if (regionid.HasValue)
            {
                regionInfo = _regionservices.Region_GetByID((int)regionid);
            }
            
       
        }

        public IActionResult OnPost()
        {
            if (regionid <= 0)
            {
                FeedbackMessage = "Region id values are 1 or greater";
            }
            //RedirectToPage will cause the post redirct Get response

            return RedirectToPage(new { regionid = regionid });
        }

    }

}
