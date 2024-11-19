using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawSqlQueriesDemo
{
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal Amount { get; set; }
    }

    public class UnmappedType
    {
        public string InvoiceNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
