using KpopZtation.Factory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace KpopZtation.Repository
{
    public class AlbumRepository
    {
        static DatabaseEntities1 db = SingletonDatabase.GetInstance();
        public static List<Album> GetAll()
        {
            return (from i in db.Albums select i).ToList();
        }

        public static List<Album> GetByID(int id)
        {
            return (from i in db.Albums where i.ArtistID == id select i).ToList();
        }
        public static List<Album> GetByAlbumID(int id)
        {
            return (from i in db.Albums where i.AlbumID == id select i).ToList();
        }

        public static Album GetAlbum(String name)
        {
            return (from i in db.Albums where name.Equals(i.AlbumName) select i).FirstOrDefault();
        }
        public static Album GetAlbumUsingID(int id)
        {
            return (from i in db.Albums where id == i.AlbumID select i).FirstOrDefault();
        }

        public static int GetIdNotUsed()
        {
            return db.Albums.OrderByDescending(i => i.AlbumID).First().AlbumID;
        }
        public static void CreateAlbum(int artistID, String name, String imgPath, int price, int stock, String description)
        {
            Album newAlbum= ArtistFactory.CreateAlbum(artistID, name, imgPath, price, stock, description);
            db.Albums.Add(newAlbum);
            db.SaveChanges();
        }

        public static void UpdateAlbum(String oldName, String newName, String oldImagePath, String imgPath, int price, int stock, String desc)
        {
            Album album = GetAlbum(oldName);

            File.Delete(oldImagePath);
            album.AlbumName = newName;
            album.AlbumImage = imgPath;
            album.AlbumDescription = desc;
            album.AlbumPrice = price;
            album.AlbumStock = stock;
            db.SaveChanges();
        }

        public static void DeleteAlbum(String name, String path)
        {
            Album album = GetAlbum(name);
            File.Delete(path);

            db.Albums.Remove(album);
            db.SaveChanges();
        }


    }
}