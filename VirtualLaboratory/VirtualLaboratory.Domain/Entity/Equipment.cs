using System.Collections.Generic;

#nullable disable

namespace VirtualLaboratory.Domain.Entity
{
    public partial class Equipment
    {
        public Equipment()
        {
            EquipmentParametrs = new HashSet<EquipmentParametr>();
        }

        public int Id { get; set; }
        public int IdInstallation { get; set; }
        public string Name { get; set; }

        public virtual Installation IdInstallationNavigation { get; set; }
        public virtual ICollection<EquipmentParametr> EquipmentParametrs { get; set; }
    }
}
