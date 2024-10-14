using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using TaskProject.Application.Extentions;
using TaskProject.Application.Services.Interfaces;
using TaskProject.Domain.Entities;
using TaskProject.Domain.Interfaces.Task;
using TaskProject.Domain.ViewModels;

namespace TaskProject.Application.Services.Implimants
{
    public class TaskService : ITaskService
    {

        #region Ctor
        private ITaskRepository _repo;
        public TaskService(ITaskRepository repo)
        {
            _repo = repo;
        }
        #endregion

        #region Get Task
        public async Task<List<TaskViewModel>> GetAllTasks()
        {
            var result = await _repo.GetAll();
            return result.Select(x => new TaskViewModel {
                ID = x.ID,
                Title = x.Title,
                IsComplited = x.IsComplited,
                DueDate = x.DueDate.Toshamsi()
            }).ToList();
        }
        public async Task<TaskDTO> GetTaskByID(Guid id)
        {

            var IsExist = await _repo.Exist(id);
            if (IsExist)
            {
                var result = await _repo.GetByID(id);

                return new TaskDTO
                {
                    Result = TaskResult.Success,
                    Data = new InsertTaskViewModel
                    {
                        
                        Title = result.Title,
                        Description = result.Description,
                        IsComplited = result.IsComplited,
                        DueDate = result.DueDate.Toshamsi(),
                    }
                };
            }
            else
            {
                return new TaskDTO { Result = TaskResult.TaskNotFound };
            }
        }

        #endregion

        #region Add Task
        public async Task<TaskDTO> AddTask(InsertTaskViewModel model)
        {

            var task = new Domain.Entities.Task
            {
                Title = model.Title,
                Description = model.Description,
                IsComplited = model.IsComplited,
                DueDate = model.DueDate.ToMiladi()
            };

            var resul = await _repo.Create(task);
            await _repo.SaveChanges();

            if (resul)
            {
                return new TaskDTO
                {
                    Result = TaskResult.Success,
                    Message = "تسک با موفقیت ثبت شد",
                    
                };
            }
            else
            {
                return new TaskDTO
                {
                    Result = TaskResult.Failure,
                    Message = "عملیات با شکست مواجه شد"
                };

            }
        }

        #endregion

        #region Edit Task
        public async Task<TaskDTO> EditTask(InsertTaskViewModel model , Guid ID)
        {
            var IsEsxist = await _repo.Exist(ID);
            if (!IsEsxist) { return new TaskDTO { Result = TaskResult.TaskNotFound, Message = "تسکی یافت نشد" }; }
            var task = new Domain.Entities.Task
            {
                ID = ID,
                Title = model.Title,
                Description = model.Description,
                IsComplited = model.IsComplited,
                DueDate = model.DueDate.ToMiladi()
            };
            var resul = _repo.Update(task);
            await _repo.SaveChanges();
            if (resul)
            {
                return new TaskDTO
                {
                    Result = TaskResult.Success,
                    Message = "تسک با موفقیت آپدیت شد"
                };
            }
            else
            {
                return new TaskDTO
                {
                    Result = TaskResult.Failure,
                    Message = "عملیات با شکست مواجه شد"
                };

            }
        }

        #endregion

        #region Remove Task
        public async Task<TaskDTO> RemoveTask(Guid ID)
        {

            var IsEsxist = await _repo.Exist(ID);
            if (!IsEsxist) { return new TaskDTO { Result = TaskResult.TaskNotFound, Message = "تسکی یافت نشد" }; }
            var result = await _repo.GetByID(ID);
            var task = new Domain.Entities.Task
            {
                ID = ID,
                Title = result.Title,
                Description = result.Description,
                IsComplited = result.IsComplited,
                DueDate = result.DueDate
            };
            var resul = _repo.Delete(task);
            await _repo.SaveChanges();
            if (resul)
            {
                return new TaskDTO
                {
                    Result = TaskResult.Success,
                    Message = "تسک با موفقیت حذف شد"
                };
            }
            else
            {
                return new TaskDTO
                {
                    Result = TaskResult.Failure,
                    Message = "عملیات با شکست مواجه شد"
                };

            }

        }

        #endregion

    }
}
