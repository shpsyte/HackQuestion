using HackQuestion.Libraries.Core.Domain.Questions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HackQuestion.Libraries.Core.Domain.Categories
{
    public class Category
    {
        public Category()  
        {

        }

        public Category(string name) : this()
        {
            this.Name = name;
            
        }
         

        [Key]
        public int Id {get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<Question> Questions { get; set; }

    }
}