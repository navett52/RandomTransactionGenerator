/*
 * Group Project for IT3047
 * Bill Nicholson
 * nicholdw@ucmauil.uc.edu
 * 
 * /***********************************************************************************************************************************************************************************************
 * Assignment 11
 * Jake Reilman (reilmajb@mail.uc.edu) and Justin Meyer (meyer3js@mail.uc.edu) Tom Martin (marti2t5@mail.uc.edu)
 * IT3047C Web Server App Dev
 * Class Project to build a website that generates a random transaction and adds it to the GroceryStore database.
 * Due Date: 4/12/2017
 *
 **********************************************************************************************************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    private static System.Data.SqlClient.SqlConnection connection;
    private static SqlCommand command;
    private static SqlDataReader reader;
    int storeID;
    int emplID;
    int productID;
    int couponID;
    string date = "";
    GetStore getstore = new GetStore();
    GetEmployee getempl = new GetEmployee();
    GetProduct getProduct = new GetProduct();
    GetCoupon getCoupon = new GetCoupon();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

        }
    }

    private void AddTransaction()
    {
        Random random = new Random();
        int qty = random.Next();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.Add(new SqlParameter("LoyaltyID", storeID));
        //cmd.Parameters.Add(new SqlParameter("DateOfTransaction", txtStoreNumber.Text.Trim()));
        //cmd.Parameters.Add(new SqlParameter("TimeOfTransaction", txtStoreNumber.Text.Trim()));
        //cmd.Parameters.Add(new SqlParameter("TransationTypeID", storeID));
        //cmd.Parameters.Add(new SqlParameter("StoreID", storeID));
        //cmd.Parameters.Add(new SqlParameter("EmplID", emplID));
        //cmd.Parameters.Add(new SqlParameter("Qty", ));
        //cmd.Parameters.Add(new SqlParameter("PricePerSellableUnitAsMarked", storeID));
        //cmd.Parameters.Add(new SqlParameter("PricePerSellableUnitToTheCustomer", storeID));
        //cmd.Parameters.Add(new SqlParameter("TransactionComment", storeID));
        //cmd.Parameters.Add(new SqlParameter("TransactionDetail", storeID));
        //cmd.Parameters.Add(new SqlParameter("CouponDetailID", storeID));
        //cmd.Parameters.Add(new SqlParameter("TransactionID", storeID));
        //cmd.CommandText = "AddTransactionAndDetail";
        cmd.ExecuteNonQuery();
    }

    protected void calDate_SelectionChanged(object sender, EventArgs e)
    {
        date = calDate.ToString();
    }

    protected void btnGenerateTrans_Click(object sender, EventArgs e)
    {
        storeID = getstore.randomOpenStore();
        emplID = getempl.RandomAvailableEmployee();
        productID = getProduct.RandomProductAvailableAtStore(storeID);
        couponID = getCoupon.RandomCurrentCouponForProduct(productID);
        //Get Quantity
        //Get TransactionTypeID
        //Get PricePerSellableUnitAsMarked
        //Make PricePerSellableUnitToCustomer = PricePerSellableUnitAsMarked
        //Make TransactionComment empty
        //Make TransactionDetail empty
        //Get CouponDetailID
        //TransactionID is return value, should be able to keep empty
    }

    protected void btnAddTrans_Click(object sender, EventArgs e)
    {
        AddTransaction();
    }
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