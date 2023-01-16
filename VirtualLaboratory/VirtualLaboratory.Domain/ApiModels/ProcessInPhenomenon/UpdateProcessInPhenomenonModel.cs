using System.ComponentModel.DataAnnotations;

namespace VirtualLaboratory.Domain.ApiModels.ProcessInPhenomenon
{
    public class UpdateProcessInPhenomenonModel
    {
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Название явления")]
        public int IdPhenomenon { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Название процесса")]
        public int IdProcess { get; set; }

        public Entity.ProcessInPhenomenon ToProcessInPhenomenon(int id)
        {
            return new Entity.ProcessInPhenomenon()
            {
                Id = id,
                IdPhenomenon = this.IdPhenomenon,
                IdProcess = this.IdProcess
            };
        }
    }
}
