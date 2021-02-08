using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SemearApi.Entities;
using SemearApi.Repository.Configuration;
using SemearApi.Repository.Interface;

namespace SemearApi.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(SemearAppContext semearAppContext) : base(semearAppContext)
        {
        }


        public List<User> GetAllLearns()
        {
            return SemearAppContext.Set<User>()
                .Include(s => s.UserLearn)
                .Include(s => s.UserIntructs)
                .ToList();
        }
    }
}