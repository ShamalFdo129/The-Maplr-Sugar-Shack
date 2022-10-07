using SugarShack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShack.Domain.Entities
{
    public class Product:BaseEntity
    {
        public string? Name { get; set; }
        public double Price { get; set; }
        public Catalogue Type { get; set; }
    }
}
