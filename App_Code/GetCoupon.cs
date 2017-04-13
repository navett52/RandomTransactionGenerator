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
    private ConnectionStringSettings ReadConnectionString()
    {
        String strPath;
        strPath = HttpContext.Current.Request.ApplicationPath + "/web.config";
        Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(strPath);

        ConnectionStringSettings connString = null;
        if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
        {
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["GroceryStoreSimulatorConnectionString"];
        }
        return connString;
    }

    public int RandomCurrentCouponForProduct(int productID)
    {
        int couponID = 0;
        GetProduct product = new GetProduct();
        GetStore store = new GetStore();
        productID = product.RandomProductAvailableAtStore(store.randomOpenStore());
        comm = new SqlCommand("select top 1 cp.CouponID  from tCoupon cp join tCouponDetail cd on cp.CouponID = cd.CouponID where cd.ProductID = " + productID + " order by NEWID()", conn);
        try { reader.Close(); } catch (Exception ex) { }
        reader = comm.ExecuteReader();
        while (reader.Read())
        {
            couponID = reader.GetInt32(0);

        }
        return couponID;
    }
}