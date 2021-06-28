using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using System.Threading.Tasks;

namespace PayRoll
{
    class dbconnection
    {

        String conStr = "Data Source=DESKTOP-L7N98AO\\MARIMGK;Initial Catalog=PayRoll;Integrated Security=True";
        public SqlConnection connection;


        public SqlConnection CreateConnection()
        {

            connection = new SqlConnection(conStr);
            return connection;
        }

        public bool OpenConnection()
        {
            try
            {
                connection = CreateConnection();
                connection.Open();
                return true;


            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }


        private bool CloseConnection()
        {
            try
            {

                connection.Close();
                return true;


            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public void Executing(String query)
        {
            try
            {
                if (OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet LoadData(string Query) //get data using sql query
        {
            try
            {
                DataSet ds = new DataSet();
                if (OpenConnection())
                {

                    SqlCommand cmd = new SqlCommand(Query, connection);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }

                    CloseConnection();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
