using System.Data.SqlClient;
using System.Data;
using Example1.Entities;
using Example1.Interfaces;

namespace Example1.Services
{
    public class DepartmentService : IDepartmentService
    {
        private const string connectionString = "Server=.\\MSSQLSERVER05;Database=SchoolManagement;Trusted_Connection=True;";
        private readonly string _connectionString;

        public DepartmentService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool AddDepartment(Department department)
        {
            SqlConnection sqlCon = new (connectionString);

            string insertCommand = "DepartmentInsert";

            SqlCommand cmd = new ();
            cmd.Connection = sqlCon;
            cmd.CommandText = insertCommand;
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterName = new ();
            parameterName.ParameterName = "@Name";
            parameterName.SqlDbType = SqlDbType.VarChar;
            parameterName.Direction = ParameterDirection.Input;
            parameterName.SqlValue = department.Name;
            cmd.Parameters.Add(parameterName);

            SqlParameter parameterCode = new ();
            parameterCode.ParameterName = "@Code";
            parameterCode.SqlDbType = System.Data.SqlDbType.VarChar;
            parameterCode.Direction = System.Data.ParameterDirection.Input;
            parameterCode.SqlValue = department.Code;
            cmd.Parameters.Add(parameterCode);
            
            SqlParameter parameterfacultyId = new ();
            parameterfacultyId.ParameterName = "@FacultyId";
            parameterfacultyId.SqlDbType = System.Data.SqlDbType.Int;
            parameterfacultyId.Direction = System.Data.ParameterDirection.Input;
            parameterfacultyId.SqlValue = department.FacultyId;
            cmd.Parameters.Add(parameterfacultyId);

            sqlCon.Open();
            int result = cmd.ExecuteNonQuery();
            sqlCon.Close();
            return true;
        }

        public List<Department> GetAllDepartment()
        {
            List<Department> departments = new List<Department>();

            SqlConnection sqlCon = new SqlConnection(connectionString);
            string insertCommand = "DepartmentGetAll";

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandText = insertCommand;
            sqlCom.CommandType = System.Data.CommandType.StoredProcedure;

            sqlCon.Open();
            SqlDataReader reader = sqlCom.ExecuteReader();

            while(reader.Read())
            {
                Department department = new ();
                
                department.Id = reader.GetInt32(0);
                department.Name = reader.GetString(1);
                department.Code = reader.GetString(2);
                department.FacultyId = reader.GetInt32(3);
    
                departments.Add(department);
            }  

            return departments;
        }

        public Department GetById(int facultyId)
        {
            Department department = new ();

            SqlConnection sqlCon = new ();
            string insertCommand = "DepartmentGetById";

            SqlCommand sqlCom = new ();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandText = insertCommand;
            sqlCom.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameterFacultyId = new ();
            parameterFacultyId.ParameterName = "@Id";
            parameterFacultyId.SqlDbType = System.Data.SqlDbType.Int;
            parameterFacultyId.Direction = System.Data.ParameterDirection.Input;
            parameterFacultyId.SqlValue = facultyId;
            sqlCom.Parameters.Add(facultyId);

            sqlCon.Open();
            SqlDataReader reader = sqlCom.ExecuteReader();

            while(reader.Read())
            {
                department.Id = reader.GetInt32(0);
                department.Name = reader.GetString(1);
                department.Code = reader.GetString(2);
                department.FacultyId = reader.GetInt32(3);
            }  
            return department;

        }

        public bool UpdateDepartment(Department department)
        {
            SqlConnection sqlCon = new SqlConnection(connectionString);

            string insertCommand = "DepartmentUpdate";

            SqlCommand cmd = new ();
            cmd.Connection = sqlCon;
            cmd.CommandText = insertCommand;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameterId = new SqlParameter();
            parameterId.ParameterName = "@Id";
            parameterId.SqlDbType = System.Data.SqlDbType.Int;
            parameterId.Direction = System.Data.ParameterDirection.Input;
            parameterId.SqlValue = department.Id;
            cmd.Parameters.Add(parameterId);

            SqlParameter parameterName = new ();
            parameterName.ParameterName = "@Name";
            parameterName.SqlDbType = System.Data.SqlDbType.VarChar;
            parameterName.Direction = System.Data.ParameterDirection.Input;
            parameterName.SqlValue = department.Name;
            cmd.Parameters.Add(parameterName);

            SqlParameter parameterEmail = new ();
            parameterEmail.ParameterName = "@Code";
            parameterEmail.SqlDbType = System.Data.SqlDbType.VarChar;
            parameterEmail.Direction = System.Data.ParameterDirection.Input;
            parameterEmail.SqlValue = department.Code;
            cmd.Parameters.Add(parameterEmail);

            SqlParameter parameterInstitutionId = new ();
            parameterInstitutionId.ParameterName = "@InstitutionId";
            parameterInstitutionId.SqlDbType = System.Data.SqlDbType.Int;
            parameterInstitutionId.Direction = System.Data.ParameterDirection.Input;
            parameterInstitutionId.SqlValue = department.FacultyId;
            cmd.Parameters.Add(parameterInstitutionId);

            sqlCon.Open();
            int result = cmd.ExecuteNonQuery();
            sqlCon.Close();

            return true;
        } 
    }
}