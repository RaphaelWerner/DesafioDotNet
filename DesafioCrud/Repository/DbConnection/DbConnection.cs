using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DesafioCrud.Repository.DbConnection
{
    public class DbConnection
    {
        protected SqlConnection connection;
        protected SqlCommand command;
        protected SqlDataReader reader;

        protected void OpenConnection()
        {
            try
            {
                connection = new SqlConnection("Data Source=localhost;Initial Catalog=DesafioCrud;Integrated Security=True");
                connection.Open();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao abrir a conexão: " + e.Message);
            }
        }
        protected void CloseConnection()
        {
            try
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao fechar a conexão: " + e.Message);
            }
        }
    }
}