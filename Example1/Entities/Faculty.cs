using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example1.Entities
{
    public class Faculty
    {
        public int Id { set; get; }
        public string? Name { set; get; }
        public string? Code { set; get; }
        public int InstitutionId { set; get; }
    }
}