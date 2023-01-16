using VirtualLaboratory.Domain.ApiModels.MistakeInReport;
using VirtualLaboratory.Domain.Entity;

namespace VirtualLaboratory.Service.Interfaces
{
    public interface IMistakeInReportService : IBaseService<
        MistakeInReport,
        AddMistakeInReportModel,
        UpdateMistakeInReportModel
        >
    {
    }
}
