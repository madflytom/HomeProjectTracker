using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeProjectApi.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ActualStartDate { get; set; }
        public int ActualDuration { get; set; }
        public DateTime EstimatedStartDate { get; set; }
        public int EstimatedDuration { get; set; }

        //TODO: Set up repository to handle calculation of these things
        [NotMapped]
        public double ActualTotalCost { get; set; }
        [NotMapped]
        public DateTime ActualEndDate { get; set; }
        [NotMapped]
        public double EstimatedTotalCost { get; set; }
        [NotMapped]
        public DateTime EstimatedEndDate { get; set; }

    }
}