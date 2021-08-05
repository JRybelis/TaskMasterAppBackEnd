namespace TaskmasterCore.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Day { get; set; }
        public bool Reminder { get; set; } = false;
    }
}
