using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Product
    {
        public string ImageUrl { get; set; }

        [Key]
        public int Productnummer { get; set; }

        public string Productnaam { get; set; }

        public string Omschrijving {  get; set; }

        public string Kleur {  get; set; }

        public int Voorraad {  get; set; }

        public decimal PrijsPerStuk { get; set; }

        public ICollection<Order> Orders { get; } = new List<Order>();
    }
}
