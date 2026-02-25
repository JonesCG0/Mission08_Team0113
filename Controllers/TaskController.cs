using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mission08_Team0113.Models;
using System.Linq;

namespace Mission08_Team0113.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _repo;

        public TaskController(ITaskRepository repo)
        {
            _repo = repo;
        }

        // =========================
        // QUADRANTS (GET)
        // =========================
        [HttpGet]
        public IActionResult Quadrants()
        {
            var tasks = _repo.Tasks
                .Cast<TaskItem>()
                .Where(t => !t.Completed)
                .ToList();

            return View(tasks); // Views/Task/Quadrants.cshtml
        }

        // Optional: keep Index as an alias (in case someone links to /Task/Index)
        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Quadrants));
        }

        // =========================
        // CREATE (GET)
        // =========================
        [HttpGet]
        public IActionResult Create()
        {
            PopulateCategories();
            return View(new TaskItem()); // Views/Task/Create.cshtml (Model: TaskItem)
        }

        // =========================
        // CREATE (POST)
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(task);
                _repo.Save();
                return RedirectToAction(nameof(Quadrants));
            }

            PopulateCategories();
            return View(task);
        }

        // =========================
        // EDIT (GET)
        // =========================
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _repo.Tasks
                .Cast<TaskItem>()
                .FirstOrDefault(t => t.TaskItemId == id);

            if (task == null)
                return RedirectToAction(nameof(Quadrants));

            PopulateCategories();
            return View("Create", task); // reuse Create view
        }

        // =========================
        // EDIT (POST)
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateTask(task);
                _repo.Save();
                return RedirectToAction(nameof(Quadrants));
            }

            PopulateCategories();
            return View("Create", task);
        }

        // =========================
        // DELETE (POST)
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _repo.DeleteTask(id);
            _repo.Save();
            return RedirectToAction(nameof(Quadrants));
        }

        // =========================
        // COMPLETE (POST)
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Complete(int id)
        {
            var task = _repo.Tasks
                .Cast<TaskItem>()
                .FirstOrDefault(t => t.TaskItemId == id);

            if (task != null)
            {
                task.Completed = true;
                _repo.UpdateTask(task);
                _repo.Save();
            }

            return RedirectToAction(nameof(Quadrants));
        }

        private void PopulateCategories()
        {
            // Only needed if your _TaskForm uses ViewBag.Categories for the dropdown
            ViewBag.Categories = _repo.Categories
                .Cast<Category>()
                .Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.Name
                })
                .ToList();
        }
    }
}