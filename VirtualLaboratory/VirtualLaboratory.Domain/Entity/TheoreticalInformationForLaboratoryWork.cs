#nullable disable

namespace VirtualLaboratory.Domain.Entity
{
    public partial class TheoreticalInformationForLaboratoryWork
    {
        public int Id { get; set; }
        public int IdLaboratoryWork { get; set; }
        public int IdTheoreticalInformation { get; set; }

        public virtual LaboratoryWork IdLaboratoryWorkNavigation { get; set; }
        public virtual TheoreticalInformation IdTheoreticalInformationNavigation { get; set; }
    }
}
