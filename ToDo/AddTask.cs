using ToDo.Models;

namespace ToDo
{
    public class AddTask
    {
        private dbConnect DBCON;
        public AddTask(dbConnect dbConnect) {
            DBCON = dbConnect;
           
        }
       public void AddNewTask(InDateTask inDateTask) {
            ToDoTask NewTask = new ToDoTask();
            NewTask.Task_Type = inDateTask.Task_Type;
            NewTask.Task_Name = inDateTask.Task_Name;   
            NewTask.Task_Description = inDateTask.Task_Description;
            DBCON.ToDoTask.Add(NewTask);
            DBCON.SaveChanges();
        }
    }
}
