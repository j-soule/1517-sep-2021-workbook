﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeConsole.Data;

/*namespace PracticeConsole.Data
{
   public class Employment
    {
        //An instance in this class will describe an employment of a job
        //the characterisitics will be
        //Title, supervisory level, years of employment within that job

        

        //the 4 components of a class definition are
        //datafield
        //property
        //constructor
        //behaviour aka method

        //datafield
        //this is a storage area in your program
        //this is a variable

        //a decalred storage area that will be associated with the Title property (1to 1 relationship)
        //normally this declaration is a private access type
        //one does not want an outside user to directly interact with the variable

        private string _Title;
        private double _Years;

        //private SupervisoryLevel Level;

        //Properties
        //these are access techniques to retrieve or set data in your class
        //without directly touching the storage field

        //fully implemented property
        // a) a declared storage area (data field)
        // b) declare the property siganture
        // c) code a get 'method'
        // d) optinally code a set

        
        public string Title
        {
            get
            {
                //accessor
                //the get "method" will return the contents of a data field as an expresssion
                return _Title;
            }
            set 
            {
                //mutator
                // the set "method" recieves an incoming value and lpaces it in the associated data field
                //during the set method, you might wish to validate the incoming data for correction
                //during the get method, you might wish to do some type of logical processing against
                //the incoming data

                //ensure that the incoming is not null or empty
                //the incoming dta is referred to using the keyword "value"
                if(string.IsNullOrEmpty(value))
                {
                    throw new Exception("Title is a required piece of data.");
                }
                else
                {
                    _Title = value;
                }
            }
        }

        

        //Auto implemented Properties
        //these properties are differnt only in syntax
        //each property is responsible for a single piece of data
        //these properties do NOT refrence a decalred internal private data memeber of their class
        //the system generates an internal storage area of the return data type
        //the system manages the internal storage for the accessor and mutator
        //there is NO additional logic applied to the data value


        //using an enum to declare a variable
        //this property is using a private set which means that the Level property
        //will only allow an outside  user (Program) to access the associate value
        //the private set must be done within the class either in a constructor or a behaviour
        //of the class
        public SupervisoryLevel Level { get; private set; }

        // the property years could be coded as either a fully implemented property (as shown) or
        //as an auto-implemented property
        public double Years 
        {
            get { return _Years; }
            set { _Years = value; }
        }

        //Constructors
        //is to initialize the created instance (physical obj) of the class (conceptual definition)
        //constructor(s) are optional
        //if your class definition has NO constructor code, thent he data members / auto implemented
        //properties are set to the C# default type value

        //you can code one of more constructor in your class definition
        //IF YOU CODE A CONSTRUCTOR FOR THE CLASS, YOU ARE RESPONSIBLE FOR ALL CONSTRUCTORS USED BY THE CLASS!!
        //
        //generally, if you are going to code your own constructor(s) you code two types
        //      Default: this constructor does NPT take in any ways: it mimics the default system constructor
        //
        //      Greedy: this constructor has a list of parameters, one for each property, decalred for incoming data
        //
        // syntax:  accesstype classname([list of parameters]) {constructor code body}

        //default constructor
        public Employment()
        {
            //constructor body
            //you could assign literal values to your properties within this constructor
            Level = SupervisoryLevel.Entry; //0
            Title = "Unknown";
        }
 
        //Greedy constructor
        public Employment(string title, SupervisoryLevel level, double years)
        {
            Title = title;
            Level = level;
            Years = years;
        }

        //Behaviours (aka Methods)
        //behaviours are no different than methods elsewhere
        //
        //syntax  accesstype returndatatype BehaviourName([list of parameters]) {code boy}
        //
        //This class has a private set for the Level property
        //the set for the Level property can be done in either a constructor or behaviour
        //thsi is and exmaple of placing data into the Level property outsideof a constructor

        public void SetEmployeeResonsibility(SupervisoryLevel level)
        {
            //maybe you might need to do some type of logical processing to assign the
            //value to the property with the private set
            Level = level;
        }

        //there may be times you widh to obtain al teh data in your instance all at once for the display
        //generally to accomplish this, your class overrides the .ToString() method of classes
        public override string ToString()
        {
            //in this example the return data values in a comma seperator string
            return $"{Title},{Level},{Years}";
        }

        public static Employment Parse(string text)
        {
            string[] parts = text.Split(',');
            if (parts.Length != 3)
            {
                throw new System.FormatException("Input string is not in the correct CSV format for an EMployment object");
            }
            //convert teh string array elements into the appropriate data types of the
            //Employment class
            string title = parts[0];
            SupervisoryLevel level = (SupervisoryLevel)Enum.Parse(typeof(SupervisoryLevel), parts[1]);
            double years = double.Parse(parts[2]);
            return new Employment(title, level, years); //use a greedy constructor
        } 
    }
}*/
namespace PracticeConsole.Data
{
    public class Employment
    {
        //An instance in this class will describe an employment of a job
        //the characteristics will be
        //  Title, supervisory level, years of employment within that job
        //the 4 components of a class definition are
        //  data field 
        //  property
        //  constructor
        //  behaviour (aka method)
        //data field
        //this is a storage area in your program
        //this is a variable
        //a declared storage area that will be associated with the Title property
        //normally this delcaration is a private access type
        //one does NOT want an outsider user to directly interact with the variable
        private string _Title;
        private double _Years;
        //Properties
        //These are access techniques to retrieve or set data in your class without
        //  directly touch the storage data field
        // fully implemented property
        //  a) a declare storage area (data field)
        //  b) declare the property signature
        //  c) code an get "method"
        //  d) optionally code a set "method"
        public string Title
        {
            get
            {
                // accessor
                //the get "method" will return the contents of a data field(s) as an expression
                return _Title;
            }
            set
            {
                //mutator
                //the set "method" receives an incoming value and places it in the associate data field
                //during the set method, you might wish to validate the incoming data for correctess
                //during the set method, you might wish to do some type of logically processing against
                //      the incoming data
                //the incoming piece of data is referred to using the keyword "value"
                //ensure that the incoming is not null or empty
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Title is a required piece of data.");
                }
                else
                {
                    _Title = value;
                }
            }
        }
        //Auto Implemented Properties
        //
        // these properties different only in syntax
        // each property is responsible for a single piece of data
        // these properties do NOT reference a declared private data member of their class
        // The system generates an internal storage area of the return data type
        // The system manages the internal storage for the assessor and mutator
        // there is NO additional logic applied to the data value
        //
        //using an enum to declare a variable
        //this property is using a private set which means that the Level property
        //      will only allow an outside user (Program) to access the associate value
        //the private set must be done within the class either in a constructor or a behaviour of the
        //      class
        public SupervisoryLevel Level { get; private set; }
        //the property Years could be code as either a fully implemented property (as shown) or
        //   as an auto-omplemented property
        public double Years
        {
            get { return _Years; }
            set { _Years = value; }
        }
        //Constructors
        //is to initialize the created instance (physical object) of the class (conceptual definition)
        //constructor(s) are optional
        //
        //if your class definition has NO constructor code, then the data members / auto implemented 
        //      properties are set to the C# default data type value
        //
        //you can code one or more constructors in your class definition
        //IF YOU CODE A CONSTRUCTOR FOR THE CLASS, YOU ARE RESPONSIBLE FOR ALL CONSTRUCTORS USED BY
        //          THE CLASS!!!!
        //
        //generally, if you are going to code your own contructor(s) you code two types
        //      Default: this constructor do NOT take in any ways: it mimics the default system constructor
        //      Greedie: this constructor has a list of parameters, one for each property, declare for incoming data
        //
        //  syntax:     accesstype classname([list of parameters]) { constructor code body }
        //
        //Default constructor
        public Employment()
        {
            //constructor body
            //you COULD assign literal values to your Properties within this constructor
            Level = SupervisoryLevel.Entry;  //0
            Title = "Unknown";
        }
        //Greedie constructor
        public Employment(string title, SupervisoryLevel level, double years)
        {
            Title = title;
            Level = level;
            Years = years;
        }
        //Behaviours (aka methods)
        //Behaviours are no different thn methods elsewhere
        //
        //syntax  accesstype returndatatype BehaviourName([list of parameters]) { code body }
        //
        //This class has a private set for the Level property
        //the set for the Level property can be done in either a constructor or behaviour
        //this is an example of placing data into the Level property outside of a constructor

        public void SetEmployeeResponsibility(SupervisoryLevel level)
        {
            //maybe you might need to do some type of logical processing to assign the 
            //    value to the property with the private set
            Level = level;
        }
        //there maybe times you wish to obtain all the data in your instance all at once for display
        //generally to accomplish this, your class overrides the .ToString() method of classes
        public override string ToString()
        {
            //in this example, return the data values in a comma separater value string
            return $"{Title},{Level},{Years}";
        }

        public static Employment Parse(string text)
        {
            string[] parts = text.Split(',');
            if (parts.Length != 3)
            {
                throw new System.FormatException("Input string is not in the correct CSV format for an Employment object");
            }
            //covert the string array elements into the appropriate data type of the
            //  Employment class
            string title = parts[0];
            SupervisoryLevel level = (SupervisoryLevel)Enum.Parse(typeof(SupervisoryLevel), parts[1]);
            double years = double.Parse(parts[2]);
            return new Employment(title, level, years);
        }

        public static bool TryParse(string text, out Employment result)
        {
            bool valid = false;

            //create a try/catch that will call the .parse for this class
            //if the parsing is successful, we will set the out variable
            //  to the parsed instance and change the valid flag to true
            //if the parsing is not successful, we will set the out
            //  variable to null and not change the valid flag

            try
            {
                result = Parse(text);
                valid = true;
            }
            catch
            {
                result = null;
            }

            return valid;
        }
    }
}
