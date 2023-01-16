using System.ComponentModel.DataAnnotations;

namespace VirtualLaboratory.Domain.ApiModels.PhenomenonInLaboratoryWork
{
    public class UpdatePhenomenonInLaboratoryWorkModel
    {
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Название лабораторной работы")]
        public int IdLaboratoryWork { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Название явления")]
        public int IdPhenomenon { get; set; }

        public Entity.PhenomenonInLaboratoryWork ToPhenomenonInLaboratoryWork(int id)
        {
            return new Entity.PhenomenonInLaboratoryWork()
            {
                Id = id,
                IdLaboratoryWork = this.IdLaboratoryWork,
                IdPhenomenon = this.IdPhenomenon
            };
        }
    }
}
