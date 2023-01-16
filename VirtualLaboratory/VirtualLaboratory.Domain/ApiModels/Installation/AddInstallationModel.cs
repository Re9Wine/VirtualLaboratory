using System.ComponentModel.DataAnnotations;

namespace VirtualLaboratory.Domain.ApiModels.Installation
{
    public class AddInstallationModel
    {
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Название лабораторной работы")]
        public int IdLaboratoryWork { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Название установки")]
        public string Name { get; set; }

        public Entity.Installation ToInstallation()
        {
            return new Entity.Installation()
            {
                IdLaboratoryWork = this.IdLaboratoryWork,
                Name = this.Name
            };
        }
    }
}
