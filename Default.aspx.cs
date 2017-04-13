/*
 * Group Project for IT3047
 * Bill Nicholson
 * nicholdw@ucmauil.uc.edu
 * 
 * /***********************************************************************************************************************************************************************************************
 * Assignment 11
 * Jake Reilman (reilmajb@mail.uc.edu) and Justin  (polleyaw@mail.uc.edu) Tom Martin ()
 * IT3047C Web Server App Dev
 * Class Project to build a website that generates a random transaction and adds it to the GroceryStore database.
 * Due Date: 4/12/2017
 *
 **********************************************************************************************************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
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
    }

    protected void btnAddTrans_Click(object sender, EventArgs e)
    {
        AddTransaction();
    }
}