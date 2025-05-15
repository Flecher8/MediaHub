using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Core.Services.Abstract;
public interface IUsersService
{
    Task<Guid?> GetUserIdByEmailAsync(string email);
}
