using System;
using System.Collections.Generic;
using PracticeConsole.Data;
//using static System.Console; //fully qualified namespace

namespace PracticeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employment> jobs = new List<Employment>();

            //declared and load Employment instance seperately
            //default constructor

            Employment job1 = new Employment();

            //property set
            job1.Title = "Lab Assistant";
            //the Level property has a private set so you cannot directly assign
            //a value to the Level property
            //Instead use the method provided which will assign the
            //given arguemnt value to the Level property internally
            job1.SetEmployeeResonsibility(SupervisoryLevel.TeamLeader);
            job1.Years = 7.4;

            jobs.Add(job1); //add to the jobs List<T> where T is employmwnt

            //declare and load Employment instance using Constructor
            //we can reuse the  Emplymwnt variable job1 beacuse we are creating
            //a new instance of the Employment class
            //greedy constructor
            job1 = new Employment("Research", SupervisoryLevel.TeamMember, 5.8);
            jobs.Add(job1); //add to the jobs List<T> where T is employmwnt

            //decalre and load Employment instance using the object instantiation
            //source
            //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-initialize-objects-by-using-an-object-initializer
            //object initalizer
            //declaring an instance using object instantiation does so without
            //explicitly invoking a constructor type.
            //The computer processes object initalizers by first accessing the 
            //parameterless instance constructor and then processing the member
            //initalizations
            //you must use an object initalizer if you are defining an anonymous type
            //
            //this works whether you have explicitly coded constructors in your class
            //defintion or not


            job1 = new Employment
            {
                Title = "Gander Cooking Club",
                Years = 1.2


            };
            job1.SetEmployeeResonsibility(SupervisoryLevel.Owner);
            jobs.Add(job1); //add to the jobs List<T> where T is employmwnt

          
            // struct sample
            //remember structs are value types, not refrence types
            //can initalize via constructor or object initalizer (shown)
            //ResidentAddress address = new ResidentAddress(123, "Maple St.", null, null, "Edmonton", "AB");

            ResidentAddress address = new ResidentAddress
            {
                //Number = 123,  //when field is readonly struct defintion
                Address1 = "Maple St.",
                City = "Edmonton",
                ProvinceState = "AB"
            };

            Person me = new Person()
            {
                FirstName = "Don",
                LastName = "Welch",
                Address = address,
                EmploymentPositions = jobs
            };

            //display the contents of Person
            Console.WriteLine("Person:\n");
            Console.WriteLine($"{me.LastName}, {me.FirstName} \n");
            Console.WriteLine($"{me.Address.Number} {me.Address.Address1} \n" +
                $"{me.Address.City}, {me.Address.ProvinceState}");
            Console.WriteLine("Past/Present Employment: \n");

            foreach (Employment item in me.EmploymentPositions)
            {
                Console.WriteLine($"\t{item.ToString()}");
            }

            
            //using a readonly nonstatic class which can hold data
            //at the time of instantion you must supply all required value data
            //to your new instance
            EmploymentReadOnly altJob = new EmploymentReadOnly("Art Director",
                SupervisoryLevel.Supervisor, 4.5);
            Console.WriteLine($"\n\n*****\nEmployment ReadOnly\n\t{altJob.Title},{altJob.Level},{altJob.Years}\n*****\n")

            Employment badjob;
            Person badperson;

            try
            {
                //badJob = new Employment("testing bads". SupervisoryLevel.TeamMember, 5.8);
                badperson = new Person()
                {
                    FirstName = "don",
                    LastName = "welch"


                };
            }
            catch(Exception ex)
            {
                Console.WriteLine($"************\n{ex.Message}\n******************");
            }

        }
    }
}
