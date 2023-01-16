using System.ComponentModel.DataAnnotations;

namespace VirtualLaboratory.Domain.ApiModels.EquipmentParametr
{
    public class AddEquipmentParametrModel
    {
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Название оборудования")]
        public int IdEquipment { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Название параметра")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Значение")]
        public string Value { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Система измерения")]
        public string Si { get; set; }

        public Entity.EquipmentParametr ToEquipmentParametr()
        {
            return new Entity.EquipmentParametr()
            {
                IdEquipment = this.IdEquipment,
                Name = this.Name,
                Value = this.Value,
                Si = this.Si
            };
        }
    }
}
