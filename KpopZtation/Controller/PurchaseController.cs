using KpopZtation.Handler;
using KpopZtation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Controller
{
    public class PurchaseController
    {
        private static String CheckQuantity(int quantity, int albumID)
        {
            Album album = AlbumHandler.GetAlbumUsingID(albumID);
            if(quantity == 0)
            {
                return "Please enter a number above 0";
            }
            else if (quantity > album.AlbumStock)
            {
                return "Not enough stock";
            }
            return "";
        }

        public static String Checker(int customerID, int albumID, int quantity)
        {
            String response = CheckQuantity(quantity, albumID);
            if(response != "")
            {
                return response;
            }
            PurchaseRepository.CreateCart(customerID, albumID, quantity);

            return "Added items to cart";
        }

    }
}