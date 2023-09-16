using KpopZtation.Factory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace KpopZtation.Repository
{
    public class ArtistRepository
    {
        static DatabaseEntities1 db = SingletonDatabase.GetInstance();

        public static List<Artist> GetAll()
        {
            return (from i in db.Artists select i).ToList();
        }

        public static Artist GetArtist(String name)
        {
            return (from i in db.Artists where name.Equals(i.ArtistName) select i).FirstOrDefault();
        }

        public static int GetIdNotUsed()
        {
            return db.Artists.OrderByDescending(i => i.ArtistID).First().ArtistID;
        }
        public static void CreateArtist(String name, String imgPath)
        {
            Artist newArtist = ArtistFactory.CreateArtist(name, imgPath);
            db.Artists.Add(newArtist);
            db.SaveChanges();
        }

        public static void UpdateArtist(String oldName, String newName, String imgPath, String oldImagePath)
        {
            Artist artist = GetArtist(oldName);

            File.Delete(oldImagePath);
            artist.ArtistName = newName;
            artist.ArtistImage = imgPath;
            db.SaveChanges();
        }

        public static void DeleteArtist(String name, String path)
        {
            Artist artist = GetArtist(name);
            File.Delete(path);
         
            db.Artists.Remove(artist);
            db.SaveChanges();
        }

    }
}