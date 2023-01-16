using System.Collections.Generic;

#nullable disable

namespace VirtualLaboratory.Domain.Entity
{
    public partial class Process
    {
        public Process()
        {
            ProcessInPhenomena = new HashSet<ProcessInPhenomenon>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProcessInPhenomenon> ProcessInPhenomena { get; set; }
    }
}
