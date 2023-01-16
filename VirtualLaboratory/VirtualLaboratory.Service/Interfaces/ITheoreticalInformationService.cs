using VirtualLaboratory.Domain.ApiModels.TheoreticalInformation;
using VirtualLaboratory.Domain.Entity;

namespace VirtualLaboratory.Service.Interfaces
{
    public interface ITheoreticalInformationService : IBaseService<
        TheoreticalInformation,
        AddTheoreticalInformationModel,
        UpdateTheoreticalInformationModel
        >
    {
    }
}
