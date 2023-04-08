using System.ComponentModel.DataAnnotations;

namespace CookBook.Model
{
    public class Instructions
    {
        public int Id { get; set; }
        public string? Instruction { get; set; }
    }
}
