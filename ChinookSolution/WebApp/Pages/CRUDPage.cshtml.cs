using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


#region Additional Namespaces
using WestWindSystem.Entities;
using WestWindSystem.BLL;
#endregion

namespace WebApp.Pages
{
    public class CRUDPageModel : PageModel
    {
        #region Private service fields, FeedBackMessage & constructor (dependency injection)

        private readonly TerritoryServices _territoryservices;
        private readonly RegionServices _regionservices;


        public CRUDPageModel(TerritoryServices territoryservices,
                            RegionServices regionservices)
        {

            _territoryservices = territoryservices;
            _regionservices = regionservices;
        }

        [TempData]
        public string FeedbackMessage { get; set; }

        public bool HasFeedback => !string.IsNullOrWhiteSpace(FeedbackMessage);
        #endregion
        [TempData]
        public string ErrorMessage { get; set; }

        public bool HasError => !string.IsNullOrWhiteSpace(ErrorMessage);

        [BindProperty(SupportsGet = true)]
        
        public string territoryid { get; set; }

        // this holds the territory record we are maintaining
        [BindProperty]
        public Territory territoryInfo { get; set; }

        [BindProperty]
        public List<Region> regionInfo { get; set; }
      

        public void OnGet()
        {
            if (!string.IsNullOrWhiteSpace(territoryid))
            {
                territoryInfo = _territoryservices.Territory_GetyID(territoryid);
            }
            regionInfo = _regionservices.Region_List();
        }

        public IActionResult OnPostNew()
        {
            
            if(ModelState.IsValid)
            {
                //this has to be done in a user freindly error handling environment
                try
                {

                    // call the appropriate TerritoryService to attempt to add the
                    //    data to the
                    // in this example there is NO returning value for the pkey BECAUSE
                    //     TerritoryID is NOT an identiiy pkey
                    _territoryservices.Territory_Add(territoryInfo);
                    FeedbackMessage = "Teritory has been added";
                    return RedirectToPage(new { territoryid = territoryid });
                }
                catch (Exception ex)
                {
                    ErrorMessage = GetInnerException(ex).Message;
                    regionInfo = _regionservices.Region_List(); //retreive data for the dropdownlist
                    return Page(); //Page IS NOT the same as RedirectToPage, does not go to OnGet
                }
            }
            else
            {
                //ErrorMessage = GetInnerException(ex).Message;
                //regionInfo = _regionservices.Region_List(); //retreive data for the dropdownlist
                //return Page(); //Page IS NOT the same as RedirectToPage, does not go to OnGet
                return Page();
            }
        }

        public IActionResult OnPostUpdate()
        {
           if(ModelState.IsValid)
           {
               try
               {
                    // call the appropriate TerritoryService to attempt to update the
                    //    data on the database
                    int rowsaffected = _territoryservices.Territory_Update(territoryInfo);
                    if (rowsaffected > 0)
                    {
                        FeedbackMessage = "Territory has been updated";

                    }
                    else
                    {
                        FeedbackMessage = "Territory has been not been updated. Territory does not appear to be on file. Refresh your search.";

                    }
                    return RedirectToPage(new { territoryid = territoryid });

               }
               catch (Exception ex)
               {
                    ErrorMessage = GetInnerException(ex).Message;
                    regionInfo = _regionservices.Region_List(); //retreive data for the dropdownlist
                    return Page(); //Page IS NOT the same as RedirectToPage, does not go to OnGet

               }
                
           }
            else
            {
                
                return Page(); //Page IS NOT the same as RedirectToPage, does not go to OnGet
            }
            

    }

        public IActionResult OnPostRemove()
        {

            if(ModelState.IsValid)
            {
                //this has to be done in a user freindly error handling environment
                try
                {
                    // call the appropriate TerritoryService to attempt to remove the
                    //    data from the database
                    int rowsaffected = _territoryservices.Territory_Delete(territoryInfo);
                    if (rowsaffected > 0)
                    {
                        FeedbackMessage = "Territory has been removed";

                    }
                    else
                    {
                        FeedbackMessage = "Territory has been not been removed. Territory does not appear to be on file. Refresh your search.";

                    }
                    return RedirectToPage(new { territoryid = "" });

                }
                catch (Exception ex)
                {
                    ErrorMessage = GetInnerException(ex).Message;
                    regionInfo = _regionservices.Region_List(); //retreive data for the dropdownlist
                    return Page(); //Page IS NOT the same as RedirectToPage, does not go to OnGet

                }
                
            }
            else
            {
               
                return Page(); //Page IS NOT the same as RedirectToPage, does not go to OnGet
            }
        }
        public IActionResult OnPostClear()
        {

            return RedirectToPage(new { territoryid = "" });
        }
        public IActionResult OnPostBack()
        {
            // return RedirectToPage("/PartialFilterSearch");
            return Redirect("/PartialFilterSearch");
        }

        private Exception GetInnerException(Exception ex)
        {
            //drill down to the REAL ERROR MESSAGE
            while (ex.InnerException != null)
                ex = ex.InnerException;
            return ex;
        }

        
    }
}