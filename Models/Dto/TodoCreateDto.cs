using System;
using System.ComponentModel.DataAnnotations;
using TodoApi.Models.Enums;

namespace TodoApi.Models.Dto {
    public class TodoCreateDto {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        [Required]
        public DateTime CreationTime { get; set; }
        public DateTime? DueDate { get;set; }
        public Priority PriorityLevel { get; set; }
    }
}