using System;

namespace ZoikInfra.Models
{
    public class Item
    {
        public int Id { get; set; }
        public long CustomerId { get; set; }
        public int PropertyId { get; set; }
        public long? AgentId { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsCompleted { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime VisitDate { get; set; }
    }
}