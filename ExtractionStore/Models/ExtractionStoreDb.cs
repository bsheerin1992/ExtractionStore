using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExtractionStore.Models
{
    public class ExtractionStoreDb : DbContext
    {
        public ExtractionStoreDb() : base("name=DefaultConnection")
        {

        }

        public DbSet<File> Files { get; set; }
    }
}