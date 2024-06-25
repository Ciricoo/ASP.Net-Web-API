using Sistema_de_Tarefas.Enums;

namespace Sistema_de_Tarefas.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public StatusTarefa Status { get; set;}
    }
}
