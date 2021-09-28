﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeConsole.Data;

namespace PracticeConsole.Data
{
    
    // source
    //https://www.c-sharpcorner.com/article/understanding-structures-in-C-Sharp/#:~:text=C%23%20Struct%2C%20A%20structure%20in,structure%20are%20created%20in%20stack.
    public struct ResidentAddress
    {
        //struct is value type
        //cant have collections
        //can have arrays
        //can contain other structs
        //can have public, public readonly, private fields 
        // properties - jsut taking in data and storing it
        public readonly int Number;
        public string Address1;
        public string Address2;
        private string _Unit;
        private string _City;
        public string ProvinceState;

        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        //no parameterless constructor
        //only constructor you can have is a greedy constructor

        public ResidentAddress(int Number, string Address1, string Address2, string Unit,
                                string City, string ProvinceState)
        {
            this.Number = Number;
            this.Address1 = Address1;
            this.Address2 = Address2;
            this.ProvinceState = ProvinceState;
            _Unit = Unit;
            _City = City;

        }
    }
}

