using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.DataLayer.DataContext;
using TaskProject.Domain.Entities;
using TaskProject.Domain.Interfaces.Task;

namespace TaskProject.DataLayer.Repositories.Task
{
    public  class TaskRepository : ITaskRepository
    {
        #region Ctor
        private TaskDataContext _context;
        public TaskRepository(TaskDataContext context)
        {
            _context = context;
        }
        #endregion

        #region Get

        public async Task<List<Domain.Entities.Task>> GetAll()
        {
            return await _context.Tasks.AsNoTracking().ToListAsync();
        }

        public async Task<Domain.Entities.Task> GetByID(Guid id)
        {
            return await _context.Tasks.AsNoTracking().FirstOrDefaultAsync(s => s.ID == id);
        }
        public async Task<bool> Exist(Guid id)
        {
            return await _context.Tasks.AsNoTracking().AnyAsync(s => s.ID == id);  
        }

        #endregion

        #region Create
        public async Task<bool> Create(Domain.Entities.Task task)
        {
            try
            {
                await _context.AddAsync(task);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Update
        public bool Update(Domain.Entities.Task task)
        {
            try
            {
                _context.Tasks.Update(task);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Delete

        public bool Delete(Domain.Entities.Task task)
        {
            try
            {
                _context.Tasks.Remove(task);
                return true;
            }
            catch (Exception e)
            {
                return false; 
            }
        }
        #endregion

        #region SaveChanges
        public async System.Threading.Tasks.Task SaveChanges()
        {
            await _context.SaveChangesAsync();  
        }

        #endregion
    }
}
