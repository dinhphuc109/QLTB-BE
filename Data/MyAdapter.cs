using NETCORE3.Infrastructure;
using System;
using System.Data;
using System.Data.SqlClient;

namespace NETCORE3.Data
{
    public class MyAdapter: IMyAdapter
    {

        private readonly string connectionString;
        private SqlConnection connection;

        public MyAdapter(string connectionString)
        {
            this.connectionString = connectionString;
            connection = new SqlConnection(connectionString);
        }

        public bool TestConnection()
        {
            try
            {
                connection.Open();
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        public void Dispose()
        {
            if (connection != null)
            {
                connection.Dispose();
                connection = null;
            }
        }
    }
}
