using VirtualLaboratory.Domain.ApiModels.Report;
using VirtualLaboratory.Domain.Entity;

namespace VirtualLaboratory.Service.Interfaces
{
    public interface IReportService : IBaseService<
        Report,
        AddReportModel,
        UpdateReportModel
        >
    {
    }
}
