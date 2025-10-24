using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RTC.Models;

namespace RTC.Services
{
    public class DataService : IDataService
    {
        private readonly List<Project> _projects = new();
        private readonly List<Department> _departments = new();

        public DataService()
        {
            InitializeSampleData();
        }

        private void InitializeSampleData()
        {
            _departments.AddRange(new[]
            {
                new Department { Id = "1", Name = "Разработка", Manager = "Иван Петров", TeamSize = 15 },
                new Department { Id = "2", Name = "Маркетинг", Manager = "Мария Сидорова", TeamSize = 8 },
                new Department { Id = "3", Name = "Продажи", Manager = "Алексей Козлов", TeamSize = 12 }
            });

            var random = new Random();
            for (int i = 1; i <= 20; i++)
            {
                _projects.Add(new Project
                {
                    Name = $"Проект {i}",
                    Description = $"Описание проекта {i}",
                    Department = _departments[random.Next(_departments.Count)],
                    StartDate = DateTime.Now.AddDays(-random.Next(100)),
                    Budget = random.Next(50000, 500000),
                    ActualCost = random.Next(45000, 550000),
                    Status = (ProjectStatus)random.Next(4),
                    Priority = (ProjectPriority)random.Next(4),
                    CompletionPercentage = random.Next(0, 101)
                });
            }
        }

        public Task<List<Project>> GetProjectsAsync()
        {
            return Task.FromResult(_projects);
        }

        public Task<List<Department>> GetDepartmentsAsync()
        {
            return Task.FromResult(_departments);
        }

        public Task SaveProjectAsync(Project project)
        {
            if (string.IsNullOrEmpty(project.Id))
            {
                project.Id = Guid.NewGuid().ToString();
                _projects.Add(project);
            }
            else
            {
                var existing = _projects.FirstOrDefault(p => p.Id == project.Id);
                if (existing != null)
                {
                    _projects.Remove(existing);
                    _projects.Add(project);
                }
            }
            
            project.LastUpdated = DateTime.Now;
            return Task.CompletedTask;
        }

        public Task DeleteProjectAsync(string projectId)
        {
            var project = _projects.FirstOrDefault(p => p.Id == projectId);
            if (project != null)
            {
                _projects.Remove(project);
            }
            return Task.CompletedTask;
        }

        public Task<List<ProjectMetrics>> GetMetricsHistoryAsync(DateTime startDate, DateTime endDate)
        {
            var metrics = new List<ProjectMetrics>();
            var currentDate = startDate;
            
            while (currentDate <= endDate)
            {
                var periodProjects = _projects.Where(p => p.StartDate.Date <= currentDate.Date).ToList();
                
                metrics.Add(new ProjectMetrics
                {
                    Period = currentDate,
                    TotalProjects = periodProjects.Count,
                    CompletedProjects = periodProjects.Count(p => p.IsCompleted),
                    InProgressProjects = periodProjects.Count(p => p.Status == ProjectStatus.InProgress),
                    DelayedProjects = periodProjects.Count(p => 
                        p.Status == ProjectStatus.InProgress && 
                        p.EndDate.HasValue && 
                        p.EndDate.Value < DateTime.Now),
                    TotalBudget = periodProjects.Sum(p => p.Budget),
                    TotalActualCost = periodProjects.Sum(p => p.ActualCost),
                    AverageCompletionRate = periodProjects.Average(p => p.CompletionPercentage)
                });
                
                currentDate = currentDate.AddDays(7);
            }
            
            return Task.FromResult(metrics);
        }
    }
}