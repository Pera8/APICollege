using Mapster;
using Microsoft.EntityFrameworkCore;
using Repository.Model;
using Repository.Repository.IRepository;
using Service.Mapper;
using Share.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class StudentService : IRepository<Student>
    {
        static StudentService() => MapperConfig.RegisterStudentMapping();

        private readonly IRepository<Student> repositoryStudent;
        private readonly IRepository<College> repositoryCollege;
        private readonly IRepository<Subject> repositorySubject;

        public StudentService(IRepository<Student> repositoryStudent, IRepository<College> repositoryCollege, IRepository<Subject> repositorySubject)
        {
            this.repositoryStudent = repositoryStudent;
            this.repositoryCollege = repositoryCollege;
            this.repositorySubject = repositorySubject;
        }
        public async Task<Student> AddAsync(StudentDTO model)
        {
            if (model == null)
            {
                throw new Exception("Student can not be null");
            }
            var _college = await repositoryCollege.GetAsyncById(model.CollegeId);

            if (_college == null)
            {
                throw new KeyNotFoundException("College can't be null");
            }

            var _student = TypeAdapter.Adapt<StudentDTO, Student>(model);
            _student.College = _college;
            return await repositoryStudent.AddAsync(_student);
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1)
            {
                throw new Exception("id can not be null");
            }
            await repositoryStudent.DeleteAsync(id);
        }

        public async Task<DbSet<Student>> GetAllAsync()
        {
            return await repositoryStudent.GetAllAsync();
        }

        public async Task<Student> GetAsyncById(int id)
        {
            if (id < 1)
            {
                throw new Exception("id can not be null");
            }
            return await repositoryStudent.GetAsyncById(id);
        }

        public Task<Student> AddAsync(Student model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Student>> GetAllStudentByProfessorAndSubjectID(int subjectID, int professorId)
        {
            if(subjectID<1 || professorId < 1)
            {
                throw new Exception("subject or professor can not be null");
            }
            var students = await repositoryStudent.GetAllAsync();
            var studentList = await students
                .Where(student => student.Professors.Any(professor => professor.Id == professorId) && student.Subjects.Any(subject => subject.Id == subjectID))
                .ToListAsync();

            var test = studentList.Select(x => x.Subjects).ToList();
            var test1 = studentList.Select(x => x.Name).ToList();

            return studentList;
        }

        public async Task<List<SubjectDTO>> GetSubjectsByIdProfessor(int professorId)
        {
            if ( professorId < 1)
            {
                throw new Exception("subject or professor can not be null");
            }
            var subjects = await repositorySubject.GetAllAsync();
            var subjectList = await subjects.Where(subject => subject.Professors.Any(professor => professor.Id == professorId)).ToListAsync();
            var subjectListDTO= subjectList.Select(TypeAdapter.Adapt<SubjectDTO>).ToList();
            return subjectListDTO;
        }
    }
}
