namespace practical11.Models
{
    public static class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            context.Database.Migrate();
            if (context?.Products.Count() == 0 && context?.Suppliers.Count() == 0 && context?.Categories.Count() == 0)
            {
                Supplier s1 = new() { Name = "Splash Dudes", City = "San Jose" };
                Supplier s2 = new() { Name = "Soccer Town", City = "Chicago" };
                Supplier s3 = new() { Name = "Chess Co", City = "New York" };

                Category c1 = new() { Name = "Watersports" };
                Category c2 = new() { Name = "Soccer" };
                Category c3 = new() { Name = "Chess" };

                context.Products.AddRange(
                    new()
                    {
                        Name = "Kayak",
                        Price = 275,
                        Category = c1,
                        Supplier = s1
                    },
                    new()
                    {
                        Name = "Lifejacket",
                        Price = 48.95m,
                        Category = c1,
                        Supplier = s1
                    },
                    new()
                    {
                        Name = "Soccer Ball",
                        Price = 19.50m,
                        Category = c2,
                        Supplier = s2
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
