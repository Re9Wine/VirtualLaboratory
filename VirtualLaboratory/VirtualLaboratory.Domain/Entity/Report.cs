using System.Collections.Generic;

#nullable disable

namespace VirtualLaboratory.Domain.Entity
{
    public partial class Report
    {
        public Report()
        {
            MistakeInReports = new HashSet<MistakeInReport>();
        }

        public int Id { get; set; }
        public int IdLaboratoryWork { get; set; }
        public string Content { get; set; }

        public virtual LaboratoryWork IdLaboratoryWorkNavigation { get; set; }
        public virtual ICollection<MistakeInReport> MistakeInReports { get; set; }
    }
}
