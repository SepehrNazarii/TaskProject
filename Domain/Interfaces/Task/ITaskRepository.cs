using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Domain.Entities;

namespace TaskProject.Domain.Interfaces.Task
{
    public interface ITaskRepository
    {
        #region Read
        public Task<List<Entities.Task>> GetAll();
        public Task<Entities.Task> GetByID(Guid id);
        public Task<bool> Exist(Guid id);
        #endregion

        #region Create
        public Task<bool> Create(Entities.Task task);
        #endregion

        #region Update
        public bool Update(Entities.Task task);
        #endregion

        #region Delete
        public bool Delete(Entities.Task task);
        #endregion

        #region SaveChanges
        public System.Threading.Tasks.Task SaveChanges();
        #endregion
    }
}
