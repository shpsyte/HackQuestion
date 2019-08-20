using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackQuestion.Libraries.Core.Domain.Questions;
using HackQuestion.Libraries.Data.Repository;

namespace HackQuestion.Libraries.Services.Interfaces {
    public interface IQuestionServices : IRepository<Question> {
        bool Check ();

    }
}