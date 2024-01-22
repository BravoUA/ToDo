using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class InDateTask
    {
        [Required(ErrorMessage = "Enter Task Name")]
        public string Task_Name { get; set;}
        [Required(ErrorMessage = "Enter Task Description")]
        public string Task_Description { get; set;}
        [Required(ErrorMessage = "Enter Task Type")]
        public byte Task_Type { get; set;}

    }
}
