using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HackQuestion.Libraries.Data.Map
{
    public interface IMapConfiguration<T> where T:class
    {
        void Map(EntityTypeBuilder<T> entity);
    }
}
