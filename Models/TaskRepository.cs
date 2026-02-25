namespace Mission08_Team0113.Models
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<TaskItem> Tasks => _context.Tasks;
        public IQueryable<Category> Categories => _context.Categories;

        public void AddTask(TaskItem task) => _context.Tasks.Add(task);
        public void UpdateTask(TaskItem task) => _context.Tasks.Update(task);
        public void DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null) _context.Tasks.Remove(task);
        }
        public void Save() => _context.SaveChanges();
    }
}
