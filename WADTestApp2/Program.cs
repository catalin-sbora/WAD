using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WADTestApp2.Model;

namespace WADTestApp2
{
    public class Program
    {
        private static void InitializeData(ApplicationDbContext dbContext)
        {
            Category testCategory = new Category { Name = "FirstCategory", Description = "This is the description for the first Category" };
            Category secondCategory = new Category { Name = "SecondCategory", Description = "This is the description for the first Category" };
            Product firstProduct = new Product { Name = "First Product", Description = "First Product Description", Price = new Decimal(12.5), Category = testCategory };
            Product secondProduct = new Product { Name = "Second Product", Description = "Second Product Description", Price = new Decimal(20.5), Category = testCategory };
            Product thirdProduct = new Product { Name = "Third Product", Description = "Third Product Description", Price = new Decimal(19.5), Category = secondCategory };
            if (dbContext.Products.Where(product => product.Name.Equals(firstProduct.Name)).FirstOrDefault() == null)
            {
                dbContext.Add(firstProduct);
                dbContext.Add(secondProduct);
                dbContext.Add(thirdProduct);
                dbContext.SaveChanges();
            }

        }
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            using (var provider = host.Services.CreateScope())
            {
                var dbContext = provider.ServiceProvider.GetService<ApplicationDbContext>();
                InitializeData(dbContext);
            }
                host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
