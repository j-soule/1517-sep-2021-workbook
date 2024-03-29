﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeConsole.Data;

namespace PracticeConsole.Data
{
    //supervisory level is the data type name of the enum
    //the data type of an enum is a whole number: default type of int
    public enum SupervisoryLevel //to create enum, add new class and change
    {
        
        Entry,          //= 0 by default
        TeamMember,     //= 1 by default
        TeamLeader,     //= 2 by default
        Supervisor,     //= 3 by default
        DepartmentHead, //= 4 by default
        Owner           //= 5 by default
    }
}
