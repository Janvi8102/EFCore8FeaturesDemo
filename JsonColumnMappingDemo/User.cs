using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonColumnMappingDemo
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserAttributes Attributes { get; set; } 
    }

    public class UserAttributes
    {
        public string Designation { get; set; }
        public List<string> Skills { get; set; }
    }
}
