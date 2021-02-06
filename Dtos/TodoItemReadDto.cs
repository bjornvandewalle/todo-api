using System;

namespace TodoApi.Dtos {
    
    public class TodoItemReadDto {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime EnterdOn { get; set; }

        public DateTime? Endtime { get; set; }

        public bool finished { get; set; }
    }
}