namespace RestApi_MongoDB.Database
{
    public class UserManagementStoreDatabaseSettings : IUserManagementStoreDatabaseSettings
    {
        public string UserCoursesCollectionName { get; set; }
        public string DatabaseName { get; set; }
    }
}