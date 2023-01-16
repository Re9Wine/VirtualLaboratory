#nullable disable

namespace VirtualLaboratory.Domain.Entity
{
    public partial class EquipmentParametr
    {
        public int Id { get; set; }
        public int IdEquipment { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Si { get; set; }

        public virtual Equipment IdEquipmentNavigation { get; set; }
    }
}
