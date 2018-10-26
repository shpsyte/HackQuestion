using HackQuestion.Libraries.Core.Domain.Questions;
using HackQuestion.Libraries.Data.Context;
using HackQuestion.Libraries.Data.Repository;
using HackQuestion.Libraries.Services.Interfaces;
 

namespace HackQuestion.Libraries.Services.Entity
{
    public class QuestionServices : Repository<Question>, IQuestionServices
    {
        public QuestionServices(HackContext context) : base(context)
        {

        }

        public bool Check() => true;
    }
}
