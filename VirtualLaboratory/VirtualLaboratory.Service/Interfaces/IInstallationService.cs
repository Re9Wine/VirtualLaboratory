using VirtualLaboratory.Domain.ApiModels.Installation;
using VirtualLaboratory.Domain.Entity;

namespace VirtualLaboratory.Service.Interfaces
{
    public interface IInstallationService : IBaseService<
        Installation,
        AddInstallationModel,
        UpdateInstallationModel
        >
    {
    }
}
