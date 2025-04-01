using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<IEnumerable<TaskItem>> GetAllTasksAsync() => await _taskRepository.GetAllAsync();

    public async Task<TaskItem?> GetTaskByIdAsync(int id) => await _taskRepository.GetByIdAsync(id);

    public async Task AddTaskAsync(TaskItem task)
    {
        if (string.IsNullOrWhiteSpace(task.Titulo) || task.Titulo.Length > 100)
            throw new ArgumentException("O título é obrigatório e deve ter no máximo 100 caracteres.");

        if (task.DataConclusao.HasValue && task.DataConclusao < task.DataCriacao)
            throw new ArgumentException("A data de conclusão não pode ser anterior à data de criação.");

        await _taskRepository.AddAsync(task);
    }

    public async Task UpdateTaskAsync(TaskItem task) 
    {
        if (string.IsNullOrWhiteSpace(task.Titulo) || task.Titulo.Length > 100)
            throw new ArgumentException("O título é obrigatório e deve ter no máximo 100 caracteres.");

        if (task.DataConclusao.HasValue && task.DataConclusao < task.DataCriacao)
            throw new ArgumentException("A data de conclusão não pode ser anterior à data de criação.");
        
        await _taskRepository.UpdateAsync(task);
    }

    public async Task DeleteTaskAsync(int id) => await _taskRepository.DeleteAsync(id);
}
