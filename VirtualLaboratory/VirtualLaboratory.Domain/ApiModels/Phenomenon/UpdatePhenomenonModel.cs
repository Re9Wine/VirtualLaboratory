using System.ComponentModel.DataAnnotations;

namespace VirtualLaboratory.Domain.ApiModels.Phenomenon
{
    public class UpdatePhenomenonModel
    {
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Название явления")]
        public string Name { get; set; }

        public Entity.Phenomenon ToPhenomenon(int id)
        {
            return new Entity.Phenomenon()
            {
                Id = id,
                Name = this.Name
            };
        }
    }
}
