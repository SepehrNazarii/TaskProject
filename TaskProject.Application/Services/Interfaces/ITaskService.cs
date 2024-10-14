using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Domain.ViewModels;

namespace TaskProject.Application.Services.Interfaces
{
    public interface ITaskService
    {
        #region Get Tasks
        public Task<List<TaskViewModel>> GetAllTasks();
        public Task<TaskDTO> GetTaskByID(Guid id);
        

        #endregion

        #region Add Task
        public Task<TaskDTO> AddTask(InsertTaskViewModel model);
        #endregion

        #region Edit Task
        public Task<TaskDTO> EditTask(InsertTaskViewModel model , Guid ID);
        #endregion

        #region Remove Task
        public Task<TaskDTO> RemoveTask(Guid ID);
        #endregion

    }
}


