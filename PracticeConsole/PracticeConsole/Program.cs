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
            List<Employment> job = new List<Employment>();

            //declared and load Employment instance seperately
            //default constructor
            Employment job1 = new Employment();
            //property set
            job1.Title = "Lab Assistant";
            //the Level property has a private set so you cannot directly assign
            //a value to the Level property
            //Instead use the method provided to the Level property internally
            job1.SetEmployeeResponsibility(SupervisoryLevel.TeamLeader);
            job1.Years = 7.4;

            jobs.Add(job1); //add to the jobs List<T> where T is employmwnt

            //declare and load Employment instance usinf Constructor
            //we can reuse the  Emplymwnt variable job1 beacuse we are creating
            //a new instance of the Employment class
            job1 = new Employment("Research", SupervisoryLevel.TeamMember, 5.8);
            jobs.Add(job1); //add to the jobs List<T> where T is employmwnt

            //decalre and load Employmwnt instance using the object instantiation

            job1 = new Employment()
            {
                Title = "Gander Cooking Club",
                Years = 1.2


            };
            job1.SetEmployeeRespnsibility(SupervisoryLevel.Owner);
            jobs.Add(job1); //add to the jobs List<T> where T is employmwnt

            Person me = new Person()
            {
                FirstName = "Don",
                LastName = "Welch",
                EmploymentPositions = jobs
            };

            //display the contents of Person
            Console.WriteLine("Person:\n");
            Console.WriteLine($"{me.LastName}, {me.FirstName}: \n");
            Console.WriteLine("Past/Present Employment: \n");
            foreach (Employment item in me.EmploymentPositions)
            {
                Console.WriteLine($"\t{item.ToString()}");
            }

        }
    }
}
