using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Entities;

namespace TaskManager.Core.UsesCases.User
{
    public interface IUserInteractor
    {
        Entities.User Login(AuthInfo user);
    }
}
