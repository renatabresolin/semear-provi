using System.Collections.Generic;
using SemearApi.Entities;
using SemearApi.Repository.Configuration;

namespace SemearApi.Repository.Interface
{
    public interface IUserRepository : IRepositoryBase<User>
    {

        public List<User> GetAllLearns();

    }
}