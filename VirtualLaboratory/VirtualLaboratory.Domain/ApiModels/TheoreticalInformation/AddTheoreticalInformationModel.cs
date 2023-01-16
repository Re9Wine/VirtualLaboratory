using System.ComponentModel.DataAnnotations;

namespace VirtualLaboratory.Domain.ApiModels.TheoreticalInformation
{
    public class AddTheoreticalInformationModel
    {
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Выберите методичку")]
        public string PhysicalDirectory { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Выберите глоссарий")]
        public string Glossary { get; set; }

        public Entity.TheoreticalInformation ToTheoreticalInformation()
        {
            return new Entity.TheoreticalInformation()
            {
                PhysicalDirectory = this.PhysicalDirectory,
                Glossary = this.Glossary
            };
        }
    }
}
