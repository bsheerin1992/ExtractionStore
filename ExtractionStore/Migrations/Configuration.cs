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
            for (int i = 0; i < 100; i++)
            {
                context.Files.AddOrUpdate(r => r.Name,
                    new File { Name = i.ToString(), Type = "file", Data = (i * 83).ToString() });
            }
        }
    }
}
