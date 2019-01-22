using HackQuestion.Libraries.Core.Domain.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackQuestion.Libraries.Core.Domain.Questions
{
    public class Question
    {
        public Question()
        {
            this.CreateDate = System.DateTime.UtcNow;
            this.Deleted = false;
            this.Published = true;
        }

        public Question(string description, string tips, string answer, int categoryId, bool published, int second = 0) : this()
        {
            this.Description = description;
            this.Tips = tips;
            this.Answer = answer;
            this.CategoryId = categoryId;
            this.Published = published;
            this.Seconds = second > 0 ? second : 0;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public string Tips { get; set; }
        public string Answer { get; set; }
        public int Seconds { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Deleted { get; set; }
        
        public bool Published {get;set;}

        public Category Category { get; set; }



    }
}
