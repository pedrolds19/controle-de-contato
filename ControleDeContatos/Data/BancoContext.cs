using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.Data
{
    public class BancoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("SuaStringDeConexaoAqui");
            }
        }

        public BancoContext(DbContextOptions<BancoContext> options) : base(options){ 

        }

        public DbSet<ContatoModel> Contatos { get; set; }
    }
}
