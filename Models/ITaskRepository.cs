namespace Mission08_Team0113.Models
{
    public interface ITaskRepository
    {
        IQueryable<TaskItem> Tasks { get; }
        IQueryable<Category> Categories { get; }
        void AddTask(TaskItem task);
        void UpdateTask(TaskItem task);
        void DeleteTask(int taskItemId);
        void Save();
    }
}
