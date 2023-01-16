using System.ComponentModel.DataAnnotations;

namespace VirtualLaboratory.Domain.ApiModels.TheoreticalInformationForLaboratoryWork
{
    public class UpdateTheoreticalInformationForLaboratoryWorkModel
    {
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Название лабораторной работы")]
        public int IdLaboratoryWork { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Теоретическая информация")]
        public int IdTheoreticalInformation { get; set; }

        public Entity.TheoreticalInformationForLaboratoryWork ToTheoreticalInformationForLaboratoryWork(int id)
        {
            return new Entity.TheoreticalInformationForLaboratoryWork()
            {
                Id = id,
                IdLaboratoryWork = this.IdLaboratoryWork,
                IdTheoreticalInformation = this.IdTheoreticalInformation
            };
        }
    }
}
