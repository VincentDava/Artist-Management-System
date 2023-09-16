using KpopZtation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Handler
{
    public class PurchaseHandler
    {
        public static List<Cart> GetAllToList()
        {
            return PurchaseRepository.GetAllToList();
        }

        public static int GetQuantity(int customerID)
        {
            return PurchaseRepository.GetCartQuantity(customerID);
        }

        public static Cart GetCart(int customerID, int albumID)
        {
            return PurchaseRepository.GetCart(customerID, albumID);
        }

        public static List<DisplayPurchase> GetCartView()
        {
            return PurchaseRepository.GetCartView();
        }

        public static List<DisplayPurchase> GetCartViewWithID(int customerID)
        {
            return PurchaseRepository.GetCartViewWithID(customerID);
        }

        public static void DeleteCart(int customerID, int albumID)
        {
            PurchaseRepository.DeleteCart(customerID, albumID);
        }

        public static String GetCurrentDate()
        {
            String currentDateTime = DateTime.Now.ToString("dd MMMM yyyy");
            return currentDateTime;
        }

        public static int GetIdNotUsed()
        {
            return PurchaseRepository.GetIdNotUsed();
        }

        public static void CreateTransaction(int customerID)
        {
            PurchaseRepository.CreateTransaction(customerID);
        }

        public static List<DisplayTransaction> GetTrWithName(String customerName)
        {
            return PurchaseRepository.GetTrWithName(customerName);
        }
        public static List<TransactionHeader> getTransaction()
        {
            return PurchaseRepository.getTransactionData();
        }
    }
}