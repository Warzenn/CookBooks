using System.ComponentModel.DataAnnotations;

namespace CookBook.Model

{
    public class Instructions
    {
        
        public int Id { get; set; }
        [Required]
        public string Instruction { get; set; }

        public Recipe? Recipe { get; set; }
    }
}
