using MongoDB.Driver;
using RestApi_MongoDB.Database;
using RestApi_MongoDB.Models;

namespace RestApi_MongoDB.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IUserManagementStoreDatabaseSettings settings, IMongoClient mongoClient)
            : base(settings.DatabaseName, settings.UserCoursesCollectionName, mongoClient)
        {
        }
    }
}