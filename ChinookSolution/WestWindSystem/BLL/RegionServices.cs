﻿using System;
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
    public class RegionServices
    {
        #region Context variable & constructor
        private readonly WestwindContext _context;

        internal RegionServices(WestwindContext context)
        {
            _context = context;
        }
        #endregion

        #region Queries
        //get ALL the records of the sql Region Table
        //return as a List<T> //need for exercise 5
        public List<Region> Region_List()
        {
            IEnumerable<Region> info = _context.Regions
                                               .OrderBy(anyRegionRecord =>
                                                        anyRegionRecord.RegionDescription);
            return info.ToList();
        }

        //get a Region record based on the RegionId value parameter
        //return is an instance of Region OR a null value
        public Region Region_GetByID(int regionid)
        {
            Region info = _context.Regions
                                  .Where(x => x.RegionId == regionid)
                                  .FirstOrDefault();
            return info;
        }

        //get a set of Region records that match a string of RegionDescription characters
        //typically referred to as a partial lookup
        //this is usually on any field that is not the pkey
        //this will return 0, 1 or more records that match the filter test (.Where)
        public List<Region> Region_GetByPartialDescription(string partialdescription)
        {
            IEnumerable<Region> info = _context.Regions
                                               .Where(x => x.RegionDescription.Contains(partialdescription));
            return info.ToList();
        }
        #endregion
    }
}