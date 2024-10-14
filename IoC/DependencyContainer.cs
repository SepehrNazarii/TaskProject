using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Application.Services.Implimants;
using TaskProject.Application.Services.Interfaces;
using TaskProject.DataLayer.Repositories.Task;
using TaskProject.Domain.Interfaces.Task;

namespace IoC
{
    public class DependencyContainer
    {
        public static void RegisterDependencies(IServiceCollection _service)
        {
            #region Repository
            _service.AddScoped<ITaskRepository, TaskRepository>();
            #endregion

            #region Service
            _service.AddScoped<ITaskService , TaskService>();
            #endregion
        }
    }
}
