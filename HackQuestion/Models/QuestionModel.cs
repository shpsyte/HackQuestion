using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackQuestion.Models
{
    public class QuestionModel
    {
       

        [Key]
        public int _Id { get; set; }
        [Required]
        public string _Description { get; set; }
        public string _Tips { get; set; }
        public string _Answer { get; set; }
        public int _Seconds { get; set; }
        public int _CategoryId { get; set; }
       

      
    }
}
