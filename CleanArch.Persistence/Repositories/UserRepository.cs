using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Persistence.Repositores
{
   public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) 
        { }

        public async Task<User>  GetByEmail(string email, CancellationToken cancellationToken)
        {
            return await Context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        }
    }
}
