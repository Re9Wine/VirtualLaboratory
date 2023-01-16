#nullable disable

namespace VirtualLaboratory.Domain.Entity
{
    public partial class ConstantInLaboratoryWork
    {
        public int Id { get; set; }
        public int IdConstant { get; set; }
        public int IdLaboratoryWork { get; set; }

        public virtual Constant IdConstantNavigation { get; set; }
        public virtual LaboratoryWork IdLaboratoryWorkNavigation { get; set; }
    }
}
