using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimitiveCollectionsDemo
{
    public class Order
    {
        public int Id { get; set; }
        public required string CustomerName { get; set; }
        public List<int> ProductIds { get; set; } = [];
    }
}
