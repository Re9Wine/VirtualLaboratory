using System.ComponentModel.DataAnnotations;

namespace VirtualLaboratory.Domain.ApiModels.LaboratoryWork
{
    public class UpdateLaboratoryWorkModel
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

        public Entity.LaboratoryWork ToLaboratoryWork(int id)
        {
            return new Entity.LaboratoryWork()
            {
                Id = id,
                Number = this.Number,
                Name = this.Name,
                Objective = this.Objective
            };
        }
    }
}
