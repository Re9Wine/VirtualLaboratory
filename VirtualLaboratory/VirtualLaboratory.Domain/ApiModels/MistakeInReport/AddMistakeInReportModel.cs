using System.ComponentModel.DataAnnotations;

namespace VirtualLaboratory.Domain.ApiModels.MistakeInReport
{
    public class AddMistakeInReportModel
    {
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Отчет")]
        public int IdReport { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Ошибка")]
        public string Mistake { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Ошибка исправлена?")]
        public bool IsFixed { get; set; }

        public Entity.MistakeInReport ToMistakeInReport()
        {
            return new Entity.MistakeInReport()
            {
                IdReport = this.IdReport,
                Mistake = this.Mistake,
                IsFixed = this.IsFixed
            };
        }
    }
}
