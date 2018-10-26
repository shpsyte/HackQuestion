using HackQuestion.Libraries.Core.Domain.Categories;
using HackQuestion.Libraries.Data.Context;
using HackQuestion.Libraries.Data.Repository;
using HackQuestion.Libraries.Services.Interfaces;

namespace HackQuestion.Libraries.Services.Entity
{
    public class CategoryServices : Repository<Category>, ICategory
    {
        public CategoryServices(HackContext context) : base(context)
        {
            
        }

    }
}