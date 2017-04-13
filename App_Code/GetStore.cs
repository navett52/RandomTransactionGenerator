/*
 * Group Project for IT3047
 * Bill Nicholson
 * nicholdw@ucmauil.uc.edu
 * 
 * /***********************************************************************************************************************************************************************************************
 * Assignment 11
 * Adam Ralston (ralstoat@mail.uc.edu) and Andrew Polley (polleyaw@mail.uc.edu)
 * IT3047C Web Server App Dev
 * Class Project to build a website that generates a random transaction and adds it to the GroceryStore database.
 * Due Date: 4/12/2017
 *
 **********************************************************************************************************************************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Provides a method that returns a random open store.
/// </summary>
public class GetStore
{
    private static SqlConnection connection;
    private static SqlCommand command;
    private static SqlDataReader reader;

    public GetStore()
    {
    }
     
    public int randomOpenStore()
    {

        // Opens the connection to the database.
        openConnection();

        // Defines the query.
        string query = "select top 1 st.storeId, store from tStore st join tStoreHistory sh on st.StoreID = sh.StoreID join tStoreStatus ss on sh.StoreStatusID = ss.StoreStatusID where ss.IsOpenForBusiness = 1 order by NEWID();";

        // Stores the results of the query.
        int id = 0;

        // Establishes the command for the given query on the connection.
        command = new SqlCommand(query, connection);

        // Attempts to read from the database.
        try
        {
            // Reads from the database.
            reader = command.ExecuteReader();

            // Loops through all items that match the query in the database.
            while (reader.Read())
            {
                // Stores the returns.
                id = reader.GetInt32(0);
            }

            // Attempts to close the reader.
            try { reader.Close(); }
            // Eats any exceptions if there is an issue closing the reader.
            catch (Exception ex)
            {
            }
        }
        // Eats any exceptions if there was an issue reading from the database.
        catch (Exception ex)
        {

        }
        return id;
    }


    // Defines the method to open a connection to the database.
    private void openConnection()
    {
        try
        {
            // Creates a connection to the database that can be opened or closed by utilizing the connection string.
            connection = new System.Data.SqlClient.SqlConnection(GetConnectionString("GroceryStoreSimulator").ConnectionString);
            // Opens the connection to execute queries on the database.
            connection.Open();
        }
        // Eats any exceptions.
        catch (Exception ex)
        {

        }
    }

    // Defines the method to obtain the connection string from the web.config file.
    private System.Configuration.ConnectionStringSettings GetConnectionString(string nameOfString)
    {
        String path;
        // Establishes the path to the file.
        path = "/Web.config";
        // Obtains the connection string.
        System.Configuration.Configuration webConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(path);
        // Returns the connection string.
        return webConfig.ConnectionStrings.ConnectionStrings[nameOfString];
    }
}