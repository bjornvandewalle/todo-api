
using System;
using TodoApi.Models.Enums;

namespace TodoApi.Models.Dto {
    public class TodoReadDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? DueDate { get;set; }
        public DateTime? finishedOn { get; set; }
        public bool finished { get; set; }
        public Priority PriorityLevel { get; set; }
    }
}