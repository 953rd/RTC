using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RTC.Models;

namespace RTC.Services
{
    public class AnalysisService : IAnalysisService
    {
        private readonly IDataService _dataService;

        public AnalysisService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<ProjectMetrics> CalculateCurrentMetricsAsync()
        {
            var projects = await _dataService.GetProjectsAsync();
            
            return new ProjectMetrics
            {
                Period = DateTime.Now,
                TotalProjects = projects.Count,
                CompletedProjects = projects.Count(p => p.IsCompleted),
                InProgressProjects = projects.Count(p => p.Status == ProjectStatus.InProgress),
                DelayedProjects = projects.Count(p => 
                    p.Status == ProjectStatus.InProgress && 
                    p.EndDate.HasValue && 
                    p.EndDate.Value < DateTime.Now),
                TotalBudget = projects.Sum(p => p.Budget),
                TotalActualCost = projects.Sum(p => p.ActualCost),
                AverageCompletionRate = projects.Average(p => p.CompletionPercentage),
                ProjectsByPriority = projects.GroupBy(p => p.Priority)
                    .ToDictionary(g => g.Key, g => g.Count()),
                ProjectsByStatus = projects.GroupBy(p => p.Status)
                    .ToDictionary(g => g.Key, g => g.Count())
            };
        }

        public async Task<List<Project>> GetProjectsByStatusAsync(ProjectStatus status)
        {
            var projects = await _dataService.GetProjectsAsync();
            return projects.Where(p => p.Status == status).ToList();
        }

        public async Task<List<Project>> GetHighPriorityProjectsAsync()
        {
            var projects = await _dataService.GetProjectsAsync();
            return projects.Where(p => p.Priority == ProjectPriority.High || 
                                      p.Priority == ProjectPriority.Critical)
                         .ToList();
        }

        public async Task<Dictionary<string, decimal>> GetDepartmentPerformanceAsync()
{
    var projects = await _dataService.GetProjectsAsync();
    
    return projects.GroupBy(p => p.Department.Name)
        .ToDictionary(
            g => g.Key,
            g => (decimal)g.Average(p => p.CompletionPercentage)
        );
}

        public async Task<List<Project>> FindProjectsAtRiskAsync()
        {
            var projects = await _dataService.GetProjectsAsync();
            
            return projects.Where(p => 
                p.IsOverBudget || 
                (p.EndDate.HasValue && p.EndDate.Value < DateTime.Now.AddDays(14) && 
                 p.CompletionPercentage < 80) ||
                p.CompletionPercentage < 30 && p.StartDate < DateTime.Now.AddMonths(-3)
            ).ToList();
        }
    }
}