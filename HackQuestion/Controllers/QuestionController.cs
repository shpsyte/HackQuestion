using System.Collections.Generic;
using HackQuestion.Libraries.Core.Domain.Questions;
using HackQuestion.Libraries.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var data = _question.Find(id);
            if (data == null)
                return NotFound();

            return Ok(data);
        }


        // POST: api/Question
        [HttpPost]
        public IActionResult Post([FromBody] Question question)
        {
            if (question == null)
            {
                return BadRequest();
            }

            question.Deleted = false;
            question.CreateDate = System.DateTime.UtcNow;

            _question.Add(question);
            _question.Save();

            return CreatedAtRoute("Get", new { id = question.Id }, question);

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
