using System;
using Avalonia.Media;

namespace RTC.Models
{
    public class Project
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Department Department { get; set; } = new Department();
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; }
        public decimal Budget { get; set; }
        public decimal ActualCost { get; set; }
        public ProjectStatus Status { get; set; } = ProjectStatus.Planning;
        public ProjectPriority Priority { get; set; } = ProjectPriority.Medium;
        public int CompletionPercentage { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.Now;
        
        public decimal CostVariance => Budget - ActualCost;
        public bool IsOverBudget => ActualCost > Budget;
        public bool IsCompleted => Status == ProjectStatus.Completed;
    }

    public enum ProjectStatus
    {
        Planning,
        InProgress,
        OnHold,
        Completed,
        Cancelled
    }

    public enum ProjectPriority
    {
        Low,
        Medium,
        High,
        Critical
    }
}