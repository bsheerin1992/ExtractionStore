namespace ExtractionStore.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ExtractionStore.Models.ExtractionStoreDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ExtractionStore.Models.ExtractionStoreDb";
        }

        protected override void Seed(ExtractionStore.Models.ExtractionStoreDb context)
        {
            context.Files.AddOrUpdate(f => f.Name,
                new File { Name = "abcd" },
                new File { Name = "efgh" },
                new File { Name = "yz12" });
        }
    }
}
