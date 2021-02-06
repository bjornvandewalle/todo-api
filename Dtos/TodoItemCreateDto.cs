using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Dtos {
    
    public class TodoItemCreateDto {

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        public DateTime EnterdOn { get; set; }

        [Required]
        public bool finished { get; set; }

        [Range(1, 3)]
        public int PriorityLevel { get; set; }
    }
}