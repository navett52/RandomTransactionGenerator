using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using dsGetProductTableAdapters;
using System.Data;

/// <summary>
/// Summary description for GetProduct
/// </summary>
public class GetProduct
{
    public GetProduct()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int RandomProductAvailableAtStore(int storeID)
    {
        dsGetProductTableAdapters.getRandomProductSoldAtGivenStore productAdapter = new dsGetProductTableAdapters.getRandomProductSoldAtGivenStore();
        

        return 0;
    }
}