using System;
using System.Collections.Generic;
using PracticeConsole.Data;
using System.IO;    //File IO
//using static System.Console; //fully qualified namespace

namespace PracticeConsole
{
    class Program
    {
        private const string ArrayFileName = "IntData.dat";
        private const string CSVFileName = "EmploymentData.dat";
        static void Main(string[] args)
        {

            ArrayReview();
            int[] inputArray = ReadArrayFile();
            PrintArray(inputArray, inputArray.Length, "File IO input array");
            CreateEmploymentData();
            ReadCSVFile();
        }
                
            
            public static int[] ReadArrayFile()
            {
                //read all the record lines from the input file
                // each line is treated like a string
                //tje return data tpe of RealAllLines(filename) is an 
                //array of stings
                string[] fileinput = File.ReadAllLines(ArrayFileName);

                //create an int array of a specific size
                //create the array with the number of lines read size
                //the array property .Length will indicate the number of lines read
                int[] myArray = new int[fileinput.Length];

                //move string data into array

                for (int i = 0; i < fileinput.Length; i++)
                {
                    //assumption is data in file is vaild
                    //int is astruct of system.int32
                    //.Parse is a method within the struct
                    //calling struct methods requires structname.methodname
                    myArray[i] = int.Parse(fileinput[i]);
                    
                    
                }
                return myArray;
            }

            public static void ReadCSVFile()
            {
                string[] fileinput = File.ReadAllLines(CSVFileName);
                List<Employment> employments = new List<Employment>();
                Employment anEmployment = null;
                foreach (string item in fileinput)
                {
                    //PArse the record line into teh serperate values of an 
                    //Employment instance
                    //using the same concept of int.Parse, let us create
                    //a .Parse for our developer defined data type
                    //input will be a string
                    //output will be an instance of employment
                    //because we are using classname.method the methog will
                    //be a static method within the specific classname

                    //employments.Add(Employment.Parse(item));

                    anEmployment = Employment.Parse(item);
                    employments.Add(anEmployment);
                }

                Console.WriteLine($"Lines read: {employments.Count}");
                foreach(var line in employments)
                {
                    Console.WriteLine($"{line.ToString()}");
                }
               
            }

            private static void CreateEmploymentData()
            {
                List<Employment> employments = new List<Employment>();
                employments.Add(new Employment("Instructor", SupervisoryLevel.TeamLeader, 35.5));
                employments.Add(new Employment("System Developer", SupervisoryLevel.TeamMember, 7.65));
                employments.Add(new Employment("LAb Tech", SupervisoryLevel.TeamLeader, 3.5));
                employments.Add(new Employment("Student Advisor", SupervisoryLevel.TeamLeader, 3.5));

                List<string> csvlines = new List<string>();
                foreach(var item in employments)
                {
                    csvlines.Add(item.ToString());

                }
                //write out all the csv lines
                File.WriteAllLines(CSVFileName, csvlines);

            }

        




        public static void ArrayReview()
        {
            //Declare a single-dimensional array size 5
            int lsArray1 = 0;
            int lsArray2 = 0;

            int lsArray3 = 0;

            int[] array1 = new int[5];
            PrintArray(array1, 5, "declare int array size 5");
            lsArray1 = 0;

            //Declare and set array elements
            int[] array2 = new int[] { 1, 2, 3, 4, 5 };
            PrintArray(array2, 5, "declare and set int array size 5");
            lsArray2 = 5;

            //alternate syntax
            int[] array3 = { 1, 2, 3, 4, 5 };
            PrintArray(array3, 5, "alternative declare and set int array size 5");
            lsArray3 = 5;

            //add an value to array1
            //compare physical size to logical size, is there room
            if (array1.Length > lsArray1)
            {
                Random rnd = new Random();
                int position = rnd.Next(0, 5);
                array1[position] = 15;
                lsArray1++;
            }
            PrintArray(array1, 5, "declare int array size 5");

            //remove element 3 from array2
            //determine the logic size
            //index of the element to remove
            array2[2] = array2[lsArray2 - 1];
            lsArray2--;
            PrintArray(array2, 5, "declare and set int array size 5");

            string filerecord = "don, 1986, edmonton, ab";
            string[] values = filerecord.Split(',');
            int i = 1;
            Console.WriteLine($"Number of values is {values.Length}");
            foreach (var item in values)
            {
                Console.WriteLine($"item {i} is {item}");
                i++;
            }

        }

        public static void PrintArray(int[] array, int logicalsize, string comment)
        {
            Console.WriteLine($"{comment}\n");
            for (int i = 0; i < logicalsize; i++)
            {
                Console.Write($"{array[i]}, ");
            }
            Console.WriteLine("\n");
        }
        public static void ClassObjectReview()
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
            Console.WriteLine($"\n\n*****\nEmployment ReadOnly\n\t{altJob.Title},{altJob.Level},{altJob.Years}\n*****\n");

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
