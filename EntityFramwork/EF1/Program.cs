using EF1.Models;
using Microsoft.EntityFrameworkCore;

namespace EF1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //await Insert(new Product { Name = "nong", Provider = "123" });

            //var products = new Product[] { new Product { Name = "NCC", Provider = "HN2" },
            //    new Product { Name = "Long", Provider = "ND" } };
            //await Insert(products);

            Show(null);

        }

        public static async Task CreateDatabase()
        {
            using (var dbcontext = new ProductDBContext())
            {
                bool result = await dbcontext.Database.EnsureCreatedAsync();
                if (result) { await Console.Out.WriteLineAsync("created"); }
            }
        }

        public static async Task DeleteDatabase()
        {
            using (var dbcontext = new ProductDBContext())
            {
                bool result = await dbcontext.Database.EnsureDeletedAsync();
                if (result)
                {
                    await Console.Out.WriteLineAsync("deleted");
                }
            }
        }

        public static async Task Insert(Product product)
        {
            using (var dbcontext = new ProductDBContext())
            {
                await dbcontext.Products.AddAsync(product);
                int rows = await dbcontext.SaveChangesAsync();
                await Console.Out.WriteLineAsync("Save Change :" + rows);
            }
        }


        public static async Task Insert(IEnumerable<Product> products)
        {
            using (var dbcontext = new ProductDBContext())
            {
                await dbcontext.Products.AddRangeAsync(products);
                int rows = await dbcontext.SaveChangesAsync();
                await Console.Out.WriteLineAsync("Save Change :" + rows);
            }
        }

        public static void Show(Func<Product,bool>? ok)
        {
            using (var dbcontext = new ProductDBContext())
            {
                var products = ok != null ? dbcontext.Products.Where(ok) : dbcontext.Products;

                foreach (var product in products)
                {
                    Console.WriteLine(product);
                }
            }
        }

        public static void Update(Product product)
        {
            using (var dbcontext = new ProductDBContext())
            {
                var item = dbcontext.Products.Where(p => p.ProductId == product.ProductId).FirstOrDefault();    
                dbcontext.Products.Update(item);
            }
        }

        public static void Delete(Product product)
        {
            using (var dbcontext = new ProductDBContext())
            {
                var item = dbcontext.Products.Where(p => p.ProductId == product.ProductId).FirstOrDefault();
                dbcontext.Products.Remove(item);
                dbcontext.SaveChanges();
            }
        }



    }
}
