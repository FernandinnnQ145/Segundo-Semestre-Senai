using Microsoft.EntityFrameworkCore;
using webapi.HealthClinic.tarde.Domains;

namespace webapi.HealthClinic.tarde.Contexts
{
    public class HealthClinicContext : DbContext
    {
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Clinica> Clinica { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Prontuario> Prontuario { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE22-S15; Database=HealthClinic_tarde; User id = sa; Pwd = Senai@134; TrustServerCertificate=True;", x => x.UseDateOnlyTimeOnly());
            base.OnConfiguring(optionsBuilder);
        }
    }
}
