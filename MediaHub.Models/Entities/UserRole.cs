using Microsoft.AspNetCore.Identity;

namespace MediaHub.Models.Entities;

public class UserRole : IdentityRole<Guid>
{
    //PK: public Guid Id { get; set; }

    #region Foreign Keys

    //User -> One to many
    public List<User> Users { get; set; } = new();

    #endregion
}
