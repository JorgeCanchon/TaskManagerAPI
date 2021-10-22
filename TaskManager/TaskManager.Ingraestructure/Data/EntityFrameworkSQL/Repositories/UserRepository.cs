using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Entities;
using TaskManager.Core.Interfaces.Repositories;

namespace TaskManager.Infraestructure.Data.EntityFrameworkSQL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RepositoryContextSqlServer _repositoryContextSqlServer;
        public UserRepository(RepositoryContextSqlServer repositoryContextSqlServer)
            //: base(repositoryContextSqlServer)
        {
            _repositoryContextSqlServer = repositoryContextSqlServer ?? throw new ArgumentNullException(nameof(repositoryContextSqlServer));
        }

        public Core.Entities.User Login(AuthInfo userInfo) =>
            _repositoryContextSqlServer.Users.Where(user => user.Usuario.Equals(userInfo.Username) && user.Password.Equals(userInfo.Password)).FirstOrDefault();
    }
}
