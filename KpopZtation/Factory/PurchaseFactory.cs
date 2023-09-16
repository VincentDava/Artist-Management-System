using KpopZtation.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Factory
{
    public class PurchaseFactory
    {

        public static Cart CreateCart(int customerID, int albumID, int quantity)
        {
            Cart cart = new Cart
            {
                CustomerID = customerID,
                AlbumID = albumID,
                Quantity = quantity
            };
            return cart;
        }

        public static TransactionHeader CreateTransactionHeader(int customerID)
        {
            int transactionID = PurchaseHandler.GetIdNotUsed() + 1;
            String date = PurchaseHandler.GetCurrentDate();

            TransactionHeader header = new TransactionHeader
            {
                TransactionID = transactionID,
                CustomerID = customerID,
                TransactionDate = date
            };
            return header;
        }

        public static TransactionDetail CreateTransactionDetail(int transactionID, int albumID, int quantity)
        {
            TransactionDetail detail = new TransactionDetail
            {
                TransactionID = transactionID,
                AlbumID = albumID,
                Qty = quantity
            };
            return detail;
        }
    }
}