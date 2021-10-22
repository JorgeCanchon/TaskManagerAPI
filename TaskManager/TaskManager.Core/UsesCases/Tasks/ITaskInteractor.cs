using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Entities;

namespace TaskManager.Core.UsesCases.Tasks
{
    public interface ITaskInteractor
    {
        Response GetTasks();
        Response InsertTask(TaskEntity task);
        Response UpdateTask(TaskEntity task);
        Response DeleteTask(int id);
    }
}
