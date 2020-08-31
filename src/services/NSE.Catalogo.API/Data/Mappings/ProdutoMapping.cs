using NSE.Catalogo.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NSE.Catalogo.API.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(j => j.Id);

            builder.Property(j => j.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(j => j.Descricao)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(j => j.Imagem)
                .IsRequired()
                .HasColumnType("varchar(250)");
        }
    }
}
