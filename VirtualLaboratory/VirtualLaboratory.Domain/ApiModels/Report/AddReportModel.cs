using System.ComponentModel.DataAnnotations;

namespace VirtualLaboratory.Domain.ApiModels.Report
{
    public class AddReportModel
    {
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Название лабораторной работы")]
        public int IdLaboratoryWork { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Выберите файл с отчетом")]
        public string Content { get; set; }

        public Entity.Report ToReport()
        {
            return new Entity.Report()
            {
                IdLaboratoryWork = this.IdLaboratoryWork,
                Content = this.Content
            };
        }
    }
}
