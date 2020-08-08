using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmerOzkan.Digiturk.Makale.Entities.Concrate;

namespace OmerOzkan.Digiturk.Makale.DataAccess.Mapping
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Title).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Description).HasColumnType("ntext");

            builder.HasOne(I => I.Category).WithMany(I => I.Articles).HasForeignKey(I => I.CategoryId);
        }
    }
}
