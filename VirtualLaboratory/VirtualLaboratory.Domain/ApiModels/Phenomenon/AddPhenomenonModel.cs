using System.ComponentModel.DataAnnotations;

namespace VirtualLaboratory.Domain.ApiModels.Phenomenon
{
    public class AddPhenomenonModel
    {
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Название явления")]
        public string Name { get; set; }

        public Entity.Phenomenon ToPhenomenon()
        {
            return new Entity.Phenomenon()
            {
                Name = this.Name
            };
        }
    }
}
