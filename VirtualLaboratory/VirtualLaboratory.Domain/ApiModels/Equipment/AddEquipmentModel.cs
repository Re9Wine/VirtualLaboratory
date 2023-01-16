using System.ComponentModel.DataAnnotations;

namespace VirtualLaboratory.Domain.ApiModels.Equipment
{
    public class AddEquipmentModel
    {
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Название установки")]
        public int IdInstallation { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Название оборудования")]
        public string Name { get; set; }

        public Entity.Equipment ToEquipment()
        {
            return new Entity.Equipment()
            {
                IdInstallation = this.IdInstallation,
                Name = this.Name
            };
        }
    }
}
