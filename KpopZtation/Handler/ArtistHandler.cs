using KpopZtation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Handler
{
    public class ArtistHandler
    {
        public static List<Artist> GetAll()
        {
            return ArtistRepository.GetAll();
        }

        public static String GetArtistName(String name)
        {
            Artist artist = ArtistRepository.GetArtist(name);
            if(artist == null)
            {
                return "";
            }
            return artist.ArtistName;
        }

        public static int GetArtistID(String name)
        {
            Artist artist = ArtistRepository.GetArtist(name);
            if (artist == null)
            {
                return -1;
            }
            return artist.ArtistID;
        }

        public static String GetArtistPath(String name)
        {
            Artist artist = ArtistRepository.GetArtist(name);
            if (artist == null)
            {
                return "";
            }
            return artist.ArtistImage;
        }

        public static void DeleteArtist(String name, String path)
        {
            ArtistRepository.DeleteArtist(name, path);
        }
        

    }
}