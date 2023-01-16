namespace VirtualLaboratory.Domain.ApiModels.ConstantInLaboratoryWork
{
    public class UpdateConstantInLaboratoryWorkModel
    {
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Постоянная")]
        public int IdConstant { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Лабораторная работа")]
        public int IdLaboratoryWork { get; set; }

        public Entity.ConstantInLaboratoryWork ToConstantInLaboratoryWork(int id)
        {
            return new Entity.ConstantInLaboratoryWork()
            {
                Id = id,
                IdConstant = this.IdConstant,
                IdLaboratoryWork = this.IdLaboratoryWork
            };
        }
    }
}
