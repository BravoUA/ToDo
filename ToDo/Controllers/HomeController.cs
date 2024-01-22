using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private dbConnect DBCON;
        public HomeController(ILogger<HomeController> logger,dbConnect dbConnect)
        {
            _logger = logger;
            DBCON = dbConnect;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ToDoTask> ToDoTask = new List<ToDoTask>();
            
            
                ToDoTask = DBCON.ToDoTask.ToList();
            
           return View(ToDoTask);
         
        }

        [HttpPost]
        public IActionResult Index(InDateTask InDateTask) {
            AddTask addTask = new AddTask(DBCON);
            addTask.AddNewTask(InDateTask);
            List<ToDoTask> ToDoTask = new List<ToDoTask>();
            ToDoTask = DBCON.ToDoTask.ToList();
            return View(ToDoTask);
            
        }

        [HttpPost]
        public IActionResult DeleteTask(int ID)
        { 
            List<ToDoTask> toDoTasks = new List<ToDoTask>();
            ToDoTask toDoTask = new ToDoTask();
            toDoTasks = DBCON.ToDoTask.Where(p=>p.id==ID).ToList();
            toDoTask = toDoTasks[0];
            DBCON.ToDoTask.Remove(toDoTask);
            DBCON.SaveChanges();
            List<ToDoTask> ToDoTask = new List<ToDoTask>();
            ToDoTask = DBCON.ToDoTask.ToList();
            return View(ToDoTask);
        }

        [HttpPost]
        public IActionResult EditeTaskName(string NAME,int ID)
        {
            List<ToDoTask> toDoTasks = new List<ToDoTask>();
            ToDoTask toDoTask = new ToDoTask();
            toDoTasks = DBCON.ToDoTask.Where(p => p.id == ID).ToList();
            toDoTask = toDoTasks[0];
            toDoTask.Task_Name = NAME;
            DBCON.ToDoTask.Update(toDoTask);
            DBCON.SaveChanges();
            List<ToDoTask> ToDoTask = new List<ToDoTask>();
            ToDoTask = DBCON.ToDoTask.ToList();
            return View(ToDoTask);
        }
        [HttpPost]
        public IActionResult EnableTask([FromBody] CheckedTask model)
        {
            List<ToDoTask> ToDoTasks = new List<ToDoTask>();
            ToDoTask toDoTask = new ToDoTask();
            ToDoTasks = DBCON.ToDoTask.Where(p=>p.id == model.TaskId).ToList();
            toDoTask = ToDoTasks[0];
            if (model.Checked == true)
            {
                toDoTask.Task_Status = true;
                DBCON.ToDoTask.Update(toDoTask);
                DBCON.SaveChanges();
            }
            else
            {
                toDoTask.Task_Status = false;
                DBCON.ToDoTask.Update(toDoTask);
                DBCON.SaveChanges();
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}