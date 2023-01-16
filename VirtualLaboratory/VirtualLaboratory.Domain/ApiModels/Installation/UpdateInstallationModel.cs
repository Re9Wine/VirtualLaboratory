using System.ComponentModel.DataAnnotations;

namespace VirtualLaboratory.Domain.ApiModels.Installation
{
    public class UpdateInstallationModel
    {
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Название лабораторной работы")]
        public int IdLaboratoryWork { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Название установки")]
        public string Name { get; set; }

        public Entity.Installation ToInstallation(int id)
        {
            return new Entity.Installation()
            {
                Id = id,
                IdLaboratoryWork = this.IdLaboratoryWork,
                Name = this.Name
            };
        }
    }
}
