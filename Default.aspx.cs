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
    string date = "";
    GetStore getstore = new GetStore();
    GetEmployee getempl = new GetEmployee();
    GetProduct getProduct = new GetProduct();
    GetCoupon getCoupon = new GetCoupon();
    protected void Page_Load(object sender, EventArgs e)
    {
        calError.InnerText = "";

        if (!IsPostBack)
        {

        }
    }

    private void AddTransaction()
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("LoyaltyID", txtLoyaltyID.Text));
            cmd.Parameters.Add(new SqlParameter("DateOfTransaction", calDate.SelectedDate));
            cmd.Parameters.Add(new SqlParameter("TimeOfTransaction", txtTimeOfTransaction.Text));
            cmd.Parameters.Add(new SqlParameter("TransactionTypeID", txtTransactionTypeID.Text));
            cmd.Parameters.Add(new SqlParameter("StoreID", txtStoreID.Text));
            cmd.Parameters.Add(new SqlParameter("EmplID", txtEmployeeID.Text));
            cmd.Parameters.Add(new SqlParameter("ProductID", txtProductID.Text));
            cmd.Parameters.Add(new SqlParameter("Qty", txtQty.Text));
            cmd.Parameters.Add(new SqlParameter("PricePerSellableUnitAsMarked", txtPricePerSellableUnitAsMarked.Text));
            cmd.Parameters.Add(new SqlParameter("PricePerSellableUnitToTheCustomer", txtPricePerSellableUnitToCustomer.Text));
            cmd.Parameters.Add(new SqlParameter("TransactionComment", ""));
            cmd.Parameters.Add(new SqlParameter("TransactionDetailComment", ""));
            cmd.Parameters.Add(new SqlParameter("couponDetailID", txtCouponDetailID.Text));
            cmd.Parameters.Add(new SqlParameter("TransactionID", ""));
            cmd.CommandText = "spAddTransactionAndDetail";
            openConnection();
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();
            GenerateTransaction();
        }
        catch (Exception e)
        {
            calError.InnerText = e.Message;
        }
        
    }

    protected void btnGenerateTrans_Click(object sender, EventArgs e)
    {
        GenerateTransaction();
    }

    protected void GenerateTransaction()
    {
        Random random = new Random();
        GetMiscValues values = new GetMiscValues();
        txtStoreID.Text = Convert.ToString(getstore.randomOpenStore());
        txtLoyaltyID.Text = Convert.ToString(values.GetRandomLoyaltyID());
        txtTransactionTypeID.Text = Convert.ToString(values.GetRandomTransactionTypeID());
        txtQty.Text = Convert.ToString(random.Next(1, 10000));
        txtEmployeeID.Text = Convert.ToString(getempl.RandomAvailableEmployee());
        txtProductID.Text = Convert.ToString(getProduct.RandomProductAvailableAtStore(Convert.ToInt32(txtStoreID.Text)));
        txtCouponID.Text = Convert.ToString(getCoupon.RandomCurrentCouponForProduct(Convert.ToInt32(txtProductID.Text)));
        txtPricePerSellableUnitAsMarked.Text = Convert.ToString(values.GetPricePerSellableUnitAsMarked(Convert.ToInt32(txtStoreID.Text), Convert.ToInt32(txtProductID.Text)));
        txtPricePerSellableUnitToCustomer.Text = txtPricePerSellableUnitAsMarked.Text;
        txtCouponDetailID.Text = Convert.ToString(values.GetCouponDetailID(Convert.ToInt32(txtCouponID.Text)));
        btnAddTrans.Enabled = true;
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