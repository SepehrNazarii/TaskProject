using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskProject.Application.Extentions;
using TaskProject.Application.Services.Interfaces;
using TaskProject.Domain.ViewModels;

namespace TaskProject.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        #region Ctor
        private ITaskService _service;
        public TaskController(ITaskService service)
        {
            _service = service;
        }
        #endregion

        #region Get
        [HttpGet]
        [Route("Tasks")]
        public async Task<ActionResult<IEnumerable<TaskViewModel>>> GetTasks()
        {
            var tasks = await _service.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet]
        [Route("Tasks/{ID}")]
        public async Task<ActionResult<TaskDTO>> GetTask(Guid ID)
        {
            var result = await _service.GetTaskByID(ID);
            
            //Switch On Result
            switch (result.Result)
            {
                case TaskResult.TaskNotFound:
                    return NotFound(result);

                case TaskResult.Failure:
                    return Conflict(result);
            }
            
            return Ok(result);
        }
        #endregion

        #region Create
        [HttpPost]
        [Route("Tasks")]
        public async Task<ActionResult<TaskDTO>> CreateTasks([FromBody] InsertTaskViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.AddTask(model);
            //Switch On Result
            switch (result.Result)
            {

                case TaskResult.TaskNotFound:
                    return NotFound(result);

                case TaskResult.Failure:
                    return Conflict(result);
            }

            return Ok(result);
        }
        #endregion

        #region Update
        [HttpPut]
        [Route("Tasks/{ID}")]
        public async Task<ActionResult<TaskDTO>> EditTasks([FromBody] InsertTaskViewModel model, Guid ID)
        {
            if (ID == Guid.Empty)
            {
                return BadRequest(
                    new TaskDTO
                    {
                        Result = TaskResult.Failure,
                        Message = "لطفا ID را وارد کنید",
                    }
                );
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.EditTask(model, ID);

            //Switch On Result
            switch (result.Result)
            {

                case TaskResult.TaskNotFound:
                    return NotFound(result);

                case TaskResult.Failure:
                    return Conflict(result);
            }

            return Ok(result);


        }
        #endregion

        #region Delete
        [HttpDelete]
        [Route("Tasks/{ID}")]
        public async Task<ActionResult<TaskDTO>> DeleteTask(Guid ID)
        {
            if(ID == Guid.Empty)
            {
                return BadRequest(
                  new TaskDTO
                  {
                      Result = TaskResult.Failure,
                      Message = "لطفا ID را وارد کنید",
                  }
              );
            }

            var result = await _service.RemoveTask(ID);
            switch (result.Result) 
            {
                case TaskResult.TaskNotFound:
                    return NotFound(result);

                case TaskResult.Failure:
                    return Conflict(result);
            }

            return Ok(result);
        }
        #endregion

    }
}
