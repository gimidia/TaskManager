namespace TaskManager.Domain.Entities;

public enum TaskStatus
{
    Pendente,
    EmProgresso,
    Concluida
}

public class TaskItem
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    public DateTime? DataConclusao { get; set; }
    public TaskStatus Status { get; set; } = TaskStatus.Pendente;
}
