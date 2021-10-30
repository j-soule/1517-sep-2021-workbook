using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class BasicDataMovementModel : PageModel
    {
        //data members
        public string MyName;

        //properties
        [TempData]

        public string FeedbackMessage { get; set; }
        [BindProperty(SupportsGet = true)]

        public int? id { get; set; } //? makes it a nullable feed, it doesnt have to exist

        //constructors

        //behaviours aka methods
        public void OnGet()
        {
            //events (event driven logic)
            //Deafult Request event is OnGet(),
            //executed each time the page is entered and or refreshed
            //if no form post with a RedirecToPage
            Random rdn = new Random();
            int oddeven = rdn.Next(0, 25);
            if (oddeven % 2 == 0)
            {
                MyName = $"Jen is {oddeven}";
            }
            else
            {
                MyName = null;
            }
        }
        
        //Request method:
        //handles post methods from forms
        //request obj goes ito code, 
        //public IActionResult OnPost()
        //{
        //    Thread.Sleep(2000);
        //    string buttonvalue = Request.Form["theButton"];
        //    if (buttonvalue.Equals("A"))
        //    {
        //        //use an asp page handler to get to the logic for this
        //        //true path
        //    }
        //    else if (buttonvalue.Equals("B"))
        //    {

        //    }
        //    FeedbackMessage = buttonvalue;
        //    //the RedirectToPage will cause the OnGet to execute
        //    return RedirectToPage();
        //}

        //if you have a handler on the submit button and name your event method using OnPostxxxx where xxxx is the asp-page-handler
        //then this method will be executed instead of the general OnPost

        //this method (event) logic is dedicated to the action required by the pressed button
         public IActionResult OnPostAButton()
        {
            Thread.Sleep(1000);
           // string buttonvalue = Request.Form["theButton"];
            FeedbackMessage = $"You pressed the the A button, input was {id}";
            //the RedirectToPage will cause the OnGet to execute
            // we will crearte an anonymous obj and assign the desired value
            //  to the obj
            return RedirectToPage(new { id = id }); //new returns an instance of an obj {dynamically created obj}

        }

        //these method replace having to do a bunch of if/else logic

        public IActionResult OnPostBButton()
        {
            Thread.Sleep(1000);
            // string buttonvalue = Request.Form["theButton"];
            FeedbackMessage = $"You pressed the B button, input was {id}";
            //the RedirectToPage will cause the OnGet to execute
            return RedirectToPage(new { id = id});

        }
    }
}
