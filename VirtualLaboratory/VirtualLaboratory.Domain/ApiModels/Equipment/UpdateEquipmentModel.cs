using System.ComponentModel.DataAnnotations;

namespace VirtualLaboratory.Domain.ApiModels.Equipment
{
    public class UpdateEquipmentModel
    {
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Название установки")]
        public int IdInstallation { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Название оборудования")]
        public string Name { get; set; }

        public Entity.Equipment ToEquipment(int id)
        {
            return new Entity.Equipment()
            {
                Id = id,
                IdInstallation = this.IdInstallation,
                Name = this.Name
            };
        }
    }
}
