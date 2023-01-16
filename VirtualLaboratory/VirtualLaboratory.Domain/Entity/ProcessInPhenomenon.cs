#nullable disable

namespace VirtualLaboratory.Domain.Entity
{
    public partial class ProcessInPhenomenon
    {
        public int Id { get; set; }
        public int IdPhenomenon { get; set; }
        public int IdProcess { get; set; }

        public virtual Phenomenon IdPhenomenonNavigation { get; set; }
        public virtual Process IdProcessNavigation { get; set; }
    }
}
