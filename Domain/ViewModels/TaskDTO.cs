using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Domain.Entities;

namespace TaskProject.Domain.ViewModels
{
    public class TaskDTO
    {
        public InsertTaskViewModel? Data { get; set; }
        public string? Message { get; set; }
        public TaskResult? Result { get; set; }
    }
    public enum TaskResult
    {
        Success, Failure, TaskNotFound
    }
}
