namespace ExtractionStore.Migrations
{
    using Microsoft.AspNet.Identity;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ExtractionStore.Models.ExtractionStoreDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ExtractionStore.Models.ExtractionStoreDb";
        }

        protected override void Seed(ExtractionStore.Models.ExtractionStoreDb context)
        {

        }
    }
}