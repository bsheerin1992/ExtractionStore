using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExtractionStore.Models
{
    public class ExtractionStoreDb : DbContext
    {
        //set my db connection string
        public ExtractionStoreDb() : base("name=DefaultConnection")
        {

        }

        //create db table of Files named Files
        public DbSet<File> Files { get; set; }
    }
}