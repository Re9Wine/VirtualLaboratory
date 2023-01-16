#nullable disable

namespace VirtualLaboratory.Domain.Entity
{
    public partial class PhenomenonInLaboratoryWork
    {
        public int Id { get; set; }
        public int IdLaboratoryWork { get; set; }
        public int IdPhenomenon { get; set; }

        public virtual LaboratoryWork IdLaboratoryWorkNavigation { get; set; }
        public virtual Phenomenon IdPhenomenonNavigation { get; set; }
    }
}
