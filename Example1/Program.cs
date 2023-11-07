using Example1.Entities;
using Example1.Services;
using Example1.Interfaces;
namespace Example1;

public class Program
{
    private readonly IInstitutionService _InstitutionService;
    private readonly IFacultyService _FacultyService;
    private readonly IDepartmentService _DepartmentService;
    public Program(string connectionString)
    {
        _InstitutionService = new InstitutionService(connectionString);
        _FacultyService = new FacultyService(connectionString);
        _DepartmentService = new DepartmentService(connectionString);
    }
    static void Main(string[] args)
    {
        Program pg = new Program("Server=.\\MSSQLSERVER05;Database=SchoolManagement;Trusted_Connection=True;");
        
        Console.WriteLine("Choose any option \n 1. Insert Faculty \n 2. Update Faculty \n 3. Get All Faculty .");

        string? option = Console.ReadLine();

        switch(option)
        {
            case ("1"):
                pg.CreateFaculty();
                break;
            case ("2"):
                pg.UpdateFaculty();
                break;
            case ("3"):
                pg.GetAllFaculty();
                break;
            default:
                Console.WriteLine("Unknown option selected, please select the correct option given.");
                break;
        }

        // pg.Get();
    }
    private void CreateInstitution()
    {
        try
        {
            Institution institution = new Institution();

            Console.WriteLine("Please provide the name of the institution.");
            institution.Name = Console.ReadLine();

            Console.WriteLine("Please provide the Email of the institution");
            institution.Email = Console.ReadLine();

            Console.WriteLine("Please provide the State of the institution.");
            institution.State = Console.ReadLine();

            Console.WriteLine("Please provide the Country of the institution.");
            institution.Country = Console.ReadLine();

            
            bool result = _InstitutionService.AddInstitution(institution);

            if(result)
            {
                Console.WriteLine("Institution Added");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
    }
    private void UpdateInstitution()
    {
        try
        {
            Institution institution = new Institution();

            Console.WriteLine("Please provide Id of Institution.");
            institution.Id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please provide Name of Institution.");
            institution.Name = Console.ReadLine();
            
            Console.WriteLine("Please provide Email of Institution.");
            institution.Email = Console.ReadLine();

            Console.WriteLine("Please provide State of Institution.");
            institution.State = Console.ReadLine();

            Console.WriteLine("Please provide Country of Institution.");
            institution.Country = Console.ReadLine();

            bool result = _InstitutionService.UpdateInstitution(institution);

            if(result)
            {
                Console.WriteLine("Institution Updated successfully.");
            }
            else
            {
                Console.WriteLine("Institution failed!!!");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine($"There is an issue in updating ${e.Message}");
        }
    }
    private void GetAll()
    {
       try
       {
            List<Institution> institutions = _InstitutionService.GetAll();

            foreach(Institution insti in institutions) 
            {
                Console.WriteLine($"{ insti.Id } \t {insti.Email} \t {insti.State} \t {insti.Country}");
            }
       }
       catch(Exception e)
       {
            Console.WriteLine(e.Message);
       }
    }

    // *======================================== Faculty ===========================================================
    private void CreateFaculty()
    {
         try
        {
            Faculty faculty = new Faculty();

            Console.WriteLine("Please provide the name of the Faculty.");
            faculty.Name = Console.ReadLine();

            Console.WriteLine("Please provide the Code of the Faculty");
            faculty.Code = Console.ReadLine();

            Console.WriteLine("Please provide the InstitutionId of the Faculty.");
            faculty.InstitutionId = Convert.ToInt32(Console.ReadLine());
            
            bool result = _FacultyService.AddFaculty(faculty);

            if(result)
            {
                Console.WriteLine("Faculty Added");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    private void UpdateFaculty()
    {
         try
        {
            Faculty faculty = new Faculty();

            Console.WriteLine("Please provide Id of Faculty.");
            faculty.Id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please provide Name of Faculty.");
            faculty.Name = Console.ReadLine();
            
            Console.WriteLine("Please provide Code of Faculty.");
            faculty.Code = Console.ReadLine();

            Console.WriteLine("Please provide of Faculty institutionId.");
            faculty.InstitutionId = Convert.ToInt32(Console.ReadLine());

            bool result = _FacultyService.UpdateFaculty(faculty);

            if(result)
            {
                Console.WriteLine("Faculty Updated successfully.");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine($"There is an issue in updating faculty ${e.Message}");
        }
    }
    private void GetAllFaculty()
    {
        try
       {
            List<Faculty> faculties = _FacultyService.GetAllFaculty();

            foreach(Faculty fac in faculties) 
            {
                Console.WriteLine($"{ fac.Id } \t {fac.Name} \t {fac.Code} \t {fac.InstitutionId}");
            }
       }
       catch(Exception e)
       {
            Console.WriteLine(e.Message);
       }
    }
    
    // ======================================== Department =========================================================
    private void CreateDepartment()
    {
         try
        {
            Department department = new ();

            Console.WriteLine("Please provide the name of the Department.");
            department.Name = Console.ReadLine();

            Console.WriteLine("Please provide the Code of the Department");
            department.Code = Console.ReadLine();

            Console.WriteLine("Please provide the FacultyId of the Department.");
            department.FacultyId = Convert.ToInt32(Console.ReadLine());
            
            bool result = _DepartmentService.AddDepartment(department);

            if(result)
            {
                Console.WriteLine("Department Added");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
}
