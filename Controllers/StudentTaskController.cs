using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentTaskManagementSystem.Data;
using StudentTaskManagementSystem.Models;

namespace StudentTaskManagementSystem.Controllers
{
    public class StudentTaskController : Controller
    {
        protected ApplicationDbContext _db;
        public StudentTaskController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddTask() 
        {
            var curr = HttpContext.Session.GetInt32("CurrentUser");
            if(curr == null)
            {
                return RedirectToAction("LoginUser", "UserCredential");
            }
            return View();
        }
        public IActionResult ReceiveAddTask(StudentTaskModel std)
        {
            var curr = HttpContext.Session.GetInt32("CurrentUser");
            if(curr != null)
            {
                std.UserId = Convert.ToInt32(curr);
                _db.Add(std);
                _db.SaveChanges();
                return RedirectToAction("DisplayTask");
            }
            return RedirectToAction("LoginUser", "UserCredential");
        }
        public IActionResult DisplayTask()
        {
            var curr = HttpContext.Session.GetInt32("CurrentUser");
            if (curr == null)
            {
                return RedirectToAction("LoginUser", "UserCredential");
            }
            var tasks = _db.StudentTasks.Where(tk => tk.UserId == curr).ToList();
            return View(tasks);
        }
        public IActionResult EditTask(int Id)
        {
            var curr = HttpContext.Session.GetInt32("CurrentUser");
            var task = _db.StudentTasks.FirstOrDefault(tk => tk.TaskId == Id && tk.UserId == curr);
            if(task == null)
            {
                return Content("Task Not Found!");
            }
            return View(task);
        }
        public IActionResult ReceiveEditTask(StudentTaskModel std)
        {
            var curr = HttpContext.Session.GetInt32("CurrentUser");
            var task = _db.StudentTasks.FirstOrDefault(tk => tk.TaskId == std.TaskId && tk.UserId == curr);
            if(task != null)
            {
                task.SubjectName = std.SubjectName;
                task.TaskName = std.TaskName;
                task.TaskPriority = std.TaskPriority;
                task.TaskDescription = std.TaskDescription;
                task.DueDate = std.DueDate;
                task.TaskStatus = std.TaskStatus;
                _db.SaveChanges();
            }
            return RedirectToAction("DisplayTask");
        }
        public IActionResult DeleteTask(int Id)
        {
            var curr = HttpContext.Session.GetInt32("CurrentUser");
            var task = _db.StudentTasks.FirstOrDefault(tk => tk.TaskId == Id && tk.UserId == curr);
            if (task == null)
            {
                return Content("Task Not Found!");
            }
            if (task != null)
            {
                _db.Remove(task);
                _db.SaveChanges();
            }
            return RedirectToAction("DisplayTask");
        }
    }
}
