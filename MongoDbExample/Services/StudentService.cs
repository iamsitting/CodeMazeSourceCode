using MongoDbExample.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDbExample.Services
{
    public class StudentService
    {
        private readonly IMongoCollection<Student> _students;
        public StudentService(ISchoolDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _students = database.GetCollection<Student>(settings.StudentsCollectionName);
        }
        public async Task<List<Student>> GetAll()
        {
            return await _students.Find(s => true).ToListAsync();
        }
        public async Task<Student> GetById(string id)
        {
            return await _students.Find<Student>(s => s.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Student> Create(Student student)
        {
            await _students.InsertOneAsync(student);
            return student;
        }
        public async Task Update(string id, Student student)
        {
            await _students.ReplaceOneAsync(s => s.Id == id, student);
        }
        public async Task Remove(string id)
        {
            await _students.DeleteOneAsync(s => s.Id == id);
        }
    }
}