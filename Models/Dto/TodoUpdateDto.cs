using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TodoApi.Models.Enums;

namespace TodoApi.Models.Dto {
    public class TodoUpdateDto {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        public DateTime? DueDate { get;set; }
        public DateTime? finishedOn { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool finished { get; set; }
        public Priority PriorityLevel { get; set; }
    }
}