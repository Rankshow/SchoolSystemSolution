using Example1.Entities;

namespace Example1.Interfaces
{
    public interface IDepartmentService
    {
        bool AddDepartment(Department department);
        bool UpdateDepartment(Department department);
        List<Department> GetAllDepartment();
        Department GetById(int departmentId);
    }
}