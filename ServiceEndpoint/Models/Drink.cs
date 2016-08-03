using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceEndpoint.Models
{
    public class Drink
    {
        public int DrinkId { get; set; }
        public string DrinkName { get; set; }
        public int Quantity { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
