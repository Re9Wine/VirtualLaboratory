using System.Collections.Generic;

#nullable disable

namespace VirtualLaboratory.Domain.Entity
{
    public partial class Constant
    {
        public Constant()
        {
            ConstantInLaboratoryWorks = new HashSet<ConstantInLaboratoryWork>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public string Si { get; set; }

        public virtual ICollection<ConstantInLaboratoryWork> ConstantInLaboratoryWorks { get; set; }
    }
}
