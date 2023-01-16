using System.Collections.Generic;

#nullable disable

namespace VirtualLaboratory.Domain.Entity
{
    public partial class Installation
    {
        public Installation()
        {
            Equipment = new HashSet<Equipment>();
        }

        public int Id { get; set; }
        public int IdLaboratoryWork { get; set; }
        public string Name { get; set; }

        public virtual LaboratoryWork IdLaboratoryWorkNavigation { get; set; }
        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
