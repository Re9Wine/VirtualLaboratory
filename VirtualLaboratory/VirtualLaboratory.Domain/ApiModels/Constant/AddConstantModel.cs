using System.ComponentModel.DataAnnotations;

namespace VirtualLaboratory.Domain.ApiModels.Constant
{
    public class AddConstantModel
    {
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Название постоянной")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Значение")]
        public double Value { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Система измерения")]
        public string Si { get; set; }

        public Entity.Constant ToConstant()
        {
            return new Entity.Constant()
            {
                Name = this.Name,
                Value = this.Value,
                Si = this.Si
            };
        }
    }
}
