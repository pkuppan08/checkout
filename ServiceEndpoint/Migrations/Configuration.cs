namespace ServiceEndpoint.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ServiceEndpoint.Models.ServiceEndpointContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ServiceEndpoint.Models.ServiceEndpointContext context)
        {

            context.Drinks.AddOrUpdate(x => x.DrinkId,
        new Drink() { DrinkId = 1, DrinkName = "Pepsi", Quantity = 1 },
        new Drink() { DrinkId = 2, DrinkName = "Coca Cola", Quantity = 2 },
        new Drink() { DrinkId = 3, DrinkName = "Fanta", Quantity = 3 }
        );
        }
    }
}
