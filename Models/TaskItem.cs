using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0113.Models
{
    public class TaskItem
    {
        public int TaskItemId { get; set; }

        [Required]
        public string TaskName { get; set; } = string.Empty;

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public int Quadrant { get; set; } // 1, 2, 3, or 4

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public bool Completed { get; set; } = false;
    }
}
