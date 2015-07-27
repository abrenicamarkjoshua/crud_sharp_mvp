using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using System.Data;
namespace crud_csharp_mvp_customDAL {
    public class dbContextCustom  : IDisposable{
        public string connectionName{get;set;}
        protected OdbcConnection con;
        protected OdbcDataAdapter adp;
        public int lastInsertedId { get; private set; }
        public DataTable result { get; protected set; }
        public dbContextCustom(string connectionName)
        {
            //sa EF kasi "name = mysqlCon", here, dapat "mysqlCon" lang. so we adjust it here instead duon sa top level.

            connectionName = connectionName.Replace("name = ", "");
            connectionName = connectionName.Replace("name =", "");
            connectionName = connectionName.Replace("name= ", "");
            connectionName = connectionName.Replace("name=", "");
            
            connectionName.Trim();
            this.connectionName = connectionName;
            string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            con = new OdbcConnection(_connectionString);
            con.Open();
            con.Close();
        }
        protected void query(string sql)
        {
            con.Open();
            OdbcCommand command = new OdbcCommand(sql, con);
            adp = new OdbcDataAdapter(command);
            result = new DataTable();
            adp.Fill(result);
            if (sql.Contains("INSERT INTO"))
            {
                command.CommandText = "select last_insert_id()"; //mysql's retrieval of last insert id
                lastInsertedId = Convert.ToInt32(command.ExecuteScalar());
            }
            else
            {
                lastInsertedId = 0;
            }
            con.Close();
        }
        protected void query(string sql, Dictionary<string, string> parameters)
        {
            con.Open();
            OdbcCommand command = new OdbcCommand(sql, con);
            foreach(KeyValuePair<string, string> _params in parameters){
                command.Parameters.AddWithValue(_params.Key, _params.Value);
            }
            adp = new OdbcDataAdapter(command);
            result = new DataTable();
            adp.Fill(result);
            con.Close();
        }

        public void Dispose()
        {
            con.Dispose();
            adp.Dispose();
            result.Dispose();
        }

        
    }
}
