using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example1.Entities;

namespace Example1.Interfaces
{
    public interface ICourse
    {
        bool AddCourse(Course course);
        bool UpdateCourse(Course course);
        List<Department> GetAllCourse();
        Course GetById(int DepartmentId);
    }
}