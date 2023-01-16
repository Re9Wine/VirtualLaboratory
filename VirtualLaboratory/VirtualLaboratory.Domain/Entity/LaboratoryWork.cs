using System.Collections.Generic;

#nullable disable

namespace VirtualLaboratory.Domain.Entity
{
    public partial class LaboratoryWork
    {
        public LaboratoryWork()
        {
            ConstantInLaboratoryWorks = new HashSet<ConstantInLaboratoryWork>();
            Installations = new HashSet<Installation>();
            PhenomenonInLaboratoryWorks = new HashSet<PhenomenonInLaboratoryWork>();
            Reports = new HashSet<Report>();
            TheoreticalInformationForLaboratoryWorks = new HashSet<TheoreticalInformationForLaboratoryWork>();
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Objective { get; set; }

        public virtual ICollection<ConstantInLaboratoryWork> ConstantInLaboratoryWorks { get; set; }
        public virtual ICollection<Installation> Installations { get; set; }
        public virtual ICollection<PhenomenonInLaboratoryWork> PhenomenonInLaboratoryWorks { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<TheoreticalInformationForLaboratoryWork> TheoreticalInformationForLaboratoryWorks { get; set; }
    }
}
