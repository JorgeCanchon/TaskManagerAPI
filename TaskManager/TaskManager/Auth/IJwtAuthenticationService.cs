using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(string id);
    }
}
