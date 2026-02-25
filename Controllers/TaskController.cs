using Microsoft.AspNetCore.Mvc;

namespace Mission08.Controllers
{
    public class TasksController : Controller
    {
        // Inject repository when teammate #1 has it ready
        // private readonly ITaskRepository _repo;
        // public TasksController(ITaskRepository repo) => _repo = repo;

        [HttpGet]
        public IActionResult Index()
        {
            // TODO: return View(tasksNotCompleted);
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            // TODO: ViewBag.Categories = _repo.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(object task /* replace with Task */)
        {
            // TODO: validate + _repo.AddTask(task) + _repo.Save()
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // TODO: load task + categories, return View("Add", task)
            return View("Add");
        }

        [HttpPost]
        public IActionResult Edit(object task /* replace with Task */)
        {
            // TODO: validate + _repo.UpdateTask(task) + _repo.Save()
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            // TODO: _repo.DeleteTask(id) + _repo.Save()
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Complete(int id)
        {
            // TODO: set Completed=true + save
            return RedirectToAction("Index");
        }
    }
}