using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeConsole.Data
{
    public class Person 
    {
        //each instance of this class will represent an individual
        //This class will defore the following characteristics of a person:
        //FirstName, LastName, list of employment positions

        //This class defintion is an example of class Composition

        private string _FirstName;
        private string _LastName;

        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Persons first name is required");
                }
                else
                {
                    _FirstName = value;
                }
            }
        }

        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Persons last name is required");
                }
                else
                {
                    _LastName = value;
                }
            }
        }
        public ResidentAddress Address;

        //List<Employment> property
        //this is an example of a Composition class property
        //this property makes use of another programmer-decalred data type: Employment
        //one could have many properties within your class definition that uses
        // multiple different programmer-declared class data types
        //this differs from the concept of inheritance where the class defintion is extended to 
        //another class
        //inheritance syntax appears on the class declaritive
        //  example assume a class called Transportation (fuel, motor, fuselage)
        //          assume types of transporation: Vehicle, Bike, Boat ...
        //          public class Vehicle : Transportaion
        //          public class Bike : Transportation
        //          public class Boat : Transporation 
        //In addtion to the unique properties within Vehicle, Bike, Boat  the class definition is
        // extended to also have access to the Transporation class.
        public List<Employment> EmploymentPositions { get; set; }
        public Employment CurrentPosition { get; set; }

        public Person() { }

        public Person(string firstname, string lastname, List<Employment> positions, ResidentAddress Address)
        {
            FirstName = firstname;
            LastName = lastname;
            EmploymentPositions = positions;
            this.Address = Address;
        }
    }
}
