using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Entities;
using TaskManager.Core.Interfaces.Repositories;

namespace TaskManager.Core.UsesCases.User
{
    public class UserInteractor : IUserInteractor
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public UserInteractor(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper));
        }

        public Entities.User Login(AuthInfo user) =>
            _repositoryWrapper.User.Login(user);
    }
}
