﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace WestWindSystem.Entities
{
    [Table("Territories")]
    public class Territory
    {
        // the primary key for the sql table is NOT an identitypkay
        //therefore you must adda second attribute when delcaring
        // this property
        //the new attribute will indicate to EntityFramework that the
        //pkay value will be supplied for insert records
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string TerritoryID { get; set; }
        public string TerritoryDescription { get; set; }

        //this is your foreign key
        //IF your property name is the SAME as the parent table
        // property name, you DO NOT need to add an annotation
        //  for [foregin key} to thr property
        public int RegionID { get; set; }
    }
}
