using System.ComponentModel.DataAnnotations;

namespace VirtualLaboratory.Domain.ApiModels.Process
{
    public class UpdateProcessModel
    {
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Название процесса")]
        public string Name { get; set; }

        public Entity.Process ToProcess(int id)
        {
            return new Entity.Process()
            {
                Id = id,
                Name = this.Name
            };
        }
    }
}
