using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Task : BaseCLass
    {
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTimeOffset TaskStartTime { get; set; }
        public DateTimeOffset TaskEndTime { get; set; }
        public int TaskAssigned { get; set; }

        public string Status { get; set; } = string.Empty;


    }
}
