using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



#region
using WestWindSystem.BLL;
using WestWindSystem.Entities;
#endregion
namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        #region Private service fields, feedback message & constructor

        private readonly ILogger<IndexModel> _logger;
        private readonly WestWindServices _westwindservices;

        /*
         *Services that are registered using AddTransient<>()
         *  can be accessed on the constructor of teh webpage class
         *  This is referred to as the Dependancy Injection
         *  Each service that is injected is listed on the constructor as a partameter
         *  ILogger is a service form Microsoft Logging Exrensions
         *  
         *  
         *  We need to add our required service(s) to this page
         *  Our services will be known by the BLL class name
         *  
         *  When you add a service to the page, you will save the 
         *  service refrence in a private readonly field
         *  This Variable will be availavble  to all methods within
         *  this class
         */

        public IndexModel(ILogger<IndexModel> logger,
                            WestWindServices westwindservices)
        {
            _logger = logger;
            //save your incoming service registration to your
            //private readonly variable
            _westwindservices = westwindservices;
        }

        [TempData]
        public string FeedbackMessage { get; set; }

        #endregion

        #region Web Page variables and data

        public BuildVersion buildVersion { get; set; }
        #endregion
        public void OnGet()
        {
            /*
             * to obtain data to display to your page should
             * be done in the OnGet()
             */

            //call the GetBuildVersion() registers in the WestWindServices
            //input: none  output: instance of BuildVersion

            buildVersion = _westwindservices.GetBuildVersion(); //call
        }
    }
}
