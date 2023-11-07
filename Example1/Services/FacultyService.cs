using Example1.Entities;
using Example1.Interfaces;
// using Example1.Services;
using System.Data;
using System.Data.SqlClient;

namespace Example1.Services
{
    public class FacultyService : IFacultyService
    {
        private const string connectionString = "Server=.\\MSSQLSERVER05;Database=SchoolManagement;Trusted_Connection=True;";
        private readonly string _connectionString;
        public FacultyService(string connectionString)
        {
            _connectionString = connectionString;    
        }
        public bool AddFaculty(Faculty faculty)
        {
            SqlConnection sqlCon = new (connectionString);

            string insertCommand = "FacultyInsert";

            SqlCommand cmd = new ();
            cmd.Connection = sqlCon;
            cmd.CommandText = insertCommand;
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterName = new ();
            parameterName.ParameterName = "@Name";
            parameterName.SqlDbType = System.Data.SqlDbType.VarChar;
            parameterName.Direction = System.Data.ParameterDirection.Input;
            parameterName.SqlValue = faculty.Name;
            cmd.Parameters.Add(parameterName);

            SqlParameter parameterCode = new ();
            parameterCode.ParameterName = "@Code";
            parameterCode.SqlDbType = System.Data.SqlDbType.VarChar;
            parameterCode.Direction = System.Data.ParameterDirection.Input;
            parameterCode.SqlValue = faculty.Code;
            cmd.Parameters.Add(parameterCode);
            
            SqlParameter parameterInstitutionId = new ();
            parameterInstitutionId.ParameterName = "@InstitutionId";
            parameterInstitutionId.SqlDbType = System.Data.SqlDbType.Int;
            parameterInstitutionId.Direction = System.Data.ParameterDirection.Input;
            parameterInstitutionId.SqlValue = faculty.InstitutionId;
            cmd.Parameters.Add(parameterInstitutionId);

            sqlCon.Open();
            int result = cmd.ExecuteNonQuery();
            sqlCon.Close();
            return true;
        }
        public List<Faculty> GetAllFaculty()
        {
           List<Faculty> faculties = new List<Faculty>();

            SqlConnection sqlCon = new SqlConnection(connectionString);
            string insertCommand = "FacultyGetAll";

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandText = insertCommand;
            sqlCom.CommandType = System.Data.CommandType.StoredProcedure;

            sqlCon.Open();
            SqlDataReader reader = sqlCom.ExecuteReader();

            while(reader.Read())
            {
                Faculty faculty = new Faculty();
                
                faculty.Id = reader.GetInt32(0);
                faculty.Name = reader.GetString(1);
                faculty.Code = reader.GetString(2);
                faculty.InstitutionId = reader.GetInt32(3);

                faculties.Add(faculty);
            }  

            return faculties;
        }

        public Faculty GetById(int institutionId)
        {
            Faculty faculty = new ();

            SqlConnection sqlCon = new ();
            string insertCommand = "FacultyGetById";

            SqlCommand sqlCom = new ();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandText = insertCommand;
            sqlCom.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameterIdinstitutionId = new ();
            parameterIdinstitutionId.ParameterName = "@Id";
            parameterIdinstitutionId.SqlDbType = System.Data.SqlDbType.Int;
            parameterIdinstitutionId.Direction = System.Data.ParameterDirection.Input;
            parameterIdinstitutionId.SqlValue = institutionId;
            sqlCom.Parameters.Add(institutionId);

            sqlCon.Open();
            SqlDataReader reader = sqlCom.ExecuteReader();

            while(reader.Read())
            {
                faculty.Id = reader.GetInt32(0);
                faculty.Name = reader.GetString(1);
                faculty.Code = reader.GetString(2);
                faculty.InstitutionId = reader.GetInt32(3);
            }  
            return faculty;

        }

        public bool UpdateFaculty(Faculty faculty)
        {
            SqlConnection sqlCon = new SqlConnection(connectionString);

            string insertCommand = "FacultyUpdate";

            SqlCommand cmd = new ();
            cmd.Connection = sqlCon;
            cmd.CommandText = insertCommand;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameterId = new SqlParameter();
            parameterId.ParameterName = "@Id";
            parameterId.SqlDbType = System.Data.SqlDbType.Int;
            parameterId.Direction = System.Data.ParameterDirection.Input;
            parameterId.SqlValue = faculty.Id;
            cmd.Parameters.Add(parameterId);

            SqlParameter parameterName = new ();
            parameterName.ParameterName = "@Name";
            parameterName.SqlDbType = System.Data.SqlDbType.VarChar;
            parameterName.Direction = System.Data.ParameterDirection.Input;
            parameterName.SqlValue = faculty.Name;
            cmd.Parameters.Add(parameterName);

            SqlParameter parameterEmail = new ();
            parameterEmail.ParameterName = "@Code";
            parameterEmail.SqlDbType = System.Data.SqlDbType.VarChar;
            parameterEmail.Direction = System.Data.ParameterDirection.Input;
            parameterEmail.SqlValue = faculty.Code;
            cmd.Parameters.Add(parameterEmail);

            SqlParameter parameterInstitutionId = new ();
            parameterInstitutionId.ParameterName = "@InstitutionId";
            parameterInstitutionId.SqlDbType = System.Data.SqlDbType.Int;
            parameterInstitutionId.Direction = System.Data.ParameterDirection.Input;
            parameterInstitutionId.SqlValue = faculty.InstitutionId;
            cmd.Parameters.Add(parameterInstitutionId);

            sqlCon.Open();
            int result = cmd.ExecuteNonQuery();
            sqlCon.Close();

            return true;
        } 
    }
}