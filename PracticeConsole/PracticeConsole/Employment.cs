using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeConsole.Data;

namespace PracticeConsole.Data
{
   class Employment
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
        private SupervisoryLevel Level;

        //properties
        //these are access techniques to retrieve or set data in your class
        //without directly touching the storage field

        //fully implemented property
        // a) a declared storage area (data field)
        // b) declare the property siganture
        // c) code a get 'method'
        // d) optinally code a set

        Employment(string Title,  double Years);
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
        public SupervisoryLevel Level { get; set; }
        // the property years could be coded as either a fully implemented propert (as shown) or
        //as an auto-implemented property
        public double Years { get; set; }

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
            Title = null;
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
    }
}
