/*
 * Group Project for IT3047
 * Bill Nicholson
 * nicholdw@ucmauil.uc.edu
 * 
 * /***********************************************************************************************************************************************************************************************
 * Assignment 11
 * Jake Reilman (reilmajb@mail.uc.edu) and Justin Meyer (meyer3js@mail.uc.edu) Tom Martin (marti2t5@mail.uc.edu)
 * IT3047C Web Server App Dev
 * This class gathers the various values that is required to run the AddTransactionAndDetail stored procedure that was not listed in the Assignment Document
 * Due Date: 4/12/2017
 *
 **********************************************************************************************************************************************************************************************/

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
    /// <summary>
    /// Gets a loyaltyID specific to a store
    /// </summary>
    /// <param name="storeID">The storeID that is passed to only get loyaltyID's attached to this store</param>
    /// <returns>Returns a random loyaltyID attached to the storeID passed</returns>
    public int GetRandomLoyaltyID(int storeID)
    {
        tLoyaltyTableAdapter loyaltyTableAdapter = new tLoyaltyTableAdapter();
        dsLoyalty.tLoyaltyDataTable loyaltyDataTable = loyaltyTableAdapter.GetData(storeID);

        return Convert.ToInt32(loyaltyDataTable.Rows[0][0]);
    }
    
    /// <summary>
    /// Gets the price history for a specific product at a specific store
    /// </summary>
    /// <param name="storeID">The storeID to check the price for</param>
    /// <param name="productID">The specific product to check the price</param>
    /// <returns>Returns the price for a specific product at a specific store</returns>
    public int GetPricePerSellableUnitAsMarked(int storeID, int productID)
    {
        tProductPriceHistTableAdapter productPriceHistTableAdapter = new tProductPriceHistTableAdapter();
        dsPricePerSellableUnitAsMarked.tProductPriceHistDataTable pricePerSellableUnitAsMarkedDataTable = productPriceHistTableAdapter.GetData(storeID, productID);

        return Convert.ToInt32(pricePerSellableUnitAsMarkedDataTable.Rows[0][0]);
    }

    public int GetCouponDetailID(int couponID, int productID)
    {
        return 0;
    }

    public int GetRandomTransactionTypeID()
    {
        return 0;
    }


}