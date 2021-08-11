using System.ComponentModel.DataAnnotations;

namespace TaskmasterCore.Dtos
{
    public class TaskItemDto
    {
        [MaxLength(511)] public string Text { get; set; }
        [MaxLength(9)]public string Day { get; set; }
        public bool Reminder { get; set; } = false;

    }
}
