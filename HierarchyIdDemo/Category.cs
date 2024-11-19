using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchyIdDemo
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public HierarchyId Path { get; set; }
    }
}
