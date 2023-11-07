using Example1.Entities;

namespace Example1.Interfaces
{
    public interface IInstitutionService
    {
        bool AddInstitution(Institution institution);
        bool UpdateInstitution(Institution institution);
        List<Institution> GetAll();
        Institution GetById(int institutionId);
    }
}