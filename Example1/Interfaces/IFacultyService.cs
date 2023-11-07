using Example1.Entities;

namespace Example1.Interfaces
{
    public interface IFacultyService
    {
        bool AddFaculty(Faculty faculty);
        bool UpdateFaculty(Faculty faculty);
        List<Faculty> GetAllFaculty();
        Faculty GetById(int InstitutionId);
    }
}