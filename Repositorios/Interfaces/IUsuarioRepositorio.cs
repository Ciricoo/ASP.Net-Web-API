using Sistema_de_Tarefas.Models;

namespace Sistema_de_Tarefas.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarPorID( int id );
        Task<UsuarioModel> Adicionar( UsuarioModel usuario );
        Task<UsuarioModel> Atualizar( UsuarioModel usuario , int id);
        Task<bool> Apagar(int id);
    }
}
