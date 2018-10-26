using HackQuestion.Libraries.Core.Domain.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HackQuestion.Libraries.Data.Map
{
    public class CategoryMap : IMapConfiguration<Category>
    {
       
        public void Map(EntityTypeBuilder<Category> entity)
        {
            entity.ToTable("Category");
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name).HasColumnName("Name");
        }

    }
}