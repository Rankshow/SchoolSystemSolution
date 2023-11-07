using Example1.Entities;
using Example1.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Example1.Services
{
    public class InstitutionService : IInstitutionService
    {
        private const string connectionString = "Server=.\\MSSQLSERVER05;Database=SchoolManagement;Trusted_Connection=True;";
        private readonly string _connectionString;

        public InstitutionService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool AddInstitution(Institution institution)
        {
           SqlConnection sqlCon = new (connectionString);

            string insertCommand = "InstitutionInsert";

            SqlCommand cmd = new ();
            cmd.Connection = sqlCon;
            cmd.CommandText = insertCommand;
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterName = new ();
            parameterName.ParameterName = "@Name";
            parameterName.SqlDbType = System.Data.SqlDbType.VarChar;
            parameterName.Direction = System.Data.ParameterDirection.Input;
            parameterName.SqlValue = institution.Name;
            cmd.Parameters.Add(parameterName);

            SqlParameter parameterEmail = new ();
            parameterEmail.ParameterName = "@Email";
            parameterEmail.SqlDbType = System.Data.SqlDbType.VarChar;
            parameterEmail.Direction = System.Data.ParameterDirection.Input;
            parameterEmail.SqlValue = institution.Email;
            cmd.Parameters.Add(parameterEmail);

            SqlParameter parameterState = new ();
            parameterState.ParameterName = "@State";
            parameterState.SqlDbType = System.Data.SqlDbType.VarChar;
            parameterState.Direction = System.Data.ParameterDirection.Input;
            parameterState.SqlValue = institution.State;
            cmd.Parameters.Add(parameterState);

            SqlParameter parameterCountry = new ();
            parameterCountry.ParameterName = "@Country";
            parameterCountry.SqlDbType = System.Data.SqlDbType.VarChar;
            parameterCountry.Direction = System.Data.ParameterDirection.Input;
            parameterCountry.SqlValue = institution.Country;
            cmd.Parameters.Add(parameterCountry);

            sqlCon.Open();
            int result = cmd.ExecuteNonQuery();
            sqlCon.Close();
            return true;
        }

        public List<Institution> GetAll()
        {
            List<Institution> institutions = new List<Institution>();

            SqlConnection sqlCon = new SqlConnection(connectionString);
            string insertCommand = "InstitutionGetAll";

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandText = insertCommand;
            sqlCom.CommandType = System.Data.CommandType.StoredProcedure;

            sqlCon.Open();
            SqlDataReader reader = sqlCom.ExecuteReader();

            while(reader.Read())
            {
                Institution institution = new Institution();

                institution.Id = reader.GetInt32(0);
                institution.Name = reader.GetString(1);
                institution.Email = reader.GetString(2);
                institution.State = reader.GetString(3);
                institution.Country = reader.GetString(4);

                institutions.Add(institution);
            }  

            return institutions;
        }

        public Institution GetById(int institutionId)
        {
            Institution institution = new Institution();

            SqlConnection sqlCon = new ();
            string insertCommand = "InstitutionGeById";

            SqlCommand sqlCom = new ();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandText = insertCommand;
            sqlCom.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameterId = new ();
            parameterId.ParameterName = "@Id";
            parameterId.SqlDbType = System.Data.SqlDbType.Int;
            parameterId.Direction = System.Data.ParameterDirection.Input;
            parameterId.SqlValue = institutionId;
            sqlCom.Parameters.Add(parameterId);

            sqlCon.Open();
            SqlDataReader reader = sqlCom.ExecuteReader();

            while(reader.Read())
            {
                institution.Id = reader.GetInt32(0);
                institution.Name = reader.GetString(1);
                institution.Email = reader.GetString(2);
                institution.State = reader.GetString(3);
                institution.Country = reader.GetString(4);
            }  
            return institution;

        }

        public bool UpdateInstitution(Institution institution)
        {
            SqlConnection sqlCon = new (connectionString);

            string insertCommand = "InstitutionUpdate";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlCon;
            cmd.CommandText = insertCommand;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameterId = new SqlParameter();
            parameterId.ParameterName = "@Id";
            parameterId.SqlDbType = System.Data.SqlDbType.Int;
            parameterId.Direction = System.Data.ParameterDirection.Input;
            parameterId.SqlValue = institution.Id;
            cmd.Parameters.Add(parameterId);

            SqlParameter parameterName = new SqlParameter();
            parameterName.ParameterName = "@Name";
            parameterName.SqlDbType = System.Data.SqlDbType.VarChar;
            parameterName.Direction = System.Data.ParameterDirection.Input;
            parameterName.SqlValue = institution.Name;
            cmd.Parameters.Add(parameterName);

            SqlParameter parameterEmail = new SqlParameter();
            parameterEmail.ParameterName = "@Email";
            parameterEmail.SqlDbType = System.Data.SqlDbType.VarChar;
            parameterEmail.Direction = System.Data.ParameterDirection.Input;
            parameterEmail.SqlValue = institution.Email;
            cmd.Parameters.Add(parameterEmail);

            SqlParameter parameterState = new SqlParameter();
            parameterState.ParameterName = "@State";
            parameterState.SqlDbType = System.Data.SqlDbType.VarChar;
            parameterState.Direction = System.Data.ParameterDirection.Input;
            parameterState.SqlValue = institution.State;
            cmd.Parameters.Add(parameterState);

            SqlParameter parameterCountry = new SqlParameter();
            parameterCountry.ParameterName = "@Country";
            parameterCountry.SqlDbType = System.Data.SqlDbType.VarChar;
            parameterCountry.Direction = System.Data.ParameterDirection.Input;
            parameterCountry.SqlValue = institution.Country;
            cmd.Parameters.Add(parameterCountry);

            sqlCon.Open();
            int result = cmd.ExecuteNonQuery();
            sqlCon.Close();
            return true;
        }
    }

    // public class institutionId
    // {
    // }
}