/*
 * Group Project for IT3047
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 * 
 * /***********************************************************************************************************************************************************************************************
 * Assignment 11
 * RIchard McDonald (mcdonarf@mail.uc.edu) and Matthew Frank (frankmj@mail.uc.edu)
 * IT3047C Web Server App Dev
 * Class Project to build a website that generates a random transaction and adds it to the GroceryStore database.
 * Due Date: 4/12/2017
 *
 **********************************************************************************************************************************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for GetCoupon
/// </summary>
public class GetCoupon
{
    private static SqlConnection conn;
    private static SqlCommand comm;
    private static SqlDataReader reader;
    private void openConnection()
    {
        try
        {
            // Creates a connection to the database that can be opened or closed by utilizing the connection string.
            conn = new System.Data.SqlClient.SqlConnection(GetConnectionString("GroceryStoreSimulator").ConnectionString);
            // Opens the connection to execute queries on the database.
            conn.Open();
        }
        // Eats any exceptions.
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
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

    public int RandomCurrentCouponForProduct(int productID)
    {
        //open connection
        openConnection();
        int couponID = 0;
        //execute sql command       
        comm = new SqlCommand("select top 1 cp.CouponID from tCoupon cp join tCouponDetail cd on cp.CouponID = cd.CouponID where cd.ProductID = " + productID + " order by NEWID()", conn);
        try { reader.Close(); } catch (Exception ex) { }
        reader = comm.ExecuteReader();
        while (reader.Read())
        {
            couponID = reader.GetInt32(0);

        }
        //return sql response
        return couponID;
    }
}