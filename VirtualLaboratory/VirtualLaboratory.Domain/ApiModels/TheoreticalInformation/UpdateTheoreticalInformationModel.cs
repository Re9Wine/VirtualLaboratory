using System.ComponentModel.DataAnnotations;

namespace VirtualLaboratory.Domain.ApiModels.TheoreticalInformation
{
    public class UpdateTheoreticalInformationModel
    {
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Выберите методичку")]
        public string PhysicalDirectory { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Выберите глоссарий")]
        public string Glossary { get; set; }

        public Entity.TheoreticalInformation ToTheoreticalInformation(int id)
        {
            return new Entity.TheoreticalInformation()
            {
                Id = id,
                PhysicalDirectory = this.PhysicalDirectory,
                Glossary = this.Glossary
            };
        }
    }
}
