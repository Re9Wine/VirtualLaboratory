using System.ComponentModel.DataAnnotations;

namespace VirtualLaboratory.Domain.ApiModels.Process
{
    public class AddProcessModel
    {
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Название процесса")]
        public string Name { get; set; }

        public Entity.Process ToProcess()
        {
            return new Entity.Process()
            {
                Name = this.Name
            };
        }
    }
}
