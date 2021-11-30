using Mapster;
using Repository.Model;
using Share.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapper
{
    public static class MapperConfig
    {
        public static void RegisterStudentMapping()
        {
            TypeAdapterConfig<Student, StudentDTO>.NewConfig()
                .Map(des => des.CollegeId,
                src => src.College.Id,
                src => src.College != null);

            TypeAdapterConfig<StudentDTO, Student>.NewConfig();
        }

        public static void RegisterSubjectMapping()
        {
            TypeAdapterConfig<Subject, SubjectDTO>.NewConfig()
                .Map(des => des.CollegeId,
                src => src.College.Id,
                src => src.College != null);
            TypeAdapterConfig<SubjectDTO, Subject>.NewConfig();
        }

        public static void RegisterProfessorMapping()
        {
            TypeAdapterConfig<Professor, ProfessorDTO>.NewConfig();
            TypeAdapterConfig<ProfessorDTO, Professor>.NewConfig();
        }

        public static void RegisterCollegeMapping()
        {
            TypeAdapterConfig<College, CollegeDTO>.NewConfig();
            TypeAdapterConfig<CollegeDTO, College>.NewConfig();
        }

        public static void RegisterCollegeDTOMapping()
        {
            TypeAdapterConfig<CollegeDTO, College>.NewConfig();
            TypeAdapterConfig<College, CollegeDTO>.NewConfig();
        }
    }
}
