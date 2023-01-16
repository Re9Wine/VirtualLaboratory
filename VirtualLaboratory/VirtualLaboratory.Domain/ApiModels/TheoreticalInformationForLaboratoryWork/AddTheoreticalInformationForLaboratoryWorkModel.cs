using System.ComponentModel.DataAnnotations;

namespace VirtualLaboratory.Domain.ApiModels.TheoreticalInformationForLaboratoryWork
{
    public class AddTheoreticalInformationForLaboratoryWorkModel
    {
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Название лабораторной работы")]
        public int IdLaboratoryWork { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Теоретическая информация")]
        public int IdTheoreticalInformation { get; set; }

        public Entity.TheoreticalInformationForLaboratoryWork ToTheoreticalInformationForLaboratoryWork()
        {
            return new Entity.TheoreticalInformationForLaboratoryWork()
            {
                IdLaboratoryWork = this.IdLaboratoryWork,
                IdTheoreticalInformation = this.IdTheoreticalInformation
            };
        }
    }
}
