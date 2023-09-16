using KpopZtation.Factory;
using KpopZtation.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Repository
{
    public class PurchaseRepository
    {
        static DatabaseEntities1 db = SingletonDatabase.GetInstance();

        public static List<Cart> GetAllToList()
        {
            return (from i in db.Carts select i).ToList();
        }

        public static void CreateCart(int customerID, int albumID, int quantity)
        {
            Cart purchases = PurchaseFactory.CreateCart(customerID, albumID, quantity);
            db.Carts.Add(purchases);
            db.SaveChanges();
        }

        public static Cart GetCart(int customerID, int albumID)
        {
            return (from i in db.Carts where i.CustomerID == customerID && i.AlbumID == albumID select i).FirstOrDefault();
        }

        public static List<Cart> GetCartWithID(int customerID)
        {
            return (from i in db.Carts where i.CustomerID == customerID select i).ToList();
        }

        public static int GetCartQuantity(int customerID)
        {
            return (from i in db.Carts where i.CustomerID == customerID select i.CustomerID).FirstOrDefault();
        }

        public static List<DisplayPurchase> GetCartView()
        {
            return (from i in db.DisplayPurchases select i).ToList();
        }

        public static List<DisplayPurchase> GetCartViewWithID(int customerID)
        {
            return (from i in db.DisplayPurchases where i.CustomerID == customerID select i).ToList();
        }

        public static void DeleteCart(int customerID, int albumID)
        {
            Cart deleteCart = GetCart(customerID, albumID);
            db.Carts.Remove(deleteCart);
            db.SaveChanges();
        }
        public static int GetIdNotUsed()
        {
            if (db.TransactionHeaders.Count() == 0)
            {
                return 0;
            }
            return db.TransactionHeaders.OrderByDescending(i => i.TransactionID).First().TransactionID;
        }

        private static TransactionHeader CreateTransactionHeader(int customerID)
        {
            TransactionHeader header = PurchaseFactory.CreateTransactionHeader(customerID);
            db.TransactionHeaders.Add(header);
            db.SaveChanges();
            return header;
        }
        private static void CreateTransactionDetail(int transactionID, int albumID, int quantity)
        {
            TransactionDetail detail = PurchaseFactory.CreateTransactionDetail(transactionID, albumID, quantity);
            db.TransactionDetails.Add(detail);
            db.SaveChanges();
        }

        private static void DeleteCartOfCustomer(int customerID)
        {
            List<Cart> carts = GetCartWithID(customerID);
            foreach (var items in carts)
            {
                db.Carts.Remove(items);
            }
            db.SaveChanges();
        }

        public static void CreateTransaction(int customerID)
        {
            TransactionHeader header = CreateTransactionHeader(customerID);
            int transactionID = header.TransactionID;
            List<Cart> carts = GetCartWithID(customerID);
            foreach(var items in carts)
            {
                CreateTransactionDetail(transactionID, items.AlbumID, items.Quantity);
            }
            DeleteCartOfCustomer(customerID);
        }
        
        public static List<DisplayTransaction> GetTrWithName(String customerName)
        {
            return (from i in db.DisplayTransactions where customerName.Equals(i.CustomerName) select i).ToList();
        }
        public static List<TransactionHeader> getTransactionData()
        {
            return db.TransactionHeaders.ToList();
        }

    }
}