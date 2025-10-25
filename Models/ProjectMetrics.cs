using System;
using System.Collections.Generic;

namespace RTC.Models
{
    public class ProjectMetrics
    {
        public int ActiveProjects { get; set; }
        public decimal TotalProfit { get; set; }
        public decimal Profitability { get; set; }
        public DateTime Period { get; set; }
        public int TotalProjects { get; set; }
        public int CompletedProjects { get; set; }
        public int InProgressProjects { get; set; }
        public int DelayedProjects { get; set; }
        public decimal TotalBudget { get; set; }
        public decimal TotalActualCost { get; set; }
        public double AverageCompletionRate { get; set; }
        public Dictionary<ProjectPriority, int> ProjectsByPriority { get; set; } = new();
        public Dictionary<ProjectStatus, int> ProjectsByStatus { get; set; } = new();
        
        public decimal CompletionRate => TotalProjects > 0 ? 
            (decimal)CompletedProjects / TotalProjects * 100 : 0;
            
        public decimal BudgetUtilization => TotalBudget > 0 ? 
            TotalActualCost / TotalBudget * 100 : 0;
    }
}