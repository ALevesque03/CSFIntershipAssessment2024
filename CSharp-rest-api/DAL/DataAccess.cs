using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Types;

namespace DAL
{
    //This is my generic data access class for retreiving and pushing data. Function names are mostly self eplanatory
    public class DataAccess
    {
        #region Fields

        private readonly string connectionString;

        #endregion

        #region Constructors

        //This is where I set the database connection string which we will be using MSSQL
        public DataAccess()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            connectionString = builder.Build().GetConnectionString("CSFAssessmentConnStr");
        }

        #endregion

        #region Public Methods

        public async Task<DataTable> ExecuteAsync(string cmdText, List<ParmStruct>? parms = null, CommandType cmdType = CommandType.StoredProcedure)
        {
            DataTable dt = new();
            SqlCommand cmd = CreateCommand(cmdText, cmdType, parms);

            using (cmd.Connection)
            {
                SqlDataAdapter da = new(cmd);

                await Task.Run(() => da.Fill(dt));
            }

            return dt;
        }

        public DataTable Execute(string cmdText, List<ParmStruct>? parms = null, CommandType cmdType = CommandType.StoredProcedure)
        {
            DataTable dt = new();
            SqlCommand cmd = CreateCommand(cmdText, cmdType, parms);

            using (cmd.Connection)
            {
                SqlDataAdapter da = new(cmd);

                da.Fill(dt);
            }

            return dt;
        }

        public async Task<object> ExecuteScalarAsync(string cmdText, List<ParmStruct>? parms = null, CommandType cmdType = CommandType.StoredProcedure)
        {
            object? retVal;
            SqlCommand cmd = CreateCommand(cmdText, cmdType, parms);

            using (cmd.Connection)
            {
                await cmd.Connection.OpenAsync();
                retVal = await cmd.ExecuteScalarAsync();
            }

            return retVal;
        }

        public object ExecuteScalar(string cmdText, List<ParmStruct>? parms = null, CommandType cmdType = CommandType.StoredProcedure)
        {
            object retVal;
            SqlCommand cmd = CreateCommand(cmdText, cmdType, parms);

            using (cmd.Connection)
            {
                cmd.Connection.Open();
                retVal = cmd.ExecuteScalar();
            }

            return retVal;
        }

        public async Task<int> ExecuteNonQueryAsync(string cmdText, List<ParmStruct>? parms = null, CommandType cmdType = CommandType.StoredProcedure)
        {
            int rowsAffected = 0;
            SqlCommand cmd = CreateCommand(cmdText, cmdType, parms);

            using (cmd.Connection)
            {
                await cmd.Connection.OpenAsync();
                rowsAffected = await cmd.ExecuteNonQueryAsync();

                UnloadParms(parms, cmd);
            }

            return rowsAffected;
        }

        public int ExecuteNonQuery(string cmdText, List<ParmStruct>? parms = null, CommandType cmdType = CommandType.StoredProcedure)
        {
            int rowsAffected = 0;
            SqlCommand cmd = CreateCommand(cmdText, cmdType, parms);

            using (cmd.Connection)
            {
                cmd.Connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();

                UnloadParms(parms, cmd);
            }

            return rowsAffected;
        }

        #endregion

        #region Private Methods
        private SqlCommand CreateCommand(string cmdText, CommandType cmdType, List<ParmStruct>? parms)
        {
            SqlConnection conn = new(connectionString);

            SqlCommand cmd = new(SQLCleaner(cmdText), conn)
            {
                CommandType = cmdType
            };

            if (parms != null)
            {
                foreach (ParmStruct p in parms)
                {
                    cmd.Parameters.Add(p.Name, p.DataType, p.Size).Value = p.Value;
                    cmd.Parameters[p.Name].Direction = p.Direction;
                }
            }
            return cmd;
        }

        private void UnloadParms(List<ParmStruct> parms, SqlCommand cmd)
        {
            if (parms != null)
            {
                for (int i = 0; i <= parms.Count - 1; i++)
                {
                    ParmStruct p = parms[i];
                    p.Value = cmd.Parameters[i].Value;
                    parms[i] = p;
                }
            }
        }

        private string SQLCleaner(string sql)
        {
            while (sql.Contains("  "))
                sql = sql.Replace("  ", " ");

            return sql.Replace(Environment.NewLine, "");
        }

        #endregion
    }
}