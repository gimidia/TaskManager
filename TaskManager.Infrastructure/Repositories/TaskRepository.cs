using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.Persistence;

namespace TaskManager.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TaskItem>> GetAllAsync()
    {
        return await _context.TaskItems.ToListAsync(); 
    }

    public async Task<TaskItem?> GetByIdAsync(int id)
    {
        return await _context.TaskItems.FindAsync(id); 
    }

    public async Task AddAsync(TaskItem task)
    {
        await _context.TaskItems.AddAsync(task); 
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TaskItem task)
    {
        _context.TaskItems.Update(task); 
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var task = await _context.TaskItems.FindAsync(id);
        if (task != null)
        {
            _context.TaskItems.Remove(task); 
            await _context.SaveChangesAsync();
        }
    }
}

