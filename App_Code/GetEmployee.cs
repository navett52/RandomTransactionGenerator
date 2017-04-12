using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for GetEmployee
/// </summary>
public class GetEmployee {
    public GetEmployee() {
        //
        // TODO: Add constructor logic here
        //
    }

    public int RandomAvailableEmployee() {
        int emplID = 0;

        OpenConnection("GroceryStoreSimulator");

        try { reader.Close(); } catch { }
        comm = new SqlCommand("SELECT TOP 1 emp.EmplID FROM tEmpl emp JOIN tEmplHistory eh ON emp.EmplID = eh.EmplID JOIN tEmplStatus es ON eh.EmplStatusID = es.EmplStatusID WHERE es.CanWork = 1 ORDER BY NEWID()", conn);
        reader = comm.ExecuteReader();

        if (reader.HasRows) {
            while (reader.Read()) {
                emplID = (int)reader[0];
            }
        }

        return emplID;
    }

    private static SqlConnection conn;
    private static SqlDataReader reader;
    private static SqlCommand comm;

    private void OpenConnection(string connStrName) {
        System.Configuration.ConnectionStringSettings strConn;
        strConn = ReadConnectionString(connStrName);
        conn = new SqlConnection(strConn.ConnectionString);
        conn.Open();
    }

    private System.Configuration.ConnectionStringSettings ReadConnectionString(string connStrName) {
        string strPath;
        strPath = HttpContext.Current.Request.ApplicationPath + "/Web.config";
        System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(strPath);

        System.Configuration.ConnectionStringSettings connString = null;

        if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0) {
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings[connStrName];

            if (connString != null) {
                Console.WriteLine("connection string = \"{0}\"",
                    connString.ConnectionString);
            } else {
                Console.WriteLine("No connection string");
            }
        }
        return connString;
    }

}