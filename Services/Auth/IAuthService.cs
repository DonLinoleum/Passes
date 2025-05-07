using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.Services.Auth
{
    interface IAuthService
    {
        Task<bool> Auth();
    }
}
