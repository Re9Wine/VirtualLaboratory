using VirtualLaboratory.Domain.ApiModels.TheoreticalInformationForLaboratoryWork;
using VirtualLaboratory.Domain.Entity;

namespace VirtualLaboratory.Service.Interfaces
{
    public interface ITheoreticalInformationForLaboratoryWorkService : IBaseService<
        TheoreticalInformationForLaboratoryWork,
        AddTheoreticalInformationForLaboratoryWorkModel,
        UpdateTheoreticalInformationForLaboratoryWorkModel>
    {
    }
}
