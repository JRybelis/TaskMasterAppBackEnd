using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskMasterApp.Data;
using TaskMasterApp.Interfaces;
using TaskmasterCore.Models;

namespace TaskMasterApp.Repositories
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<TaskItem>> GetAll()
        {
            return await _context.Set<TaskItem>().ToListAsync();
        }

        public async Task<TaskItem> GetById(int id)
        {
            var entity = await _context.Set<TaskItem>().FirstOrDefaultAsync(e => e.Id == id);

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return entity;
        }

        public async Task Post(TaskItem entity)
        {
            _context.Add(entity);
            
            await _context.SaveChangesAsync();
        }

        public async Task Update(TaskItem entity)
        {
            _context.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Set<TaskItem>().FirstOrDefaultAsync(e => e.Id == id);

            if (entity != null)
            {
                _context.Remove(entity);
            }

            await _context.SaveChangesAsync();
        }
    }
}
