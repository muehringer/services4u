using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Domain.Entities
{
    public class Sample : Base
    {
        public int SampleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
