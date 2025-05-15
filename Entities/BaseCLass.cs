using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BaseCLass
    {
        public int Id { get; set; }
        public string RecordState { get; set; } = "Active";
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get;set; }

        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
