using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Entities;

namespace TaskManager.Core.Interfaces.Repositories
{
    public interface ITaskRepository : IRepositoryBase<TaskEntity>
    {
    }
}
