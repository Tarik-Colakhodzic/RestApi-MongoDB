namespace RestApi_MongoDB.Database
{
    public interface IUserManagementStoreDatabaseSettings
    {
        public string UserCoursesCollectionName { get; set; }
        public string DatabaseName { get; set; }
    }
}