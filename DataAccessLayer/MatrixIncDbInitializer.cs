using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class MatrixIncDbInitializer
    {
        public static void Initialize(MatrixIncDbContext context)
        {
            if (context.Customers.Any())
            {
                return;
            }
          
            var customers = new Customer[]
            {
                new Customer { Name = "Neo", Address = "123 Elm St" , Active=true},
            };
            context.Customers.AddRange(customers);
            context.SaveChanges();

            var orders = new Order[]
            {
                new Order { Customer = customers[0], OrderDate = DateTime.Parse("2021-01-01")},
            };  
            context.Orders.AddRange(orders);
            context.SaveChanges();

            var products = new Product[]
            {
                new Product { ImageUrl ="/images/Foto_Zeskantmoer.png", Productnummer = 20250001, Productnaam = "Zeskantmoer", Omschrijving = "Standaard moer met zes zijden", Kleur = "Grijs", PrijsPerStuk = 1.50m },
                new Product { ImageUrl ="/images/Foto_TMoer.png", Productnummer = 20240125, Productnaam = "T-moer", Omschrijving = "Past in T-sleuven, geschikt voor onder andere werkbanken of freesmachines.", Kleur = "Zwart", PrijsPerStuk = 1.50m }
            };
            context.Products.AddRange(products);

            context.SaveChanges();

            context.Database.EnsureCreated();
        }
    }
}
