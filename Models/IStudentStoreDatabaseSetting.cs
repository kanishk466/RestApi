namespace RestApi.Models
{
    public interface IStudentStoreDatabaseSetting
    {
        string StudentCoursesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
