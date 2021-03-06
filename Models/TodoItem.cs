using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TodoApi.Models.Enums;

namespace TodoApi.Models {
    
    public class TodoItem {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        [Required]
        public DateTime CreationTime { get; set; }
        public DateTime? DueDate { get;set; }
        public DateTime? finishedOn { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool finished { get; set; }
        public Priority PriorityLevel { get; set; }
    }
}