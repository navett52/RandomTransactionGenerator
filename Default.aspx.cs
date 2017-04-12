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
            storeID = getstore.RandomOpenStore();
            emplID = getempl.RandomAvailableEmployee();
    }

    protected void btnAddTrans_Click(object sender, EventArgs e)
    {

    }
}