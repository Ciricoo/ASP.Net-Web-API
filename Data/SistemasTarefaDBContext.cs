using Microsoft.EntityFrameworkCore;
using Sistema_de_Tarefas.Controllers;
using Sistema_de_Tarefas.Data.Map;
using Sistema_de_Tarefas.Models;

namespace Sistema_de_Tarefas.Data
{
    public class SistemasTarefaDBContext: DbContext
    {
        public SistemasTarefaDBContext(DbContextOptions<SistemasTarefaDBContext> options) 
            : base(options)
        { }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
