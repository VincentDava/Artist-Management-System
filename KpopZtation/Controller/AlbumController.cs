using KpopZtation.Handler;
using KpopZtation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Controller
{
    public class AlbumController
    {
        private static String CheckName(String name)
        {
            if (name == "")
            {
                return "Please enter a name";
            }
            else if (name.Length >= 50)
            {
                return "Name must not be more than 50 Characters";
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
            foreach (String extension in extensions)
            {
                if (extension == file.ContentType)
                {
                    return "";
                }
            }
            return "Format of image must be .png, .jpg, .jpeg, or .jfif";
        }

        private static String CheckDesc(String desc)
        {
            if (desc == "")
            {
                return "Please enter a description";
            }
            else if (desc.Length >= 50)
            {
                return "Description must not be more than 255 Characters";
            }
            return "";
        }

        public static String CheckStringIsEmpty(String str, String label)
        {
            if (String.IsNullOrEmpty(str.ToString()))
            {
                return "Please enter a " + label;
            }
            return "";
        }

        private static String CheckPrice(int price)
        {
            int[] priceRange = {100000, 1000000};
            if (price < priceRange[0] || price > priceRange[1])
            {
                return "Price must be between " + priceRange[0] + " and " + priceRange[1];
            }
            return "";
        }

        private static String CheckStock(int stock)
        {
            if (String.IsNullOrEmpty(stock.ToString()))
            {
                return "Please enter the stock number";
            }
            else if (stock <= 0)
            {
                return "Stock must be higher than 0";
            }
            return "";
        }

        public static String Checker(int artistID, String name, String imgPath, HttpPostedFile file, int price, int stock, String desc)
        {
            String response = CheckName(name);
            if(response != "")
            {
                return response;
            }
            response = CheckFile(file);
            if (response != "")
            {
                return response;
            }
            response = CheckDesc(desc);
            if (response != "")
            {
                return response;
            }
            response = CheckPrice(price);
            if (response != "")
            {
                return response;
            }
            response = CheckStock(stock);
            if (response != "")
            {
                return response;
            }

            AlbumRepository.CreateAlbum(artistID, name, imgPath, price, stock, desc);

            return "Insert Album Successful";
        }

        public static String UpdateChecker(String oldName, String newName, String oldImgPath, String imgPath, HttpPostedFile file, int price, int stock, String desc)
        {
            String response = CheckName(newName);
            if (response != "")
            {
                return response;
            }
            response = CheckFile(file);
            if (response != "")
            {
                return response;
            }
            response = CheckDesc(desc);
            if (response != "")
            {
                return response;
            }
            response = CheckPrice(price);
            if (response != "")
            {
                return response;
            }
            response = CheckStock(stock);
            if (response != "")
            {
                return response;
            }

            AlbumRepository.UpdateAlbum(oldName, newName, oldImgPath, imgPath, price, stock, desc);

            return "Update Album Successful";
        }

    }
}