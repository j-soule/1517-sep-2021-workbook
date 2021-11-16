using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;
#endregion

namespace WestWindSystem.BLL
{
    public class WestWindServices
    {
        //I need an instance of the WestWindContext class
        private readonly WestWindContext _context;

        //i need a constructor of this class to initalize  my instance of WestWindContext
        internal WestWindServices(WestWindContext context)
        {
            _context = context;
        }

        //create a method(service) that wil retrieve the BuildVersion record
        //this will be called from the web app, thus it needs to be public
        //this becomes part of the class libraries (application library)public interface
        public BuildVersion GetBuildVersion()
        {
            //going to your context instance, calling on the DbSet property
            //which will retrieve your data from the database, then return
            //the First record from the database collection (set, dataset) OR
            //if no data was returned from SQL, set the recieving variable to null
            BuildVersion info = _context.BuildVersions.FirstOrDefault();

            return info;
        }
    }

}
