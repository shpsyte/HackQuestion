using HackQuestion.Libraries.Core.Domain.Categories;
using HackQuestion.Libraries.Core.Domain.Questions;
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


    public class QuestionMap : IMapConfiguration<Question>
    {
        public void Map(EntityTypeBuilder<Question> entity)
        {
            entity.ToTable("Question").HasQueryFilter(a => a.Deleted == false);
            entity.HasKey(p => p.Id);

            entity.HasOne(q => q.Category)
                  .WithMany(c => c.Questions)
                  .HasForeignKey(f => f.CategoriId);

        }
    }
}