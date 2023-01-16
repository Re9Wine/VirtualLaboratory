using System.Collections.Generic;

#nullable disable

namespace VirtualLaboratory.Domain.Entity
{
    public partial class TheoreticalInformation
    {
        public TheoreticalInformation()
        {
            TheoreticalInformationForLaboratoryWorks = new HashSet<TheoreticalInformationForLaboratoryWork>();
        }

        public int Id { get; set; }
        public string PhysicalDirectory { get; set; }
        public string Glossary { get; set; }

        public virtual ICollection<TheoreticalInformationForLaboratoryWork> TheoreticalInformationForLaboratoryWorks { get; set; }
    }
}
