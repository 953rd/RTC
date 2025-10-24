using System.Collections.Generic;
using System.Threading.Tasks;
using RTC.Models;

namespace RTC.Services
{
    public interface IAnalysisService
    {
        Task<ProjectMetrics> CalculateCurrentMetricsAsync();
        Task<List<Project>> GetProjectsByStatusAsync(ProjectStatus status);
        Task<List<Project>> GetHighPriorityProjectsAsync();
        Task<Dictionary<string, decimal>> GetDepartmentPerformanceAsync();
        Task<List<Project>> FindProjectsAtRiskAsync();
    }
}