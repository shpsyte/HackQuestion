using HackQuestion.Libraries.Core.Domain.Categories;
using HackQuestion.Libraries.Data.Repository;

namespace HackQuestion.Libraries.Services.Interfaces
{
    public interface ICategoryServices : IRepository<Category>
    {
        bool Check();
    }
}