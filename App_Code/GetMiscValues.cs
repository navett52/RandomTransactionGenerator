using dsLoyaltyTableAdapters;
using dsPricePerSellableUnitAsMarkedTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GetMiscValues
/// </summary>
public class GetMiscValues
{
    public GetMiscValues()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int GetLoyaltyID(int storeID)
    {
        tLoyaltyTableAdapter loyaltyTableAdapter = new tLoyaltyTableAdapter();
        dsLoyalty.tLoyaltyDataTable loyaltyDataTable = loyaltyTableAdapter.GetData(storeID);

        return Convert.ToInt32(loyaltyDataTable.Rows[0][0]);
    }

    public int GetPricePerSellableUnitAsMarked(int storeID, int productID)
    {
        tProductPriceHistTableAdapter productPriceHistTableAdapter = new tProductPriceHistTableAdapter();
        dsPricePerSellableUnitAsMarked.tProductPriceHistDataTable pricePerSellableUnitAsMarkedDataTable = productPriceHistTableAdapter.GetData(storeID, productID);

        return Convert.ToInt32(pricePerSellableUnitAsMarkedDataTable.Rows[0][0]);
    }
}