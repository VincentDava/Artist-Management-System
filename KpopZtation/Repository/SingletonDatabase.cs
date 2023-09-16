using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Repository
{
    public class SingletonDatabase
    {
        private static DatabaseEntities1 db = null;
        private SingletonDatabase()
        {

        }

        public static DatabaseEntities1 GetInstance()
        {
            if(db == null)
            {
                db = new DatabaseEntities1();
            }
            return db;
        }
    }
}