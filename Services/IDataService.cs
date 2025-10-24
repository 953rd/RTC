using System.Collections.Generic;
using System.Threading.Tasks;
using RTC.Models;

namespace RTC.Services
{
    public interface IDataService
    {
        Task<List<Project>> GetProjectsAsync();
        Task<List<Department>> GetDepartmentsAsync();
        Task SaveProjectAsync(Project project);
        Task DeleteProjectAsync(string projectId);
        Task<List<ProjectMetrics>> GetMetricsHistoryAsync(System.DateTime startDate, System.DateTime endDate);
    }
}