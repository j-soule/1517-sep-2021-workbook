using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


#region Additional Namespaces
using WestWindSystem.BLL;
using WestWindSystem.Entities;
using WebApp.Helpers;
#endregion

namespace WebApp.Pages
{
    public class TerritoriesCRUDModel : PageModel
    {
        #region Private service fields, FeedBackMessage & constructor


        private readonly TerritoryServices _territoryservices;

        public TerritoriesCRUDModel(TerritoryServices territoryservices)
        {
            _territoryservices = territoryservices;
        }

        [TempData]
        public string FeedbackMessage { get; set; }
        #endregion

        [BindProperty(SupportsGet = true)]
        public int? regionid { get; set; }
        [BindProperty]
        public List<Territory> territoryInfo { get; set; }

        #region Paginator
        //need to know my desired page size
        private const int PAGE_SIZE = 5;
        //instance of the Paginator
        public Paginator Pager { get; set; }
        #endregion
        public void OnGet(int? currentPage)
        {
            if (regionid.HasValue)
            {
                //using the paginator with your query

                //OnGet will have a parameter (Request query string) that recieves the current page
                //number. On the inital load of the page, this value will
                //be null.

                //determine the current page number
                int pagenumber = currentPage.HasValue ? currentPage.Value : 1;
                //set up the current state of the paginator (sizing)
                PageState current = new(pagenumber, PAGE_SIZE);
                //temporary int to hold the result of the queries total collection size
                int totalcount;
                //we need to pass paging data into our query so thatt efficiencies in teh system 
                //will only return the amoutn of records to actually be displayed on the
                //browser page

                territoryInfo = _territoryservices.Territory_GetForRegion((int)regionid, pagenumber, PAGE_SIZE, out totalcount);

                Pager = new Paginator(totalcount, current);
            }
        }
    }
}
