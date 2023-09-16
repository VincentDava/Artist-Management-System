using KpopZtation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Factory
{
    public class ArtistFactory
    {
        public static Artist CreateArtist(String name, String imgPath)
        {
            int id = Convert.ToInt32(ArtistRepository.GetIdNotUsed() + 1);

            Artist artist = new Artist
            {
                ArtistID = id,
                ArtistName = name,
                ArtistImage = imgPath
            };
            return artist;
        }
        public static Album CreateAlbum(int artistID, String name, String imgPath, int price, int stock, String description)
        {
            int albumID = Convert.ToInt32(AlbumRepository.GetIdNotUsed() + 1);

            Album album = new Album
            {
                AlbumID = albumID,
                ArtistID = artistID,
                AlbumName = name,
                AlbumImage = imgPath,
                AlbumPrice = price,
                AlbumStock = stock,
                AlbumDescription = description
            };
            return album;
        }
    }
}