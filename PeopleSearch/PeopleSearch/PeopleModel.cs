using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PeopleSearch
{
    public class PeopleModel
    {

        public PeopleModel()
        {
        }
        //displaying at least name, address, age, interests, and a picture
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public int age { get; set; }
        public string interests { get; set; }
        public string imagePath { get; set; }
    }

    public class PeopleContext : DbContext
    {



        public PeopleContext() : base ("PeopleDB")
        {
            this.Database.CreateIfNotExists();
        }

        public DbSet<PeopleModel> People { get;set; }

    }



}
