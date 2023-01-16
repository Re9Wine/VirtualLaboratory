using System.ComponentModel.DataAnnotations;

namespace VirtualLaboratory.Domain.ApiModels.LaboratoryWork
{
    public class AddLaboratoryWorkModel
    {
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Номер работы")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Название лаборатонной работы")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Тема")]
        public string Objective { get; set; }

        public Entity.LaboratoryWork ToLaboratoryWork()
        {
            return new Entity.LaboratoryWork()
            {
                Number = this.Number,
                Name = this.Name,
                Objective = this.Objective
            };
        }
    }
}
