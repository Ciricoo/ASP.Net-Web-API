using Microsoft.EntityFrameworkCore;
using Sistema_de_Tarefas.Data;
using Sistema_de_Tarefas.Models;
using Sistema_de_Tarefas.Repositorios.Interfaces;

namespace Sistema_de_Tarefas.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemasTarefaDBContext _dbContext;
        public UsuarioRepositorio(SistemasTarefaDBContext sistemasTarefaDBContext)
        {
            _dbContext = sistemasTarefaDBContext;
        }
        public async Task<UsuarioModel> BuscarPorID(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();

        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioId = await BuscarPorID(id);

            if (usuarioId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de Dados");
            }

            usuarioId.Nome = usuario.Nome;
            usuarioId.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioId);
            await _dbContext.SaveChangesAsync();

            return usuarioId;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioId = await BuscarPorID(id);

            if (usuarioId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de Dados");
            }

            _dbContext.Usuarios.Remove(usuarioId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
