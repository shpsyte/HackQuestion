using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HackQuestion.Libraries.Data
{
    public interface IMapConfiguration<T> where T:class
    {
        void Map(EntityTypeBuilder<T> entity);
    }
}
