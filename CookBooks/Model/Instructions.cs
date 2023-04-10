
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookBook.Model
{
    public class Instructions
    {

        public int Id { get; set; }
        public string? Instruction { get; set; }
    }
}
