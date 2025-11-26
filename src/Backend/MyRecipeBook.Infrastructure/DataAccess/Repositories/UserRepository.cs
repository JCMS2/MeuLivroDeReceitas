using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Entities;
using MyRecipeBook.Domain.Repositories.User;

namespace MyRecipeBook.Infrastructure.DataAccess.Repositories
{
    internal class UserRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository
    {
        private readonly MyRecipeBookDbcontext _dbContext;

        public UserRepository(MyRecipeBookDbcontext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task Add(User user)
        {
           await _dbContext.Users.AddAsync(user);
        }
        public async Task<bool> ExistActiveUserWithEmail(string email)
        {
            return await _dbContext.Users.AnyAsync(u=> u.Email.Equals(email) && u.Active);
        }
    }
}
