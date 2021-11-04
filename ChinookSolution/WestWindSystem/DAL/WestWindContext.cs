using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.EntityFrameworkCore;
using WestWindSystem.Entities;
#endregion

namespace WestWindSystem.DAL
{
    internal class WestWindContext:DbContext

    {
        public WestWindContext()
        {

        }
        //options? thingslike DataBase Provider(MySQL | Oracle)
        //What is the connection string?
        //what type of authorization
        //that is the name of the database
        //this dependancy injection is to help us externalize our reliance on objects
        //  that are out of scop
        //example wheels on a car are attached by bolts so they can be changed as needed
        //          (software updates)
        //consider if the wheels were welded to your avils. how difficult woul dit be
        //to cjange the tires        (update software)
        //the options have the necessary values to context our system to the software
        // in teh EntityFRamework which is responsible for the actual transfer
        //of data from sql to the program and back

        public WestWindContext(DbContextOptions<WestWindContext> options) : base(options)
        {

        }

        public DbSet<Region> Regions { get; set; }

        public DbSet<BuildVersion> BuildVersions { get; set; }
    }

   
}
