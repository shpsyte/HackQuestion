using System.Collections.Generic;
using HackQuestion.Libraries.Core.Domain.Questions;
using HackQuestion.Libraries.Services.Interfaces;
using HackQuestion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HackQuestion.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly ICategoryServices _category;
        private readonly IQuestionServices _question;

        public QuestionController(ICategoryServices category, IQuestionServices question)
        {
            this._category = category;
            this._question = question;

        }

        // GET: api/Question
        [HttpGet]
        public IEnumerable<Question> Get() => _question.GetAll();

        // GET: api/Question/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _question.GetAll(a => a.CategoryId == id);
            
            if (data == null)
                return NotFound();

            return Ok(data);
        }


        //[HttpGet("{categoryid:int}")]
        //[Route("api/RandomByCategory/")]
        //public IActionResult GetByCategory(int categoryid)
        //{
        //    var data = _question.GetAll(a => a.CategoryId == categoryid);
        //    if (data == null)
        //        return NotFound();

        //    return Ok(data);
        //}

        // POST: api/Question
        [HttpPost]
        public IActionResult Post([FromBody] QuestionModel questionModel)
        {
            bool valid = TryValidateModel(questionModel);

            if (!valid)
            {
                return BadRequest();
            }

            Question question = new Question(
                questionModel._Description,
                questionModel._Tips,
                questionModel._Answer,
                questionModel._CategoryId,
                false, // questionModel._Published, //todo make published by role of user!
                questionModel._Seconds
             );

 
             if (_category.Count(a => a.Id == questionModel._CategoryId) == 0)
             {
                 ModelState.AddModelError("CategoryId","Category not found");
                 return BadRequest(ModelState);
             }

            _question.Add(question);
            _question.Save();
            return Ok(question);
            // return CreatedAtRoute("Get", new { id = question.Id });

        }
        
     
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var data = _question.Find(id);
            data.Deleted = true;
            _question.Update(data);
            _question.Save();
        }
    }
}
