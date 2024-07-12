using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Globals
{
    public class Global
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["SalonManagerDB"].ConnectionString;

        public string msgRetornoClasse { get; set; }

        public Global() { }

        public DataTable CarregaDataTable(string procedure, SqlParameterCollection parameters)
        {
            msgRetornoClasse = "OK";

            DataTable dt = new DataTable();

            using (SqlConnection SQLConnection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(procedure, SQLConnection);
                    command.CommandType = CommandType.StoredProcedure;

                    foreach (SqlParameter parameter in parameters)
                    {
                        // Clona o parâmetro antes de adicioná-lo
                        command.Parameters.Add((SqlParameter)((ICloneable)parameter).Clone());
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    SQLConnection.Open();
                    adapter.Fill(dt);
                }
                catch (SqlException ex)
                {
                    msgRetornoClasse = "Erro ao conectar ao banco de dados: " + ex.Message;
                    return null;
                }
                finally
                {
                    SQLConnection.Close();
                }
            }

            return dt;
        }
    }
}
