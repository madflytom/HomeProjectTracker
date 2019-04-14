using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace HomeProjectApi.Models
{
    public class ProjectItem
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ActualStartDate { get; set; }
        public int ActualDuration { get; set; }
        public DateTime EstimatedStartDate { get; set; }
        public int EstimatedDuration { get; set; }

        public decimal ActualCost { get; set; }
        public DateTime ActualEndDate { get; set; }
        public decimal EstimatedCost { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public bool IsComplete { get; set; }

    }
}