using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class ToDoTask
    {
        [Key]
        public int id { get; set; }
        public string Task_Name { get; set;}
        public string Task_Description { get; set;}
        public bool Task_Status { get; set;}
        public byte Task_Type { get; set;}

    }
}
