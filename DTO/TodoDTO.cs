using System.ComponentModel.DataAnnotations;

namespace MeuTodo.DTO
{
    public class TodoDTO
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}