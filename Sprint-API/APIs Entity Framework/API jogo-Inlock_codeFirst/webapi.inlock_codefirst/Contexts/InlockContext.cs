using Microsoft.EntityFrameworkCore;
using webapi.inlock_codefirst.Domains;

namespace webapi.inlock_codefirst.Contexts
{
    public class InlockContext : DbContext
    {
        public DbSet<TiposUsuario> TiposUsuarios { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Estudio> Estudio { get; set; }

        public DbSet<Jogo> Jogo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE22-S15; Database=inlock_games_codeFirst_tarde; User id = sa; Pwd = Senai@134; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
