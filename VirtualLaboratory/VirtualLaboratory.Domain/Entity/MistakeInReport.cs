#nullable disable

namespace VirtualLaboratory.Domain.Entity
{
    public partial class MistakeInReport
    {
        public int Id { get; set; }
        public int IdReport { get; set; }
        public string Mistake { get; set; }
        public bool IsFixed { get; set; }

        public virtual Report IdReportNavigation { get; set; }
    }
}
