using MongoDB.Driver;
namespace RestApi.Models.Service
{
    public class StudentService : IStudentService
    {
        private readonly IMongoCollection<Student> _students;

        public StudentService(IStudentStoreDatabaseSetting setting , IMongoClient mongoClient) {
           var database = mongoClient.GetDatabase(setting.DatabaseName);
            _students = database.GetCollection<Student>(setting.StudentCoursesCollectionName);
        }
        public Student Create(Student student)
        {
            _students.InsertOne(student);
            return student;
        }

        public List<Student> Get()
        {
            return _students.Find(student => true).ToList();
        }

        public Student Get(string id)
        {
            return _students.Find(student => student.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _students.DeleteOne(student => student.Id == id);
        }

        public void Update(string id, Student student)
        {
            _students.ReplaceOne(student => student.Id == id,student);
        }
       
        

      
    }
}
