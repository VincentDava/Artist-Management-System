using KpopZtation.Handler;
using KpopZtation.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace KpopZtation.Controller
{
    public class ArtistController
    {
        private static String CheckName(String name)
        {
            if(name == "")
            {
                return "Please enter a name";
            }
            else if(ArtistHandler.GetArtistName(name) != "")
            {
                return "Artist already in database";
            }
            return "";
        }

        private static String CheckFile(HttpPostedFile file)
        {
            int maxFileSize = 2 * 1024 * 1024;
            String[] extensions = { "image/png", "image/jpg", "image/jpeg", "image/jfif" };

            if (file.ContentLength > maxFileSize)
            {
                return "File size must be under 2 MB";
            }
            foreach(String extension in extensions)
            {
                if(extension == file.ContentType)
                {
                    return "";
                }
            }
            return "Format of image must be .png, .jpg, .jpeg, or .jfif";
        }

        public static String Checker(String name, String path, HttpPostedFile file)
        {
            String response = CheckName(name);
            
            if(response != "")
            {
                return response;
            }
            response = CheckFile(file);
            if(response != "")
            {
                return response;
            }

            ArtistRepository.CreateArtist(name, path);

            return "Insert Artist Successful";
        }

        private static String CheckNameForUpdate(String newName, String oldName)
        {
            if (newName == "")
            {
                return "Please enter a name";
            }
            else if (ArtistHandler.GetArtistID(newName) != -1 && ArtistHandler.GetArtistID(oldName) != ArtistHandler.GetArtistID(newName))
            {
                return "Artist is in another row";   
            }
            return "";
        }

        public static String UpdateChecker(String oldName, String newName, String path, String oldImgPath, HttpPostedFile file)
        {
            String response = CheckNameForUpdate(newName, oldName);

            if (response != "")
            {
                return response;
            }
            response = CheckFile(file);
            if (response != "")
            {
                return response;
            }
            ArtistRepository.UpdateArtist(oldName, newName, path, oldImgPath);

            return "Update Artist Successful";
        }
    }
}