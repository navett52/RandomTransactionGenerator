/*
Created By Evan Tellep and Connor Tellep aka 'The Wonder Brothers'
Prof. Bill Nicholson
ASP.NET
4/12/2017
Desc: Grabs a random product ID based on a given store ID
Ref: Our awesome brains... and some of google and stack overflow
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using dsGetProductTableAdapters;
using System.Data;

/// <summary>
/// Class solely to contain a method to grab a random product ID based on a given store ID
/// </summary>
public class GetProduct
{
    /// <summary>
    /// Nothing to see here folks
    /// </summary>
    public GetProduct() { }

    /// <summary>
    /// Grabs a random product ID that is sold by the corresponding store of the store ID passed to the method.
    /// </summary>
    /// <param name="storeID">A store ID representing a store from GroceryStoreSimulatorWebFormLogin db</param>
    /// <returns>A random product ID that is sold by the given store</returns>
    public int RandomProductAvailableAtStore(int storeID)
    {
        dsGetProductTableAdapters.getRandomProductSoldAtGivenStore productAdapter = new dsGetProductTableAdapters.getRandomProductSoldAtGivenStore();
        productAdapter.GetRandomProductFromStore(storeID);
        return (int)productAdapter.GetRandomProductFromStore(storeID);
    }
}