using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.Core.Services.Abstract;
using MediaHub.EntityFramework.Abstract.IRepositories;

namespace MediaHub.Core.Services;
public class UsersService : IUsersService
{
    private readonly IUserRepository _userRepo;

    public UsersService(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    public async Task<Guid?> GetUserIdByEmailAsync(string email)
    {
        // filter by Email (assuming User.Email is indexed / unique)
        var users = await _userRepo.GetFilteredItemsAsync(u => u.Email == email);
        var user = users.FirstOrDefault();
        return user?.Id;
    }
}
