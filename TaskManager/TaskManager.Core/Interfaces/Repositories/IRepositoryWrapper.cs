using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Core.Interfaces.Repositories
{
    public interface IRepositoryWrapper
    {
        ITaskRepository TaskRepository { get; }
        IUserRepository User { get; }
    }
}
