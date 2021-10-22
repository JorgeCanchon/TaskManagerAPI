using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Interfaces.Repositories;
using TaskManager.Infraestructure.Data.EntityFrameworkSQL.Repositories;

namespace TaskManager.Infraestructure.Data.EntityFrameworkSQL
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        public ITaskRepository taskRepository;
        public IUserRepository user;

        private readonly RepositoryContextSqlServer _repositoryContextSqlServer;

        public RepositoryWrapper(RepositoryContextSqlServer repositoryContextSqlServer)
        {
            _repositoryContextSqlServer = repositoryContextSqlServer ?? throw new ArgumentNullException(nameof(repositoryContextSqlServer));
        }

        public ITaskRepository TaskRepository
        {
            get
            {
                if (taskRepository == null)
                    taskRepository = new TaskRepository(_repositoryContextSqlServer);
                return taskRepository;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (user == null)
                    user = new UserRepository(_repositoryContextSqlServer);
                return user;
            }
        }
    }
}
