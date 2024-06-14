using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Users.Domain.Users;

public interface IUsersDbContext
{
    public DbSet<User> Users { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}