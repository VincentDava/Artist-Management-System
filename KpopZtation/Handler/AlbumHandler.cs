using KpopZtation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Handler
{
    public class AlbumHandler
    {
        public static List<Album> GetAll()
        {
            return AlbumRepository.GetAll();
        }
        
        public static Album GetAlbum(int id)
        {
            return AlbumRepository.GetAlbumUsingID(id);
        }

        public static List<Album> GetByID(int id)
        {
            return AlbumRepository.GetByID(id);
        }
        public static void DeleteAlbum(String name, String path)
        {
            AlbumRepository.DeleteAlbum(name, path);
        }

        public static String GetAlbumPath(String name)
        {
            Album album = AlbumRepository.GetAlbum(name);
            if (album == null)
            {
                return "";
            }
            return album.AlbumImage;
        }

        public static int GetAlbumID(String name)
        {
            Album album = AlbumRepository.GetAlbum(name);
            if (album == null)
            {
                return -1;
            }
            return album.AlbumID;
        }

        public static int GetAlbumStock(String name)
        {
            Album album = AlbumRepository.GetAlbum(name);
            if (album == null)
            {
                return -1;
            }
            return (int)album.AlbumStock;
        }

        public static Album GetAlbumUsingID(int id)
        {
            return AlbumRepository.GetAlbumUsingID(id);
        }

        public static List<Album> GetOneByName(String name)
        {
            Album album = AlbumRepository.GetAlbum(name);
            return AlbumRepository.GetByAlbumID(album.AlbumID);
        }
    }
}