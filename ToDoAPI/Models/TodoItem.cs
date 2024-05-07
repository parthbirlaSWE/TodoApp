namespace ToDoAPI.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;         //Default CreateDate to UTC Time now
    }
}
