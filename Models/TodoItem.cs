using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models {
    
    public class TodoItem {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        public DateTime EnterdOn { get; set; }

        public DateTime? Endtime { get; set; }

        [Required]
        public bool finished { get; set; }

        [Range(1, 3)]
        public int PriorityLevel { get; set; }
    }
}